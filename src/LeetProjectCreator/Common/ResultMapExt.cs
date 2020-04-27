using System;
using System.Threading.Tasks;

namespace LeetProjectCreator.Common
{
    public static class ResultMapExt
    {
        public static async Task<Result<D>> Map<T, D>(this Task<Result<T>> task, Func<T, Task<Result<D>>> map)
        {
            var result = await task;
            if (result.Success)
                return await map(result.Value);

            return new Result<D>(result.Success, default!, result.Error);
        }

        public static async Task<Result<D>> Map<T, D>(this Task<Result<T>> task, Func<T, Result<D>> map)
        {
            var result = await task;
            return result.Success
                ? map(result.Value)
                : new Result<D>(result.Success, default!, result.Error);
        }
    }
}