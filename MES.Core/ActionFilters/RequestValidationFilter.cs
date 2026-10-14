using Microsoft.AspNetCore.Mvc.Filters;
using MES.Core.Logger;
using MES.Core.Response;
using System.Collections.Generic;
using static MES.Core.Enum;

namespace MES.Core.ActionFilters
{
    public class RequestValidationFilter : IActionFilter, IAuthorizationFilter
    {
        private readonly ILoggerUtil _factory;

        public RequestValidationFilter(ILoggerUtil factory)
        {
            _factory = factory;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var log = context.GenerateLog();
            context.HttpContext.Items["log"] = log;

            if (!context.ModelState.IsValid)
            {
                var errorMessages = new List<Message>();
                foreach (var state in context.ModelState.Values)
                {
                    foreach (var error in state.Errors)
                    {
                        var msg = ErrorCode.Validation.GetErrorValue();
                        msg.MessageEN = error.ErrorMessage;
                        errorMessages.Add(msg);
                    }
                }
                context.HttpContext.Items["error"] = errorMessages;
            }
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var isAuthenticated = context.HttpContext.User.Identity?.IsAuthenticated ?? false;
            var actionName = context.GetActionName().ToLower();

            // Allow anonymous access for login/auth endpoints
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
