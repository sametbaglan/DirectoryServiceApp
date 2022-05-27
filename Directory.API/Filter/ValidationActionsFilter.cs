using Directory.Core.Dto.ResponseResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Directory.API.Filter
{
    public class ValidationActionsFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var error = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(Response<NoContentResult>.Fail(error, 400));
            }
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.ModelState.IsValid)
            {
                var errors = filterContext.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                filterContext.Result = new BadRequestObjectResult(Response<NoContentResult>.Fail(errors, 400));
            }
        }
    }
}
