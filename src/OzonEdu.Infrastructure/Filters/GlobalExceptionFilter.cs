namespace OzonEdu.Infrastructure.Filters
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exceptionInfo = new
            {
                ExceptionName = context.Exception.GetType().FullName,
                ExceptionText = context.Exception.Message,
                StackTrace = context.Exception.StackTrace
            };

            context.Result = new JsonResult(exceptionInfo)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}
