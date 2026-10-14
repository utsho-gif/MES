using MES.DAL.Interface;
using MES.Models.Context;
using MES.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace MES.DAL.Class
{
    public class RoleInfoRepository : RepositoryBase<ROLE_INFO>, IRoleInfoRepository
    {
        public RoleInfoRepository(MESDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateRoleInfo(ROLE_INFO roleInfo)
        {
            Create(roleInfo);
        }

        public void DeleteRoleInfo(ROLE_INFO roleInfo)
        {
            Delete(roleInfo);
        }

        public IEnumerable<ROLE_INFO> GetAllRoleInfos()
        {
            return FindAll().Where(x => x.IS_DELETE != 1).OrderBy(x => x.ID);
        }

        public ROLE_INFO GetRoleInfoById(int id)
        {
            return FindByID(id);
        }

        public void UpdateRoleInfo(ROLE_INFO roleInfo, int id)
        {
            Update(roleInfo);
        }
    }
}
