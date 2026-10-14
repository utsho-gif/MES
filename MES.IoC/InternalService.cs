using Microsoft.Extensions.DependencyInjection;
using MES.Core.ErrorHandler;
using MES.Core.Logger;
using MES.Core.Services;
using MES.DAL.Class;
using MES.DAL.Interface;

namespace MES.IoC
{
    public static class InternalService
    {
        public static void ConfigureInternalService(this IServiceCollection services)
        {
            // Core
            services.AddScoped<ILoggerUtil, LoggerUtil>();
            services.AddScoped<IErrorUtil, ErrorUtil>();
            services.AddScoped<IWebHttpClient, WebHttpClient>();
            services.AddScoped<IJWTService, JWTService>();

            // DAL
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserInfoRepository, UserInfoRepository>();
            services.AddScoped<IRoleInfoRepository, RoleInfoRepository>();
            services.AddScoped<IFormInfoRepository, FormInfoRepository>();
            services.AddScoped<IRoleFormsRepository, RoleFormsRepository>();
            services.AddScoped<ILogInfoRepository, LogInfoRepository>();
        }
    }
}
