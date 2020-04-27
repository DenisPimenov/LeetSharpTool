using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using LeetProjectCreator.Models;
using Xunit;

namespace LeetProjectCreator.Tests
{
    public class CliTests
    {
        [Fact]
        public async Task Should_create_random_project()
        {
            var code = await Program.Run(new CliOptions());

            code.Success.Should().BeTrue();
            IsProjectExist(code.Value).Should().BeTrue();

            RemoveProject(code.Value);
        }

        [Fact]
        public async Task Should_create_random_project_with_level()
        {
            var code = await Program.Run(new CliOptions {Level = ProblemLevel.Hard});

            code.Success.Should().BeTrue();
            IsProjectExist(code.Value).Should().BeTrue();

            RemoveProject(code.Value);
        }

        [Fact]
        public async Task Should_create_project_from_url()
        {
            var code = await Program.Run(new CliOptions {ProblemUrl = "https://leetcode.com/problems/two-sum/"});

            code.Success.Should().BeTrue();
            IsProjectExist(code.Value).Should().BeTrue();

            RemoveProject(code.Value);
        }

        [Theory]
        [InlineData("https://explore.com")]
        [InlineData("https://leetcode.com/problems/asd/")]
        [InlineData("https://leetcode.com/problems/asd")]
        public async Task Should_return_error_if_url_is_not_leetcode_problem(string url)
        {
            var code = await Program.Run(new CliOptions {ProblemUrl = url});

            code.Success.Should().BeFalse();
            IsProjectExist(code.Value).Should().BeFalse();
        }

        private static bool IsProjectExist(string path)
        {
            return Directory.Exists(path) && new DirectoryInfo(path).GetFiles().Length > 0;
        }

        private static void RemoveProject(string path)
        {
            Directory.Delete(path, true);
        }
    }
}