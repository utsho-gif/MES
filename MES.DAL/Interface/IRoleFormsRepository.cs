using MES.Models.Models;
using System.Collections.Generic;

namespace MES.DAL.Interface
{
    public interface IRoleFormsRepository : IRepositoryBase<ROLE_FORMS>
    {
        IEnumerable<ROLE_FORMS> GetAllRoleForms();
        IEnumerable<ROLE_FORMS> GetRoleFormsByRoleId(int roleId);
        void CreateRoleForms(ROLE_FORMS roleForms);
        void UpdateRoleForms(ROLE_FORMS roleForms, int id);
        void DeleteRoleForms(ROLE_FORMS roleForms);
    }
}
