using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;


namespace ProductManagementAPI.Filters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        private Stopwatch stopwatch;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            stopwatch = Stopwatch.StartNew();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            stopwatch.Stop();
            var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            var message = $"Action took {elapsedMilliseconds} ms to execute.";
            Console.WriteLine(message);
        }
    }
}
