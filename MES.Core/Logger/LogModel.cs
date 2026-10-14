namespace MES.Core.Logger
{
    public class LogModel
    {
        public string RequestBody { get; set; }
        public string ServiceName { get; set; }
        public string MethodName { get; set; }
        public string ResponseModel { get; set; }
        public string RequestGuid { get; set; }
        public string Message { get; set; }
        public string Ip { get; set; }
        public string UserInfo { get; set; }
        public string Status { get; set; }
    }
}
