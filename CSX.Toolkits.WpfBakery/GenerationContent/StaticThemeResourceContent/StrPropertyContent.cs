using CSX.Toolkits.Roslyn.Builders;
using CSX.Toolkits.Roslyn.Builders.SourceBuilderExtensions;

namespace CSX.Toolkits.WpfBakery.GenerationContent.StaticThemeResourceContent;

public static partial class StrPropertyContent
{
    public static STRGeneratorResult GenerateSourceFromManifest(this STRGeneratorManifest manifest)
    {
        return new STRGeneratorResult(
            OutputPath: manifest.GetOutputPath(),
            GeneratedCode: manifest.GenerateCode());
    }

    public static string GetOutputPath(this STRGeneratorManifest manifest)
        => $"{manifest.GetFullyQualifiedPath()}_{manifest.PropertyName}.g.cs";

    public static string GetFullyQualifiedPath(this STRGeneratorManifest manifest)
        => $"{manifest.ContainingNamespace}.{manifest.ContainingClassname}";

    public static string GenerateCode(this STRGeneratorManifest manifest)
    {
        /* // Provided
         *
         *  [StaticThemeResource(StoragePath: "StaticComponents.Storage" GetKeyMethod: "GetThatKey", ThemeSlot: "SomeBackgroundColor")]
         *  public static Color _theComponent = whatever;
         *
         * // Generated (Using VisualGenerationInspector)
            namespace My.Library.Namespace
            {
                public static partial class ThemeTestClass
                {
                    public static System.Windows.ResourceKey TheComponentKey { get; }
                        = GetThatKey(CSX.Toolkits.WpfExtensions.ThemeEngine.ThemeSlots.SomeBackgroundColor);

                    public static System.Windows.Media.Color TheComponent
                    {
                        get => _theComponent;
                        set
                        {
                            _theComponent = value;
                            StaticComponents.Storage[TheComponentKey] = value;
                        }
                    }
                }
            }
         */

        string keyName = $"{manifest.PropertyName}Key";

        SourceBuilder builder = new();
        builder.StartNamespace(manifest.ContainingNamespace);
        builder.StartClass(manifest.ContainingClassname, modifiers: "public static partial");

        builder.AddLine($"public static System.Windows.ResourceKey {keyName}" + " { get; }");
        builder.AddContinuedLine($"= {manifest.GetKeyMethodPath}(CSX.Toolkits.WpfExtensions.ThemeEngine.ThemeSlots.{manifest.ThemeSlot});");
        builder.AddEmptyLine();

        builder.AddLine($"public static {manifest.FieldType} {manifest.PropertyName}");
        builder.OpenBlockBody();
        //-
        builder.AddLine($"get => {manifest.FieldName};");
        builder.AddLine("set");
        builder.OpenBlockBody();
        //--
        builder.AddLine($"{manifest.FieldName} = value;");
        builder.AddLine($"{manifest.StoragePath}[{keyName}] = value;");
        //
        builder.CloseAllBlockBodies();

        return builder.ToString();
    }
}