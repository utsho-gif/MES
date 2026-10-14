using System.Collections.Generic;

namespace MES.Core.Response
{
    public class QueryResultSet<T> : BaseResult
    {
        public IEnumerable<T> Result { get; set; }

        public QueryResultSet()
        {
        }
    }
}
