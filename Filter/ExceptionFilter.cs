using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace StudentMarks.Filter
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {

        // Custom Exception filter.
        public override void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
            context.Result = new ObjectResult(new { err = true, errDesc = ex.Message })
            { StatusCode = 500 };
        }
    }
}
