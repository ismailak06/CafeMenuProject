using Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result()
        {

        }

        public Result(bool success)
        {
            Success = success;
        }

        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        public Result(bool success, IList<ValidationError> validationErrors)
        {
            Success = success;
            ValidationErrors = validationErrors;
        }
        public Result(bool success, string message, IList<ValidationError> validationErrors) : this(success, message)
        {
            ValidationErrors = validationErrors;
        }

        public bool Success { get; }

        public string Message { get; }

        public IList<ValidationError> ValidationErrors { get; }
    }
}
