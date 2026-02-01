
using System.Text.RegularExpressions;

public static class Utils
{
    public static string ToSlug(string input){
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;
        // Convert to lowercase
        string slug = input.ToLowerInvariant();
        // Remove invalid characters
        slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");
        // Convert multiple spaces into one hyphen
        slug = Regex.Replace(slug, @"[\s-]+", " ").Trim();
        // Replace spaces with hyphens
        slug = Regex.Replace(slug, @"\s", "-");
        return slug;
    }

    // private static string RemoveDiacritics(string text)
    // {
    //     var normalized = text.Normalize(NormalizationForm.FormD);
    //     var sb = new StringBuilder();

    //     foreach (var c in normalized)
    //     {
    //         if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c)
    //             != System.Globalization.UnicodeCategory.NonSpacingMark)
    //         {
    //             sb.Append(c);
    //         }
    //     }

    //     return sb.ToString().Normalize(NormalizationForm.FormC);
    // }
}