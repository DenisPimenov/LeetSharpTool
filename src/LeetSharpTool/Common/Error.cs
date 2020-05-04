namespace LeetSharpTool.Common
{
    public class Error
    {
        public Error(string message, int code)
        {
            Message = message;
            Code = code;
        }

        public int Code { get; }

        public string Message { get; }
    }
}