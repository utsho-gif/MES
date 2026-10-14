using MES.DAL.Interface;
using MES.Models.Context;
using MES.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace MES.DAL.Class
{
    public class RoleFormsRepository : RepositoryBase<ROLE_FORMS>, IRoleFormsRepository
    {
        public RoleFormsRepository(MESDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateRoleForms(ROLE_FORMS roleForms)
        {
            Create(roleForms);
        }

        public void DeleteRoleForms(ROLE_FORMS roleForms)
        {
            Delete(roleForms);
        }

        public IEnumerable<ROLE_FORMS> GetAllRoleForms()
        {
            return FindAll().Where(x => x.IS_DELETE != 1).OrderBy(x => x.ID);
        }

        public IEnumerable<ROLE_FORMS> GetRoleFormsByRoleId(int roleId)
        {
            return FindByCondition(x => x.ROLE_ID == roleId && x.IS_DELETE != 1).ToList();
        }

        public void UpdateRoleForms(ROLE_FORMS roleForms, int id)
        {
            Update(roleForms);
        }
    }
}
