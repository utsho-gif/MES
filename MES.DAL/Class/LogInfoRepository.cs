using MES.DAL.Interface;
using MES.Models.Context;
using MES.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace MES.DAL.Class
{
    public class LogInfoRepository : RepositoryBase<LOG_INFO>, ILogInfoRepository
    {
        public LogInfoRepository(MESDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateLog(LOG_INFO log)
        {
            Create(log);
        }

        public IEnumerable<LOG_INFO> GetAllLogs()
        {
            return FindAll().OrderByDescending(x => x.CREATED_DATE);
        }
    }
}
