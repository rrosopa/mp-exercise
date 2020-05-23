using ExerciseFive.Core.Constants;
using System.Collections.Generic;
using System.Linq;

namespace ExerciseFive.Core.Models
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }
        public List<Error> Errors { get; set; }
        public bool HasErrors => Errors.Any(x => x.ErrorType == ErrorType.Error);

        public BaseResponse()
        {
            Errors = new List<Error>();
        }
    }
}
