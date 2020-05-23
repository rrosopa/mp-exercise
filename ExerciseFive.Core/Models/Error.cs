using ExerciseFive.Core.Constants;

namespace ExerciseFive.Core.Models
{
    public class Error
    {
        public ErrorType ErrorType { get; set; } = ErrorType.Error;
        public string Code { get; set; }
        public string Message { get; set; }

        public Error(string code)
        {
            Code = code;
            Message = "An error has occured while processing your request.";
        }

        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public Error(string code, string message, ErrorType errorType)
        {
            Code = code;
            Message = message;
            ErrorType = errorType;
        }
    }
}
