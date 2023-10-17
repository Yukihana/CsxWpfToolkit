using CSX.Toolkits.WpfGenerators.Extensions;
using CSX.Toolkits.WpfGenerators.Helpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System.Linq;
using System.Text;
using System.Threading;

namespace CSX.Toolkits.WpfGenerators.StaticThemeResource;

public class STRGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Note:
        // IVPs are data for incremental steps, that can be cached by the pipeline.
        // Note: ImmutableArrays aren't Equatable by default.
        // Use records and EquatableArrays to prevent unnecessary step regeneration.
        // Think of it as a per-keystroke thing, that may cause performance dips.
        // So save/cache state as much as possible, and make sure the steps are equatable.

        // Step 1:
        // Register a callback to add the marker attribute.
        // (If you want it automatically added by the generator)
        // This is not syntax provider dependent code.
        // This gets added right after initialization, before any input-dependent content is generated.
        context.RegisterPostInitializationOutput(AttachAttributeSource);

        // Step 2:
        // Filter and transform using FAWMN
        // SemanticModel and symbol handling should only be done till this step.
        // Only use your-models after this. Do not hold on to roslyn compilation types.
        // Use only record or EquatableArray output models.
        IncrementalValuesProvider<STRGeneratorManifest> provider = context.SyntaxProvider
            .ForAttributeWithMetadataName(
            fullyQualifiedMetadataName: AttributeSources.FullyQualifiedName,
            predicate: SimpleSyntaxFilterAction,            // simple: select fields with attributes
            transform: DetailedSelectAndTransformAction)    // complex: transform relevant fields to generatorManifest models, null the rest
            .WhereNotNull();                                // cleanup: remove those null entries

        // context.CompilationProvider.Combine<Compilation,Model>
        // Unless you need to reprocess the parsed data, Combine isn't required.
        // Go directly to RegisterSourceOutput otherwise
        // var src = context.CompilationProvider.Combine<Compilation, IncrementalValuesProvider<STRGeneratorManifest>>(generationManifests);

        // Register a callback that can generate the code,
        // from the models created in the previous step.
        // Execute will be called for all the models separately.
        // To execute on all models at once, call '.Collect()' on the value provider:
        // It will produce an ImmutableArray that will be passed instead of the models individually.
        context.RegisterSourceOutput(provider, SourceGenerationAction);
    }

    // Generate 'post init' attributes not added by target or dependency libraries.
    private static void AttachAttributeSource(IncrementalGeneratorPostInitializationContext context) => context.AddSource(
        hintName: AttributeSources.OutputFilename,
        sourceText: SourceText.From(AttributeSources.SourceCode, Encoding.UTF8));

    // Light weight filter to rule out most unneeded nodes
    private static bool SimpleSyntaxFilterAction(SyntaxNode node, CancellationToken ctoken = default)
        => node is FieldDeclarationSyntax f && f.AttributeLists.Any();

    // Precision filter and model converter.
    // 1 - Handle advanced checks for filtering
    // 2 - Package everything required for codegen into a generation manifest
    //
    // The generation manifest is your custom storage model
    // which will also be sent as input data for generating code later.
    //
    // The outputs from all calls to this method will be packaged into
    // an incremental step.
    //
    // This is the final method till where symbol-types should be accessed
    // aka, no checks on symbol-types later on.
    private static STRGeneratorManifest? DetailedSelectAndTransformAction(GeneratorAttributeSyntaxContext context, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();

        // Verify attribute data first
        bool dataAttributeFound = false;
        string storagePath = string.Empty;
        string getKeyMethodPath = string.Empty;
        string themeSlot = string.Empty;

        foreach (var data in context.Attributes)
        {
            if (data.AttributeClass is not INamedTypeSymbol attributeSymbol ||
                attributeSymbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat) != AttributeSources.FullyQualifiedName)
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

        if (!fieldName.TryCapitalizeMemberName(out string propertyName))
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

    // Where the actual fun stuff happens:
    // Generating the output code.
    private static void SourceGenerationAction(SourceProductionContext context, STRGeneratorManifest manifest)
    {
        var result = GeneratedSources.GenerateSourceFromManifest(manifest);
        context.AddSource(result.OutputPath, SourceText.From(result.GeneratedCode, Encoding.UTF8));
    }
}