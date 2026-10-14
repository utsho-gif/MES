using MES.Models.Models;
using System.Collections.Generic;

namespace MES.DAL.Interface
{
    public interface ILogInfoRepository : IRepositoryBase<LOG_INFO>
    {
        IEnumerable<LOG_INFO> GetAllLogs();
        void CreateLog(LOG_INFO log);
    }
}
