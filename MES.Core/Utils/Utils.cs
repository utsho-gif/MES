using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using MES.Core.Logger;
using MES.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static MES.Core.Enum;

namespace MES.Core
{
    public static class Utils
    {
        public static string JsonObj<T>(this T data) => JsonConvert.SerializeObject(data);

        public static List<Message> GetError(this HttpContext httpContext) => httpContext.Items["error"] as List<Message> ?? new List<Message>();

        public static void SetError(this HttpContext httpContext, ErrorCode error)
        {
            var errorMessages = httpContext.GetError();
            errorMessages.Add(error.GetErrorValue());
            httpContext.Items["error"] = errorMessages;
        }

        public static void SetError(this HttpContext httpContext, ErrorCode error, LogModel log, ILoggerUtil factory, string externalMsg = null, string externalStatus = null)
        {
            var errorMessages = httpContext.GetError();
            var msg = error.GetErrorValue();
            if (!string.IsNullOrEmpty(externalMsg))
            {
                msg.ExternalMsg = externalMsg;
            }
            if (!string.IsNullOrEmpty(externalStatus))
            {
                msg.ExternalStatus = externalStatus;
            }
            errorMessages.Insert(0, msg);
            httpContext.Items["error"] = errorMessages;

            if (log != null && factory != null)
            {
                log.Message = httpContext.GetError().JsonObj();
                log.Status = "FAIL";
                factory.WriteLog(log, LogEnum.Error);
            }
            httpContext.CheckError();
        }

        public static void AddError(this HttpContext httpContext, ErrorCode error, LogModel log, ILoggerUtil factory, string externalMsg = null, string externalStatus = null)
        {
            var errorMessages = httpContext.GetError();
            var msg = error.GetErrorValue();
            if (!string.IsNullOrEmpty(externalMsg))
            {
                msg.ExternalMsg = externalMsg;
            }
            if (!string.IsNullOrEmpty(externalStatus))
            {
                msg.ExternalStatus = externalStatus;
            }
            errorMessages.Insert(0, msg);
            httpContext.Items["error"] = errorMessages;

            if (log != null && factory != null)
            {
                log.Message = httpContext.GetError().JsonObj();
                log.Status = "FAIL";
                factory.WriteLog(log, LogEnum.Error);
            }
        }

        public static void SetError(this HttpContext httpContext, List<Message> errorMessages)
        {
            httpContext.Items["error"] = errorMessages;
        }

        public static void XPagination<T>(this HttpResponse response, T data)
        {
            response.Headers.Append("X-Pagination", data.JsonObj());
        }

        public static void CheckError(this HttpContext httpContext)
        {
            var errors = httpContext.GetError();
            if (errors?.Count > 0)
            {
                throw new Exception("Error in HttpContext: " + errors.JsonObj());
            }
        }

        public static Message GetErrorValue(this ErrorCode error)
        {
            if (Error.Values != null && Error.Values.TryGetValue((int)error, out var msg))
            {
                return msg;
            }

            return new Message
            {
                Code = ((int)error).ToString(),
                MessageEN = error.ToString(),
                Status = "Failed"
            };
        }

        public static LogModel GetLog(this HttpContext httpContext) => httpContext.Items["log"] as LogModel;

        public static LogModel GetLog(this HttpContext httpContext, ILoggerUtil factory)
        {
            var log = httpContext.Items["log"] as LogModel ?? new LogModel();
            factory?.WriteLog(log, LogEnum.Information);
            httpContext.CheckError();
            return log;
        }

        public static string GetIP(this HttpContext httpContext)
        {
            if (httpContext.Request.Headers.TryGetValue("X-Forwarded-For", out var forwarded))
            {
                return forwarded.ToString();
            }

            return httpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString() ?? "127.0.0.1";
        }

        public static LogModel GenerateLog(this ActionExecutingContext context)
        {
            var userName = context.HttpContext.User.Identity?.Name ?? "Anonymous";
            var controller = context.ActionDescriptor as ControllerActionDescriptor;
            var param = context.ActionArguments.FirstOrDefault().Value;

            return new LogModel
            {
                Ip = context.HttpContext.GetIP(),
                ServiceName = controller?.ControllerName,
                MethodName = controller?.ActionName,
                RequestBody = param?.JsonObj(),
                UserInfo = userName
            };
        }

        public static LogModel GenerateLog(this AuthorizationFilterContext context)
        {
            return new LogModel
            {
                Ip = context.HttpContext.GetIP(),
                ServiceName = "Authorization",
                MethodName = "OnAuthorization",
                RequestBody = context.Result?.JsonObj(),
                UserInfo = context.HttpContext.Request.Headers.Authorization.ToString()
            };
        }

        public static string GetActionName(this ActionExecutingContext context)
        {
            var controller = context.ActionDescriptor as ControllerActionDescriptor;
            return controller?.ActionName ?? "";
        }

        public static string GetActionName(this AuthorizationFilterContext context)
        {
            var controller = context.ActionDescriptor as ControllerActionDescriptor;
            return controller?.ActionName ?? "";
        }

        public static DateTime FromUnixTime(this long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime).ToLocalTime();
        }

        public static string ToUnixTime(this DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date.ToUniversalTime() - epoch).TotalSeconds).ToString();
        }
    }
}
