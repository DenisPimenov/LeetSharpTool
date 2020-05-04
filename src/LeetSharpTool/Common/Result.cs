using System;

namespace LeetSharpTool.Common
{
    public class Result
    {
        private readonly Error error;

        protected Result(bool success, Error error = default)
        {
            Success = success;
            this.error = error ?? new Error("", 0);
        }

        public bool Success { get; }

        public Error Error
        {
            get
            {
                if (Success)
                    throw new InvalidOperationException("Result is success");

                return error;
            }
        }

        public static Result Ok() => new Result(true);

        public static Result<T> Ok<T>(T data) => new Result<T>(true, data);

        public static Result<T> Fail<T>(Error error) => new Result<T>(false, default!, error);

        public static Result Fail(Error error) => new Result(false, error);

        public static implicit operator Result(Error error) => Fail(error);
    }

    public class Result<T> : Result
    {
        public Result(bool success, T value, Error error = default) : base(success, error)
        {
            Value = value;
        }

        public T Value { get; }

        public static implicit operator Result<T>(T data) => Ok(data);

        public static implicit operator Result<T>(Error error) => Fail<T>(error);
    }
}