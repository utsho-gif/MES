using MES.Models.Models;
using System.Collections.Generic;

namespace MES.DAL.Interface
{
    public interface IUserInfoRepository : IRepositoryBase<USER_INFO>
    {
        IEnumerable<USER_INFO> GetAllUserInfos();
        USER_INFO GetUserInfoById(int id);
        USER_INFO GetUserInfoByRoleId(int roleId);
        void CreateUserInfo(USER_INFO userInfo);
        void UpdateUserInfo(USER_INFO userInfo, int id);
        void DeleteUserInfo(USER_INFO userInfo);
    }
}
