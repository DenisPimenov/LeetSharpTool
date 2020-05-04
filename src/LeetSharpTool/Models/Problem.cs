#pragma warning disable 8618

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace LeetSharpTool.Models
{
    [UsedImplicitly]
    public class Problem
    {
        [JsonProperty("stat")] public ProblemStat Stat { get; set; }

        [JsonProperty("difficulty")] public ProblemDifficulty Difficulty { get; set; }

        [JsonProperty("paid_only")] public bool PaidOnly { get; set; }

        public class ProblemStat
        {
            [JsonProperty("question__title_slug")] public string Name { get; set; }
        }

        public class ProblemDifficulty
        {
            [JsonProperty("level")]
            public ProblemLevel ProblemLevel { get; set; }
        }
    }
}