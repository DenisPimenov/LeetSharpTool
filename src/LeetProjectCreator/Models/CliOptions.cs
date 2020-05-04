using CommandLine;
using JetBrains.Annotations;

namespace LeetProjectCreator.Models
{
    [PublicAPI]
    public class CliOptions
    {
        [Option('u', "url", HelpText = "Problem url, if you want solve specific problem. " +
                                       "Example https://leetcode.com/problems/two-sum/",
            Required = false)]
        public string ProblemUrl { get; set; } = string.Empty;

        [Option('t',
            "test-framework",
            Default = "xunit",
            Required = false,
            HelpText = "Your favorite test framework. Available xunit, nunit, mstest.")]
        public string TestFramework { get; set; } = "xunit";

        [Option('l',
            "level",
            Required = false,
            HelpText = "Problem level. Easy, Middle, Hard")]
        public ProblemLevel? Level { get; set; }
    }
}