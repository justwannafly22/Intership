using Intership.Abstracts;
using Intership.Abstracts.Services;
using Intership.Abstracts.Repositories;
using Intership.Data;
using Intership.Filters;
using Intership.Logic;
using LoggerService;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity;

namespace Intership.Extensions
{
    public static class UnityExtensions
    {
        public static void ConfirureFilters(this IUnityContainer container)
        {
            container.RegisterType<IStartupFilter, DatabaseInitFilter>();
            container.RegisterType<ValidationFilterAttribute>();
            container.RegisterType<ValidateClientExistAttribute>();
            container.RegisterType<ValidateProductExistAttribute>();
        }

        public static void ConfigureLoggerManager(this IUnityContainer container)
        {
            container.RegisterType<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureData(this IUnityContainer container)
        {
            container.RegisterType<IClientRepository, ClientRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();
        }

        public static void ConfigureLogic(this IUnityContainer container)
        {
            container.RegisterType<IClientService, ClientService>();
            container.RegisterType<IProductService, ProductService>();
        }
    }
}
