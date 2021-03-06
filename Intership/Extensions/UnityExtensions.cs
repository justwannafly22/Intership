using Intership.Abstracts;
using Intership.Abstracts.Logic;
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
        }

        public static void ConfigureLoggerManager(this IUnityContainer container)
        {
            container.RegisterType<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureData(this IUnityContainer container)
        {
            container.RegisterType<IClientRepository, ClientRepository>();
        }

        public static void ConfigureLogic(this IUnityContainer container)
        {
            container.RegisterType<IClientLogic, ClientLogic>();
        }
    }
}
