using CSX.Toolkits.WpfGenerators.StaticThemeResource;

namespace GeneratorTester;

public class STRDataTests
{
    [Fact]
    public void ManifestEquality()
        => Assert.Equal(GetManifest(), GetManifest());

    private static STRGeneratorManifest GetManifest() => new(
        ContainingNamespace: "My.Library.Namespace",
        ContainingClassname: "ThemeTestClass",
        FieldName: "_theComponent",
        FieldType: "System.Windows.Media.Color",
        PropertyName: "TheComponent",
        GetKeyMethodPath: "GetThatKey",
        StoragePath: "StaticComponents.Storage",
        ThemeSlot: "SomeBackgroundColor");

    [Fact]
    public void ResultEquality()
        => Assert.Equal(GetResult(), GetResult());

    private static STRGeneratorResult GetResult() => new(
        OutputPath: "Some.Path",
        GeneratedCode: "public class Whatever { }");
}