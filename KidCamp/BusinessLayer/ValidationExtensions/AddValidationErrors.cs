using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

public static class ValidationExtensions
{
    public static void AddValidationErrors(this ValidationResult validationResult,ModelStateDictionary modelState )
    {
        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}

