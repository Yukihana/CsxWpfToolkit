using CSX.Toolkits.WpfBakery.GenerationContent.StaticThemeResourceContent;

// Detect lang version

var codegenInput = new STRGeneratorManifest(
    ContainingNamespace: "My.Library.Namespace",
    ContainingClassname: "ThemeTestClass",
    FieldName: "_theComponent",
    FieldType: "System.Windows.Media.Color",
    PropertyName: "TheComponent",
    GetKeyMethodPath: "GetThatKey",
    StoragePath: "StaticComponents.Storage",
    ThemeSlot: "SomeBackgroundColor");

var attribOutput = new STRGeneratorResult(StrAttributeContent.OutputFilename, StrAttributeContent.SourceCode);
var codegenOutput = codegenInput.GenerateSourceFromManifest();

var restoreColor = Console.ForegroundColor;
var defaultColor = ConsoleColor.DarkGray;

GenerateOutput("- ATTRIBUTE OUTPUT TEST -", attribOutput);
GenerateOutput("- GENERATED SOURCE OUTPUT TEST -", codegenOutput);

void GenerateOutput(string title, STRGeneratorResult result)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(title);
    Console.WriteLine();

    Console.ForegroundColor = defaultColor;
    Console.Write("Desination: ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(result.OutputPath);

    Console.ForegroundColor = defaultColor;
    Console.WriteLine($"Generated Source:");
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(result.GeneratedCode);

    Console.ForegroundColor = restoreColor;
    Console.WriteLine();
    Console.WriteLine();
}