using System.Text.RegularExpressions;

namespace LeetProjectCreator
{
    internal static class HtmlUtility
    {
        private static Regex escapeHtmlRegex =
            new Regex(@"<\/?[a-z]*>", RegexOptions.Compiled | RegexOptions.Multiline);

        public static string RemoveHtmlTags(string? content)
        {
            return string.IsNullOrEmpty(content)
                ? ""
                : escapeHtmlRegex.Replace(content, "");
        }

    }
}