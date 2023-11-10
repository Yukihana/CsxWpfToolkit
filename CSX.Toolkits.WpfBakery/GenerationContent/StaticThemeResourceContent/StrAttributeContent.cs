using CSX.Toolkits.Roslyn.Builders;
using CSX.Toolkits.Roslyn.Builders.SourceBuilderExtensions;

namespace CSX.Toolkits.WpfBakery.GenerationContent.StaticThemeResourceContent;

public static partial class StrAttributeContent
{
    public const string ContainingNamespace = "CSX.Toolkits.WpfBakery.Generators";
    public const string Classname = "StaticThemeResourceAttribute";

    public static string FullyQualifiedName { get; } = $"{ContainingNamespace}.{Classname}";
    public static string OutputFilename { get; } = $"{ContainingNamespace}.{Classname}.g.cs";
    public static string SourceCode { get; } = GenerateAttributeSourceCode();

    /* VisualGenerationInspector result
     *
namespace CSX.Toolkits.WpfGenerators
{
    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = false)]
    public partial class StaticThemeResourceAttribute : System.Attribute
    {
        public string StoragePath { get; private set; }
        public string GetKeyMethod { get; private set; }
        public string ThemeSlot { get; private set; }

        public StaticThemeResourceAttribute(
            string StoragePath,
            string GetKeyMethod,
            string ThemeSlot)
        {
            this.StoragePath = StoragePath;
            this.GetKeyMethod = GetKeyMethod;
            this.ThemeSlot = ThemeSlot;
        }
    }
}
     */

    private static string GenerateAttributeSourceCode()
    {
        SourceBuilder builder = new();
        // Namespace
        builder.StartNamespace(ContainingNamespace);
        //- Class
        builder.StartFieldUsageAttributeClass(Classname, allowMultiple: false);
        //-- Properties
        builder.AddAutoProperty("StoragePath", "string", AutoPropertyAccessors.GetPrivateSet);
        builder.AddAutoProperty("GetKeyMethod", "string", AutoPropertyAccessors.GetPrivateSet);
        builder.AddAutoProperty("ThemeSlot", "string", AutoPropertyAccessors.GetPrivateSet);
        builder.AddEmptyLine();
        //-- Ctor (StoragePath, GetKeyMethod, ThemeSlot)
        builder.AddLine($"public {Classname}(");
        builder.AddContinuedLines(
            "string StoragePath,",
            "string GetKeyMethod,",
            "string ThemeSlot)");
        //-- Assignment
        builder.OpenBlockBody();
        builder.AddConstructorAssignments(
            "StoragePath",
            "GetKeyMethod",
            "ThemeSlot");
        // Finish
        builder.CloseAllBlockBodies();
        return builder.ToString();
    }
}