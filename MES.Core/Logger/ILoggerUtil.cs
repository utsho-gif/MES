using System;
using static MES.Core.Enum;

namespace MES.Core.Logger
{
    public interface ILoggerUtil
    {
        LogModel GetLog(string serviceName = null, string methodName = null, string requestBody = null, string responseModel = null);
        void WriteLog(string log, LogEnum logNum, Exception exception = null);
        void WriteLog(LogModel logsModel, LogEnum logNum, Exception exception = null);
        void WriteSuccessLog(LogModel logsModel, LogEnum logNum, string methodName = null, string serviceName = null, Exception exception = null);
        void WriteErrorLog(LogModel logsModel, LogEnum logNum, string methodName = null, string serviceName = null, Exception exception = null);
    }
}
