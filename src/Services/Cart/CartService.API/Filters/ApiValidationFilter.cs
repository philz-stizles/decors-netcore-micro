using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace CartService.API.Filters
{
    public class ApiValidationFilter : IActionFilter
    {

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                //the only output i want are the error descriptions, nothing else
                var data = context.ModelState
                    .Values
                    .SelectMany(v => v.Errors.Select(b => b.ErrorMessage))
                    .ToList();

                context.Result = new JsonResult(data) { StatusCode = 400 };
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
