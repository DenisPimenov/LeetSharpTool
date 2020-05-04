using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using LeetSharpTool.Common;
using LeetSharpTool.Models;
using static LeetSharpTool.Common.Result;
using static LeetSharpTool.ProgramErrors;

namespace LeetSharpTool
{
    public static class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var result = await Parser.Default.ParseArguments<CliOptions>(args)
                .MapResult(
                    opt => Run(opt),
                    _ => Task.FromResult(Fail<string>(InvalidArgsError)));

            if (result.Success)
            {
                var fullPath = Path.GetFullPath($"./{result.Value}", Environment.CurrentDirectory);
                Console.WriteLine($"Project {fullPath} created");
                return 0;
            }

            if (result.Error != InvalidArgsError)
            {
                await Console.Error.WriteLineAsync(result.Error.Message);
            }
            return result.Error.Code;
        }

        public static async Task<Result<string>> Run(CliOptions options)
        {
            return await LeetCodeApi.GetAllProblems()
                .Map(problems => SelectProblem(options, problems))
                .Map(LeetCodeApi.GetProblemData)
                .Map(data => CreateProject(options.TestFramework, data));
        }

        private static Result<string> SelectProblem(CliOptions options, Problem[] problems)
        {
            return string.IsNullOrWhiteSpace(options.ProblemUrl)
                ? GetRandomProblem(problems, options.Level)
                : ParseFromUrl(problems, options.ProblemUrl);

            static Result<string> GetRandomProblem(Problem[] allProblems, ProblemLevel? problemLevel)
            {
                var freeProblems = allProblems.Where(p => !p.PaidOnly);
                var filtered = problemLevel.HasValue
                    ? freeProblems.Where(p => p.Difficulty?.ProblemLevel == problemLevel).ToList()
                    : freeProblems.ToList();

                foreach (var problem in filtered.Shuffle())
                {
                    var name = problem.Stat.Name;
                    if (!Directory.Exists(name))
                    {
                        return name;
                    }
                }

                return CannotSelectProblemError;
            }

            static Result<string> ParseFromUrl(Problem[] allProblems, string url)
            {
                var name = url.Split("/")
                    .LastOrDefault(s => s.Length != 0);
                if (string.IsNullOrEmpty(name))
                    return ProblemParseError(url);

                var problem = allProblems.FirstOrDefault(p =>
                    string.Equals(p.Stat.Name, name, StringComparison.InvariantCulture));
                if (problem == null)
                    return ProblemParseError(url);

                if (Directory.Exists(name))
                    return ProblemAlreadyExist;

                return name;
            }
        }

        private static Result<string> CreateProject(string testFramework, ProblemData problemData)
        {
            var name = problemData.Name;
            var csharpSnippet = problemData.CodeSnippets.FirstOrDefault(s => s.Language == "csharp");
            if (csharpSnippet == null)
                return NotSupportedLanguageError();

            DotnetCliApi.CreateProject(testFramework, $"./{name}");

            var mdContent = ReadmeHelper.ConvertToMd($"{LeetCodeApi.ProblemsUrl}/{name}",problemData.Content);
            File.AppendAllText($"./{name}/Readme.md", mdContent);
            File.AppendAllText($"./{name}/Problem.cs", csharpSnippet.Code);
            return name;
        }
    }
}