using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagementAPI.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var error = new ErrorModel
            (
                500,
                context.Exception.Message,
                context.Exception.StackTrace?.ToString()
            );

            context.Result = new JsonResult(error);
        }
    }
}
