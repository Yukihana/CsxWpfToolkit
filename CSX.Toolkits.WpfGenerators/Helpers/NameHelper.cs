namespace CSX.Toolkits.WpfGenerators.Extensions;

public static partial class NameHelper
{
    public static bool TryCapitalizeMemberName(this string fieldName, out string propertyName)
    {
        propertyName = fieldName;

        if (fieldName.Length < 1)
            return false;

        if (fieldName[0] == '_')
            fieldName = fieldName.Substring(1);

        if (fieldName.Length < 1)
            return false;

        if (char.ToUpperInvariant(fieldName[0]) == fieldName[0])
            return false;

        propertyName = $"{char.ToUpperInvariant(fieldName[0])}{fieldName.Substring(1)}";
        return true;
    }
}