using System.Collections.Generic;

namespace MES.Core.Response
{
    public class BaseResult
    {
        public bool IsSuccessful { get; set; } = false;
        public bool IsResult { get; set; } = false;
        public List<Message> ErrorMessages { get; set; }

        public BaseResult()
        {
            ErrorMessages = new List<Message>();
        }
    }
}
