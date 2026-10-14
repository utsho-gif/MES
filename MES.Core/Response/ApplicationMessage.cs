using System.Collections.Generic;

namespace MES.Core.Response
{
    public class ApplicationMessage
    {
        public static Dictionary<int, Message> Values { get; set; } = new Dictionary<int, Message>();
    }
}
