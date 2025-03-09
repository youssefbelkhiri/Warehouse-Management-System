using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Backend.Domain.Common.Result
{
    public class Result<T> : Result
    {
        public T? Value { get; set; }

        public static Result<T> Success(T value, string message = "")
        {
            return new Result<T> { Succeeded = true, Value = value, Message = message };
        }

        public static new Result<T> Failure(IEnumerable<string> errors)
        {
            return new Result<T> { Succeeded = false, Errors = errors };
        }
    }
}
