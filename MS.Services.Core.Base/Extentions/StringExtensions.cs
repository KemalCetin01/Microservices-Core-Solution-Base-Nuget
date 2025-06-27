using System.Globalization;

namespace MS.Services.Core.Base.Extentions;

public static class StringExtensions
{

    public static string RemoveWhitespace(this string input)
    {
        return new string(input.ToCharArray()
            .Where(c => !char.IsWhiteSpace(c))
            .ToArray());
    }

    public static bool Contains(this string source, string toCheck, StringComparison comp)
    {
        return source?.IndexOf(toCheck, comp) >= 0;
    }

    public static string RemoveMultipleWhitespaces(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        return string.Join(" ", input.Split(' ', '\n', '\r').Where(s => !string.IsNullOrWhiteSpace(s)));
    }

    /// <summary>
    ///     Adds '\' to end of given string if it does not ends with the char.
    /// </summary>
    public static string EnsureEndsWithBackSlash(this string str)
    {
        return EnsureEndsWith(str, '\\', StringComparison.Ordinal);
    }

    /// <summary>
    ///     Adds '/' to end of given string if it does not ends with the char.
    /// </summary>
    public static string EnsureEndsWithSlash(this string str)
    {
        return EnsureEndsWith(str, '/', StringComparison.Ordinal);
    }

    /// <summary>
    ///     Adds a char to end of given string if it does not ends with the char.
    /// </summary>
    public static string EnsureEndsWith(this string str, char c)
    {
        return EnsureEndsWith(str, c, StringComparison.Ordinal);
    }

    /// <summary>
    ///     Adds a char to end of given string if it does not ends with the char.
    /// </summary>
    public static string EnsureEndsWith(this string str, char c, StringComparison comparisonType)
    {
        if (str == null) throw new ArgumentNullException(nameof(str));

        if (str.EndsWith(c.ToString(), comparisonType)) return str;

        return str + c;
    }

    /// <summary>
    ///     Adds a char to end of given string if it does not ends with the char.
    /// </summary>
    public static string EnsureEndsWith(this string str, char c, bool ignoreCase, CultureInfo culture)
    {
        if (str == null) throw new ArgumentNullException(nameof(str));

        if (str.EndsWith(c.ToString(culture), ignoreCase, culture)) return str;

        return str + c;
    }

    /// <summary>
    ///     Adds a char to beginning of given string if it does not starts with the char.
    /// </summary>
    public static string EnsureStartsWith(this string str, char c)
    {
        return EnsureStartsWith(str, c, StringComparison.Ordinal);
    }

    /// <summary>
    ///     Adds a char to beginning of given string if it does not starts with the char.
    /// </summary>
    public static string EnsureStartsWith(this string str, char c, StringComparison comparisonType)
    {
        if (str == null) throw new ArgumentNullException(nameof(str));

        if (str.StartsWith(c.ToString(), comparisonType)) return str;

        return c + str;
    }

    /// <summary>
    ///     Adds a char to beginning of given string if it does not starts with the char.
    /// </summary>
    public static string EnsureStartsWith(this string str, char c, bool ignoreCase, CultureInfo culture)
    {
        if (str == null) throw new ArgumentNullException("str");

        if (str.StartsWith(c.ToString(culture), ignoreCase, culture)) return str;

        return c + str;
    }

    /// <summary>
    ///     Indicates whether this string is null or an System.String.Empty string.
    /// </summary>
    public static bool IsNullOrEmpty(this string str)
    {
        return string.IsNullOrEmpty(str);
    }

    /// <summary>
    ///     indicates whether this string is null, empty, or consists only of white-space characters.
    /// </summary>
    public static bool IsNullOrWhiteSpace(this string str)
    {
        return string.IsNullOrWhiteSpace(str);
    }

    /// <summary>
    ///     Converts PascalCase string to camelCase string.
    /// </summary>
    /// <param name="str">String to convert.</param>
    /// <param name="invariantCulture">Invariant culture.</param>
    /// <returns>camelCase of the string.</returns>
    public static string ToCamelCase(this string str, bool invariantCulture = true)
    {
        if (string.IsNullOrWhiteSpace(str)) return str;

        if (str.Length == 1) return invariantCulture ? str.ToLowerInvariant() : str.ToLower();

        return (invariantCulture ? char.ToLowerInvariant(str[0]) : char.ToLower(str[0])) + str.Substring(1);
    }

    /// <summary>
    ///     Converts PascalCase string to camelCase string in specified culture.
    /// </summary>
    /// <param name="str">String to convert.</param>
    /// <param name="culture">An object that supplies culture-specific casing rules.</param>
    /// <returns>camelCase of the string.</returns>
    public static string ToCamelCase(this string str, CultureInfo culture)
    {
        if (string.IsNullOrWhiteSpace(str)) return str;

        if (str.Length == 1) return str.ToLower(culture);

        return char.ToLower(str[0], culture) + str.Substring(1);
    }

    /// <summary>
    ///     Converts camelCase string to PascalCase string.
    /// </summary>
    /// <param name="str">String to convert.</param>
    /// <param name="invariantCulture">Invariant culture.</param>
    /// <returns>PascalCase of the string.</returns>
    public static string ToPascalCase(this string str, bool invariantCulture = true)
    {
        if (string.IsNullOrWhiteSpace(str)) return str;

        if (str.Length == 1) return invariantCulture ? str.ToUpperInvariant() : str.ToUpper();

        return (invariantCulture ? char.ToUpperInvariant(str[0]) : char.ToUpper(str[0])) + str.Substring(1);
    }

    /// <summary>
    ///     Converts camelCase string to PascalCase string in specified culture.
    /// </summary>
    /// <param name="str">String to convert.</param>
    /// <param name="culture">An object that supplies culture-specific casing rules.</param>
    /// <returns>PascalCase of the string.</returns>
    public static string ToPascalCase(this string str, CultureInfo culture)
    {
        if (string.IsNullOrWhiteSpace(str)) return str;

        if (str.Length == 1) return str.ToUpper(culture);

        return char.ToUpper(str[0], culture) + str.Substring(1);
    }

    /// <summary>
    ///     Gets a substring of a string from beginning of the string if it exceeds maximum length.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="str" /> is null.</exception>
    public static string? Truncate(this string? str, int maxLength)
    {
        if (str == null) return null;

        if (str.Length <= maxLength) return str;

        return str.Left(maxLength);
    }

    /// <summary>
    ///     Gets a substring of a string from beginning of the string if it exceeds maximum length.
    ///     It adds a "..." postfix to end of the string if it's truncated.
    ///     Returning string can not be longer than maxLength.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="str" /> is null.</exception>
    public static string TruncateWithPostfix(this string str, int maxLength)
    {
        return TruncateWithPostfix(str, maxLength, "...");
    }

    /// <summary>
    ///     Gets a substring of a string from beginning of the string if it exceeds maximum length.
    ///     It adds given <paramref name="postfix" /> to end of the string if it's truncated.
    ///     Returning string can not be longer than maxLength.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="str" /> is null.</exception>
    public static string? TruncateWithPostfix(this string? str, int maxLength, string postfix)
    {
        if (str == null) return null;

        if (str == string.Empty || maxLength == 0) return string.Empty;

        if (str.Length <= maxLength) return str;

        if (maxLength <= postfix.Length) return postfix.Left(maxLength);

        return str.Left(maxLength - postfix.Length) + postfix;
    }

    /// <summary>
    ///     Gets a substring of a string from beginning of the string.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="str" /> is null.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="len" /> is bigger that string's length.</exception>
    public static string Left(this string str, int len)
    {
        if (str == null) throw new ArgumentNullException("str");

        if (str.Length < len) throw new ArgumentException("len argument can not be bigger than given string's length!");

        return str.Substring(0, len);
    }
    
    /// <summary>
    ///     Create Key for Localization
    /// </summary>
    public static string CreateLocalizationKey(this string str, string name,string property,string Id)
    {
        return $"{name.ToLower()}_{property.ToLower()}_{Id}";
    }

}