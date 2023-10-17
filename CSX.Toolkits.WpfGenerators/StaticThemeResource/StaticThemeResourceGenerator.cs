using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace CSX.Toolkits.WpfGenerators.StaticThemeResource;

[Generator(LanguageNames.CSharp)]
public class StaticThemeResourceGenerator : IIncrementalGenerator
{
    /// <summary>
    /// The entry point required for the generator implementation.
    /// </summary>
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Add the code to be added anyway
        // aka the StaticThemeResourceAttribute class
        context.RegisterPostInitializationOutput(static ctx => ctx.AddSource(
            AttributeSources.OutputFilename,
            SourceText.From(AttributeSources.SourceCode, Encoding.UTF8)));
    }
}