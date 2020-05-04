using System;
using System.Diagnostics;

namespace LeetSharpTool
{
    public static class DotnetCliApi
    {
        public static int CreateProject(string projectType, string output)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = $"new {projectType} -o {output}"
            };
            var process = Process.Start(startInfo);
            if (process == null)
                throw new InvalidOperationException("Process cannot be started");

            process.WaitForExit();
            return process.ExitCode;
        }
    }
}