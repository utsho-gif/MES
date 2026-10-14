using Microsoft.AspNetCore.Mvc.Filters;
using MES.Core.Response;
using System.Collections.Generic;
using System.Linq;
using static MES.Core.Enum;

namespace MES.Core.ActionFilters
{
    public class RequestModelFilter : IActionFilter, IAuthorizationFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var log = context.GenerateLog();
            context.HttpContext.Items["log"] = log;

            if (!context.ModelState.IsValid)
            {
                var errorMessages = context.ModelState.Values
                    .SelectMany(m => m.Errors)
                    .Select(e =>
                    {
                        var msg = ErrorCode.Validation.GetErrorValue();
                        msg.MessageEN = e.ErrorMessage;
                        return msg;
                    }).ToList();

                context.HttpContext.Items["error"] = errorMessages;
            }
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var isAuthenticated = context.HttpContext.User.Identity?.IsAuthenticated ?? false;
            var actionName = context.GetActionName().ToLower();

            if (!isAuthenticated &&
                actionName != "login" &&
                actionName != "token" &&
                actionName != "health" &&
                actionName != "ping")
            {
                var errorMessages = new List<Message> { ErrorCode.AuthticationFailed.GetErrorValue() };
                context.HttpContext.Items["error"] = errorMessages;
                context.HttpContext.CheckError();
            }
        }
    }
}
