#pragma warning disable 8618

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace LeetSharpTool.Models
{
    [UsedImplicitly]
    public class ProblemData
    {
        [JsonProperty("titleSlug")] public string Name { get; set; }

        [JsonProperty("content")] public string Content { get; set; }

        [JsonProperty("codeSnippets")] public CodeSnippet[] CodeSnippets { get; set; }

        public class CodeSnippet
        {
            [JsonProperty("langSlug")] public string Language { get; set; }

            [JsonProperty("code")] public string Code { get; set; }
        }
    }
}