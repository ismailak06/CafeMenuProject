using Core.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace AdminPanel.Functions.Validation.FluentValidation
{
    public static class ValidationTool
    {
        public static void ValidateModel(this ModelStateDictionary modelState, IList<ValidationError> validationErrors, string rootTypeName = null)
        {
            foreach (var error in validationErrors)
                modelState.AddModelError(string.IsNullOrEmpty(rootTypeName) ? error.TypeName : rootTypeName + "." + error.TypeName + "." + error.PropertyName, error.ErrorMessage);
        }
    }
}
