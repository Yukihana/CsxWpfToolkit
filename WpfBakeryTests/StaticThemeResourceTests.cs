using CSX.Toolkits.WpfBakery.GenerationContent.StaticThemeResourceContent;
using CSX.Toolkits.WpfBakery.Generators;

namespace WpfBakeryTests;

public class StaticThemeResourceTests
{
    [Fact]
    public void AttributeTest()
    {
        string expected = @"namespace CSX.Toolkits.WpfBakery.Generators
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
}";

        GeneratorTesting.VerifyGenerateSources(
            source: string.Empty,
            generators: new[] { new StaticThemeResourceGenerator() },
            (StrAttributeContent.OutputFilename, expected));
    }

    [Fact]
    public void PropertyTest()
    {
        string source = @"
using System.Windows.Media;

namespace ThemeStuff;

public partial static class ThemeResources
{
    [StaticThemeResource(""Storage"", ""GetKeyMethod"", ""MyColorSlot"")]
    private static Color _myBackground = Color.FromArgb(0,0,0,0);
}
";
        string expected = @"
Get this shit from the visual inspector and finish this test
Also figure out why package mode doesn't work, but adding the roslyn dll works
";
    }
}