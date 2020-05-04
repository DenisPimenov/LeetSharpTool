# LeetSharpTool

This repo contains [dotnet global tool](https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools-how-to-use) for creating dotnet projects from [Leetcode problems](https://leetcode.com/problemset/all/)

Tool uses the api of Leetcode and creates a dotnet unit test project with a initial code and readme about a problem

## Instalation

```console
dotnet tool install --global LeetSharpTool
```

## Examples

1. Creates a project for a random problem
```console
leetsharp
```

2. With the specified difficulty
```console
leetsharp -l Middle
```

3. Direct from url
```console
leetsharp -u https://leetcode.com/problems/two-sum
```

4. With the specified unit test framework (default xUnit)
```console
leetsharp -t xunit
```
