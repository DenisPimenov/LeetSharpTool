using LeetProjectCreator.Common;

namespace LeetProjectCreator
{
    public static class Errors
    {
        public static readonly Error InvalidArgsError = new Error("Invalid args", 1);

        public static Error ProblemParseError(string? problemUrl)
        {
            return new Error(@$"Invalid problem url ""{problemUrl}""", 1);
        }

        public static Error ProblemFetchError(string? problemName)
        {
            return new Error(@$"Cannot fetch problem ""{problemName}"" from leetcode", 1);
        }

        public static Error ProblemsFetchError()
        {
            return new Error("Cannot fetch problems from leetcode", 1);
        }

        public static Error ProblemDataParsedError()
        {
            return new Error("Cannot parse problem's data from leetcode", 1);
        }

        public static Error NotSupportedLanguageError()
        {
            return new Error("C# not supported for this problem", 1);
        }
    }
}