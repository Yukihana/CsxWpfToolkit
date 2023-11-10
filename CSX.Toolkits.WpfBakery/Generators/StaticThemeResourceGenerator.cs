using CSX.Toolkits.Roslyn.RoslynToolkitExtensions;
using CSX.Toolkits.WpfBakery.GenerationContent.StaticThemeResourceContent;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System.Linq;
using System.Text;
using System.Threading;

namespace CSX.Toolkits.WpfBakery.Generators;

[Generator(LanguageNames.CSharp)]
public class StaticThemeResourceGenerator : IIncrementalGenerator
{
    /// <summary>
    /// The entry point required for the generator implementation.
    /// </summary>
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Add code that will be added regardless of code input.
        // aka attribute classes, etc.
        context.RegisterPostInitializationOutput(static ctx => ctx.AddSource(
            StrAttributeContent.OutputFilename,
            SourceText.From(StrAttributeContent.SourceCode, Encoding.UTF8)));

        // Filter relevant nodes and convert them into manifest models for generation
        IncrementalValuesProvider<STRGeneratorManifest> provider = context.SyntaxProvider
            .ForAttributeWithMetadataName(
            fullyQualifiedMetadataName: StrAttributeContent.FullyQualifiedName,
            predicate: static (node, ctoken) => SimpleSyntaxFilterAction(node, ctoken),             // simple: select fields with attributes
            transform: static (ctx, ctoken) => DetailedSelectAndTransformAction(ctx, ctoken))       // complex: transform relevant fields to generatorManifest models, null the rest
            .WhereNotNull()
            .WithTrackingName("CodeManifests");                                                                        // cleanup: remove those null entries

        // Register code generation action
        context.RegisterSourceOutput(
            source: provider,
            action: static (ctx, manifest) => SourceGenerationAction(ctx, manifest));
    }

    // Light weight filter to rule out most unneeded nodes
    private static bool SimpleSyntaxFilterAction(SyntaxNode node, CancellationToken ctoken = default)
    {
        ctoken.ThrowIfCancellationRequested();

        return node is FieldDeclarationSyntax f
            && f.AttributeLists.Any();
    }

    // Handle expensive checks here and package the models into an IEquatable for hashed incremental caching.
    // This will be the last step where roslyn node types are used. Package the output accordingly.
    private static STRGeneratorManifest? DetailedSelectAndTransformAction(GeneratorAttributeSyntaxContext context, CancellationToken ctoken)
    {
        ctoken.ThrowIfCancellationRequested();

        // Verify attribute data first
        bool dataAttributeFound = false;
        string storagePath = string.Empty;
        string getKeyMethodPath = string.Empty;
        string themeSlot = string.Empty;

        foreach (var data in context.Attributes)
        {
            if (data.AttributeClass is not INamedTypeSymbol attributeSymbol ||
                attributeSymbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat) != StrAttributeContent.FullyQualifiedName)
                continue;

            if (data.AttributeConstructor is null)
                continue;

            var paramNames = data.AttributeConstructor.Parameters;
            var paramValues = data.ConstructorArguments;

            if (paramNames.Length != paramValues.Length)
                continue;

            bool HasStoragePathParam = false;
            bool HasGetKeyMethodParam = false;
            bool HasThemeSlotParam = false;

            foreach (var paramArg in paramNames.Zip(paramValues, (a, b) => (a, b)))
            {
                if (paramArg.b.Value is string paramValue &&
                    !string.IsNullOrEmpty(paramValue))
                {
                    if (paramArg.a.Name == "StoragePath")
                    {
                        storagePath = paramValue;
                        HasStoragePathParam = true;
                        continue;
                    }
                    if (paramArg.a.Name == "GetKeyMethod")
                    {
                        getKeyMethodPath = paramValue;
                        HasGetKeyMethodParam = true;
                        continue;
                    }
                    if (paramArg.a.Name == "ThemeSlot")
                    {
                        storagePath = paramValue;
                        HasThemeSlotParam = true;
                        continue;
                    }
                }
            }

            if (HasStoragePathParam && HasGetKeyMethodParam && HasThemeSlotParam)
            {
                dataAttributeFound = true;
                break;
            }
        }

        // bail if the required attribute with sufficient data could not be found
        if (!dataAttributeFound)
            return null;

        // Start reading field details if attributes qualify.
        var fieldSymbol = (IFieldSymbol)context.TargetSymbol;

        string containingNamespace = fieldSymbol.ContainingNamespace.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
        if (string.IsNullOrEmpty(containingNamespace))
            return null;

        string containingClassname = fieldSymbol.ContainingType.Name;
        if (string.IsNullOrEmpty(containingClassname))
            return null;

        string fieldType = fieldSymbol.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
        if (string.IsNullOrEmpty(fieldType))
            return null;

        string fieldName = fieldSymbol.ToDisplayString();
        if (string.IsNullOrEmpty(fieldName))
            return null;

        if (!fieldSymbol.IsStatic)
            return null;

        if (fieldSymbol.DeclaredAccessibility is not Accessibility.Private and not Accessibility.NotApplicable)
            return null;

        if (NamingExtensions.GetPropertyNameFromField(fieldName) is not string propertyName ||
            string.IsNullOrWhiteSpace(propertyName))
            return null;

        return new(
            ContainingNamespace: containingNamespace,
            ContainingClassname: containingClassname,
            FieldType: fieldType,
            FieldName: fieldName,

            PropertyName: propertyName,
            GetKeyMethodPath: getKeyMethodPath,
            StoragePath: storagePath,
            ThemeSlot: themeSlot);
    }

    private static void SourceGenerationAction(SourceProductionContext context, STRGeneratorManifest manifest)
    {
        var result = manifest.GenerateSourceFromManifest();
        context.AddSource(result.OutputPath, SourceText.From(result.GeneratedCode, Encoding.UTF8));
    }
}