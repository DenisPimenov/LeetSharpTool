using LeetSharpTool.Common;

namespace LeetSharpTool
{
    public static class ProgramErrors
    {
        public static readonly Error InvalidArgsError = new Error("Invalid args", 1);
        
        public static readonly Error ProblemsFetchError = new Error("Cannot fetch problems from leetcode", 1);

        public static readonly Error CannotSelectProblemError = new Error("Cannot select random problem", 1);

        public static readonly Error ProblemAlreadyExist = new Error("Problem already exist", 1);

        public static Error ProblemParseError(string? problemUrl)
        {
            return new Error(@$"Invalid problem url ""{problemUrl}""", 1);
        }

        public static Error ProblemFetchError(string? problemName)
        {
            return new Error(@$"Cannot fetch problem ""{problemName}"" from leetcode", 1);
        }

        public static Error NotSupportedLanguageError()
        {
            return new Error("C# not supported for this problem", 1);
        }
    }
}