namespace MES.Core.Response
{
    public class QueryResult<T> : BaseResult
    {
        public T Result { get; set; }

        public QueryResult()
        {
        }
    }
}
