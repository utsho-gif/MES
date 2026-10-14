using MES.Models.Models;
using System.Collections.Generic;

namespace MES.DAL.Interface
{
    public interface IRoleInfoRepository : IRepositoryBase<ROLE_INFO>
    {
        IEnumerable<ROLE_INFO> GetAllRoleInfos();
        ROLE_INFO GetRoleInfoById(int id);
        void CreateRoleInfo(ROLE_INFO roleInfo);
        void UpdateRoleInfo(ROLE_INFO roleInfo, int id);
        void DeleteRoleInfo(ROLE_INFO roleInfo);
    }
}
