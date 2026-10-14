using Microsoft.AspNetCore.Http;
using MES.Core.Logger;
using static MES.Core.Enum;

namespace MES.Core.ErrorHandler
{
    public class ErrorUtil : IErrorUtil
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ErrorUtil(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void AddError(ErrorCode errorCode)
        {
            var errorList = _httpContextAccessor.HttpContext.GetError();
            errorList.Add(errorCode.GetErrorValue());
            _httpContextAccessor.HttpContext.SetError(errorList);
        }

        public void AddError(ErrorCode errorCode, LogModel log, ILoggerUtil factory, string externalMsg = null, string externalStatus = null)
        {
            _httpContextAccessor.HttpContext.AddError(errorCode, log, factory, externalMsg, externalStatus);
        }
    }
}
