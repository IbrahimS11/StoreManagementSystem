using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace StoreManagementSystem.Filters
{
    public class HandleErrorFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<HandleErrorFilter> _logger;

        public HandleErrorFilter(ILogger<HandleErrorFilter> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Unhandled exception occurred");

            context.Result = new JsonResult(new
            {
                IsSuccess = false,
                Error = "Something went wrong, please try again later"
            })
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }

}
