using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace WpfBakeryTests;

/// <summary>
/// Source:
/// https://github.com/CommunityToolkit/dotnet/blob/7b53ae23dfc6a7fb12d0fc058b89b6e948f48448/tests/CommunityToolkit.Mvvm.SourceGenerators.UnitTests/Test_SourceGeneratorsCodegen.cs#L2754C23-L2754C23
/// </summary>
public static class GeneratorTesting
{
    /// <summary>
    /// Generates the requested sources
    /// </summary>
    /// <param name="source">The input source to process.</param>
    /// <param name="generators">The generators to apply to the input syntax tree.</param>
    /// <param name="results">The source files to compare.</param>
    internal static void VerifyGenerateSources(string source, IIncrementalGenerator[] generators, params (string Filename, string? Text)[] results)
        => VerifyGenerateSources(source, generators, LanguageVersion.CSharp10, results);

    /// <summary>
    /// Generates the requested sources
    /// </summary>
    /// <param name="source">The input source to process.</param>
    /// <param name="generators">The generators to apply to the input syntax tree.</param>
    /// <param name="languageVersion">The language version to use.</param>
    /// <param name="results">The source files to compare.</param>
    private static void VerifyGenerateSources(string source, IIncrementalGenerator[] generators, LanguageVersion languageVersion, params (string Filename, string? Text)[] results)
    {
        /*
        // Ensure CommunityToolkit.Mvvm and System.ComponentModel.DataAnnotations are loaded
        Type observableObjectType = typeof(ObservableObject);
        Type validationAttributeType = typeof(ValidationAttribute);*/

        // Get all assembly references for the loaded assemblies (easy way to pull in all necessary dependencies)
        IEnumerable<MetadataReference> references =
            from assembly in AppDomain.CurrentDomain.GetAssemblies()
            where !assembly.IsDynamic
            let reference = MetadataReference.CreateFromFile(assembly.Location)
            select reference;

        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(source, CSharpParseOptions.Default.WithLanguageVersion(languageVersion));

        // Create a syntax tree with the input source
        CSharpCompilation compilation = CSharpCompilation.Create(
            "original",
            new SyntaxTree[] { syntaxTree },
            references,
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        GeneratorDriver driver = CSharpGeneratorDriver.Create(generators).WithUpdatedParseOptions((CSharpParseOptions)syntaxTree.Options);

        // Run all source generators on the input source code
        _ = driver.RunGeneratorsAndUpdateCompilation(compilation, out Compilation outputCompilation, out ImmutableArray<Diagnostic> diagnostics);

        // Ensure that no diagnostics were generated
        Assert.Equal(Array.Empty<Diagnostic>(), diagnostics);

        foreach ((string filename, string? text) in results)
        {
            if (text is not null)
            {
                string filePath = filename;

                // Update the assembly version using the version from the assembly of the input generators.
                // This allows the tests to not need updates whenever the version of the MVVM Toolkit changes.
                string expectedText = text.Replace("<ASSEMBLY_VERSION>", $"\"{generators[0].GetType().Assembly.GetName().Version}\"");

#if !ROSLYN_4_3_1_OR_GREATER
                // Adjust the filenames for the legacy Roslyn 4.0
                filePath = filePath.Replace('`', '_');
#endif

                SyntaxTree generatedTree = outputCompilation.SyntaxTrees.Single(tree => Path.GetFileName(tree.FilePath) == filePath);

                Assert.Equal(expectedText, generatedTree.ToString());
            }
            else
            {
                // If the text is null, verify that the file was not generated at all
                Assert.DoesNotContain(outputCompilation.SyntaxTrees, tree => Path.GetFileName(tree.FilePath) == filename);
            }
        }

        /*
        GC.KeepAlive(observableObjectType);
        GC.KeepAlive(validationAttributeType);
        */
    }
}