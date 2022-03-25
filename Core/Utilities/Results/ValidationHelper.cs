using Core.Extensions;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public static class ValidationHelper
    {
        public static IList<ValidationError> GetErrors(IList<ValidationFailure> errors, string TypeName = null)
        {
            IList<ValidationError> errorList = new List<ValidationError>();
            foreach (var error in errors)
            {
                errorList.Add(new ValidationError
                {
                    TypeName = TypeName,
                    PropertyName = error.PropertyName,
                    ErrorMessage = error.ErrorMessage
                });
            }
            return errorList;
        }
    }
}
