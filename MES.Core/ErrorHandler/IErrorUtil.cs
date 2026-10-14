using MES.Core.Logger;
using static MES.Core.Enum;

namespace MES.Core.ErrorHandler
{
    public interface IErrorUtil
    {
        void AddError(ErrorCode errorCode);
        void AddError(ErrorCode errorCode, LogModel log, ILoggerUtil factory, string externalMsg = null, string externalStatus = null);
    }
}
