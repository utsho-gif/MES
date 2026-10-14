using MES.DAL.Interface;
using MES.Models.Context;
using MES.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace MES.DAL.Class
{
    public class UserInfoRepository : RepositoryBase<USER_INFO>, IUserInfoRepository
    {
        public UserInfoRepository(MESDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateUserInfo(USER_INFO userInfo)
        {
            Create(userInfo);
        }

        public void DeleteUserInfo(USER_INFO userInfo)
        {
            Delete(userInfo);
        }

        public IEnumerable<USER_INFO> GetAllUserInfos()
        {
            return FindAll().Where(x => x.IS_DELETE != 1).OrderBy(x => x.ID);
        }

        public USER_INFO GetUserInfoById(int id)
        {
            return FindByID(id);
        }

        public USER_INFO GetUserInfoByRoleId(int roleId)
        {
            return FindByCondition(x => x.ROLE_ID == roleId && x.IS_DELETE != 1).FirstOrDefault();
        }

        public void UpdateUserInfo(USER_INFO userInfo, int id)
        {
            Update(userInfo);
        }
    }
}
