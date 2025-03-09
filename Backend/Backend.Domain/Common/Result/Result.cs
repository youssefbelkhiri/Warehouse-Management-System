using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Backend.Domain.Common.Result
{
    public class Result
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public static Result Success(string message = "")
        {
            return new Result { Succeeded = true, Message = message };
        }

        public static Result Failure(IEnumerable<string> errors)
        {
            return new Result { Succeeded = false, Errors = errors };
        }

    }
}
