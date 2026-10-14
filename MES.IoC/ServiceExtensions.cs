using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MES.Core;
using MES.Core.ActionFilters;
using MES.Core.ErrorHandler;
using MES.Core.Logger;
using MES.Core.Response;
using MES.Core.Setting;
using MES.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using static MES.Core.Enum;

namespace MES.IoC
{
    public static class ServiceExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerUtil factory)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    context.Response.ContentType = "application/json";

                    var errorMessage = context.GetError();
                    if (errorMessage == null || errorMessage.Count == 0)
                    {
                        errorMessage = new List<Message>
                        {
                            new Message
                            {
                                Code = "500",
                                MessageEN = "Internal Server Error.",
                                Status = "Failed"
                            }
                        };
                    }

                    await context.Response.WriteAsync(new ErrorModel
                    {
                        IsResult = false,
                        IsSuccessful = false,
                        ErrorMessages = errorMessage
                    }.ToString());
                });
            });
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .WithExposedHeaders("X-Pagination"));
            });
        }

        public static void ConfigureMSSqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:DefaultConnection"]
                                ?? config["mesdbconnection:connectionString"];
            services.AddDbContext<MESDbContext>(o => o.UseSqlServer(connectionString));
        }

        public static void ConfigureApplicationError(this IServiceCollection services, IConfiguration config)
        {
            var section = config.GetSection("ApplicationError");
            if (section.Exists())
            {
                Error.Values = section.GetChildren()
                    .Select(item => new KeyValuePair<int, Message>(
                        Convert.ToInt32(item.GetValue<string>("Code")),
                        new Message
                        {
                            Code = item.GetValue<string>("Code"),
                            MessageEN = item.GetValue<string>("MessageEN"),
                            HeadingTextEN = item.GetValue<string>("HeadingTextEN"),
                            Status = item.GetValue<string>("Status"),
                            Page = Convert.ToInt32(item.GetValue<string>("Page") ?? "1")
                        }))
                    .ToDictionary(x => x.Key, x => x.Value);
            }
        }

        public static void ConfigureApplicationMessage(this IServiceCollection services, IConfiguration config)
        {
            var section = config.GetSection("ApplicationMessage");
            if (section.Exists())
            {
                ApplicationMessage.Values = section.GetChildren()
                    .Select(item => new KeyValuePair<int, Message>(
                        Convert.ToInt32(item.GetValue<string>("Code")),
                        new Message
                        {
                            Code = item.GetValue<string>("Code"),
                            MessageEN = item.GetValue<string>("MessageEN"),
                            HeadingTextEN = item.GetValue<string>("HeadingTextEN"),
                            Status = item.GetValue<string>("Status"),
                            Page = Convert.ToInt32(item.GetValue<string>("Page") ?? "1")
                        }))
                    .ToDictionary(x => x.Key, x => x.Value);
            }
        }

        public static void ConfigureApplicationSettings(this IServiceCollection services, IConfiguration config)
        {
            config.GetSection("Settings").Get<ApplicationSettings>();
            services.AddScoped<RequestValidationFilter>();
            services.AddScoped<RequestModelFilter>();
        }

        public static void ConfigureEmailSettings(this IServiceCollection services, IConfiguration config)
        {
            var emailConfig = config.GetSection("EmailConfiguration").Get<EmailConfiguration>()
                           ?? new EmailConfiguration();
            services.AddSingleton(emailConfig);
        }

        public static void ConfigureAppSettings(this IServiceCollection services, IConfiguration config)
        {
            var appConfig = config.GetSection("AppConfiguration").Get<AppConfiguration>()
                         ?? new AppConfiguration();
            services.AddSingleton(appConfig);
        }
    }
}
