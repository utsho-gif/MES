using System.Collections.Generic;

namespace MES.Core.Response
{
    public class Error
    {
        public static Dictionary<int, Message> Values { get; set; } = new Dictionary<int, Message>();
    }
}
