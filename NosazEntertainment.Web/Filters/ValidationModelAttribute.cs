using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NosazEntertainment.Web.Models;

namespace NosazEntertainment.Web.Filters
{
    public class ValidationModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(new ApiResult
                {
                    Status = ApiResultStatus.ModelValidation,
                    ModelErrors = context.ModelState
                });
            }
        }
    }
}
