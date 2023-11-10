namespace CSX.Toolkits.WpfBakery.GenerationContent.StaticThemeResourceContent;

public record STRGeneratorManifest(
    string ContainingNamespace,
    string ContainingClassname,
    string FieldName,
    string FieldType,
    string PropertyName,
    string GetKeyMethodPath,
    string StoragePath,
    string ThemeSlot);

public record STRGeneratorResult(
    string OutputPath,
    string GeneratedCode);