using static MES.Core.Enum;

namespace MES.Core.Response
{
    public class Message
    {
        public Message()
        {
            Page = (int)PageCode.Sucess;
        }

        public string Code { get; set; }
        public string MessageEN { get; set; }
        public string HeadingTextEN { get; set; }
        public string Status { get; set; }
        public string ExternalMsg { get; set; }
        public string ExternalStatus { get; set; }
        public int Page { get; set; }
    }
}
