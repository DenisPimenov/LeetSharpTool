using System.Text;
using Html2Markdown;

namespace LeetSharpTool
{
    internal static class ReadmeHelper
    {
        public static string ConvertToMd(string url, string html)
        {
            var sb = new StringBuilder();
            sb.AppendLine("# Problem");
            sb.AppendLine();
            sb.AppendLine($"[Source]({url})");
            var converter = new Converter();
            sb.Append(converter.Convert(html));
            return sb.ToString();
        }
    }
}