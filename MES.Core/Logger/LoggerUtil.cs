using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Reflection;
using System.Xml;
using static MES.Core.Enum;

namespace MES.Core.Logger
{
    public class LoggerUtil : ILoggerUtil
    {
        private readonly ILoggerFactory _factory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static readonly ILog log = LogManager.GetLogger(typeof(LoggerUtil));

        public LoggerUtil(ILoggerFactory factory, IHttpContextAccessor httpContextAccessor)
        {
            _factory = factory;
            _httpContextAccessor = httpContextAccessor;

            try
            {
                if (File.Exists("log4net.config"))
                {
                    XmlDocument log4netConfig = new XmlDocument();
                    log4netConfig.Load(File.OpenRead("log4net.config"));

                    var repo = LogManager.CreateRepository(
                        Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

                    log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
                }
            }
            catch
            {
                // Fallback to default logger if log4net.config is missing during test
            }
        }

        public void WriteLog(LogModel logsModel, LogEnum logNum, Exception exception = null)
        {
            if (logsModel == null) return;
            var logs = $"ServiceName: {logsModel.ServiceName} @@ MethodName: {logsModel.MethodName} @@ Status: {logsModel.Status} @@ Ip: {logsModel.Ip} @@ RequestGuid: {logsModel.RequestGuid} @@ UserInfo: {logsModel.UserInfo} @@ RequestBody: {logsModel.RequestBody} @@ ResponseModel: {logsModel.ResponseModel} @@ Message: {logsModel.Message} @@";
            WriteLog(logs, logNum, exception);
            logsModel.RequestBody = "";
            logsModel.ResponseModel = "";
        }

        public LogModel GetLog(string serviceName = null, string methodName = null, string requestBody = null, string responseModel = null)
        {
            var logs = _httpContextAccessor?.HttpContext?.GetLog() ?? new LogModel();
            logs.ServiceName = serviceName ?? logs.ServiceName;
            logs.MethodName = methodName ?? logs.MethodName;
            logs.RequestBody = requestBody ?? logs.RequestBody;
            logs.ResponseModel = responseModel ?? logs.ResponseModel;
            return logs;
        }

        public void WriteSuccessLog(LogModel logsModel, LogEnum logNum, string methodName = null, string serviceName = null, Exception exception = null)
        {
            if (logsModel == null) return;
            var logs = $"ServiceName: {serviceName ?? logsModel.ServiceName} @@ MethodName: {methodName ?? logsModel.MethodName} @@ Status: Success @@ Ip: {logsModel.Ip} @@ RequestGuid: {logsModel.RequestGuid} @@ UserInfo: {logsModel.UserInfo} @@ RequestBody: {logsModel.RequestBody} @@ ResponseModel: {logsModel.ResponseModel} @@ Message: {logsModel.Message} @@";
            WriteLog(logs, logNum, exception);
            logsModel.RequestBody = "";
            logsModel.ResponseModel = "";
        }

        public void WriteErrorLog(LogModel logsModel, LogEnum logNum, string methodName = null, string serviceName = null, Exception exception = null)
        {
            if (logsModel == null) return;
            var logs = $"ServiceName: {serviceName ?? logsModel.ServiceName} @@ MethodName: {methodName ?? logsModel.MethodName} @@ Status: Error @@ Ip: {logsModel.Ip} @@ RequestGuid: {logsModel.RequestGuid} @@ UserInfo: {logsModel.UserInfo} @@ RequestBody: {logsModel.RequestBody} @@ ResponseModel: {logsModel.ResponseModel} @@ Message: {logsModel.Message} @@";
            WriteLog(logs, logNum, exception);
            logsModel.RequestBody = "";
            logsModel.ResponseModel = "";
        }

        public void WriteLog(string logs, LogEnum logNum, Exception exception = null)
        {
            var logger = LogManager.GetLogger(typeof(LoggerUtil));
            var loggerFromDi = _factory?.CreateLogger("MES");

            switch (logNum)
            {
                case LogEnum.Information:
                    logger.Info(logs);
                    loggerFromDi?.LogInformation(logs);
                    break;
                case LogEnum.Debug:
                    logger.Debug(logs);
                    loggerFromDi?.LogDebug(logs);
                    break;
                case LogEnum.Error:
                    logger.Error(logs, exception);
                    loggerFromDi?.LogError(exception, logs);
                    break;
            }
        }
    }
}
