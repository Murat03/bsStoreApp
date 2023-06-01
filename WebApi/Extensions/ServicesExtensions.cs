﻿using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EfCore;
using Services.Concrete;
using Services.Contracts;
using System.Runtime.CompilerServices;

namespace WebApi.Extensions
{
    public static class ServicesExtensions
    {
        //herhangi bir parametre vermeyeceğiz sadece this sözcüğüyle
        //birlikte genişletmek istediğimiz ifadeyi vermemiz gerekiyor.
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
            //Register -> Resolve in BooksController
            services.AddDbContext<RepositoryContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureLoggerManager(this IServiceCollection services) =>
            services.AddSingleton<ILoggerService, LoggerManager>();
    }
}
