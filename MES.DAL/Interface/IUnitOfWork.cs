using System;
using System.Threading.Tasks;

namespace MES.DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IUserInfoRepository UserInfo { get; }
        IRoleInfoRepository RoleInfo { get; }
        IFormInfoRepository FormInfo { get; }
        IRoleFormsRepository RoleForms { get; }
        ILogInfoRepository LogInfo { get; }

        int Complete();
        Task<int> CompleteAsync();
    }
}
