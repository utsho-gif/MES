using Newtonsoft.Json;
using MES.Core.Response;
using System.Collections.Generic;

namespace MES.Core.ErrorHandler
{
    public class ErrorModel
    {
        public bool IsSuccessful { get; set; } = false;
        public bool IsResult { get; set; } = false;
        public string Result { get; set; } = null;
        public List<Message> ErrorMessages { get; set; } = new List<Message>();

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
