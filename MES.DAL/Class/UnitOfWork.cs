using MES.DAL.Interface;
using MES.Models.Context;
using System.Threading.Tasks;

namespace MES.DAL.Class
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MESDbContext _repositoryContext;

        public UnitOfWork(MESDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        private IUserInfoRepository _userInfo;
        public IUserInfoRepository UserInfo => _userInfo ??= new UserInfoRepository(_repositoryContext);

        private IRoleInfoRepository _roleInfo;
        public IRoleInfoRepository RoleInfo => _roleInfo ??= new RoleInfoRepository(_repositoryContext);

        private IFormInfoRepository _formInfo;
        public IFormInfoRepository FormInfo => _formInfo ??= new FormInfoRepository(_repositoryContext);

        private IRoleFormsRepository _roleForms;
        public IRoleFormsRepository RoleForms => _roleForms ??= new RoleFormsRepository(_repositoryContext);

        private ILogInfoRepository _logInfo;
        public ILogInfoRepository LogInfo => _logInfo ??= new LogInfoRepository(_repositoryContext);

        public int Complete()
        {
            return _repositoryContext.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _repositoryContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _repositoryContext.Dispose();
        }
    }
}
