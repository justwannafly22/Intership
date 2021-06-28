using Intership.Filters;
using LoggerService;
using Microsoft.AspNetCore.Hosting;
using Unity;
using Intership.Data.Abstracts;
using Intership.Data.Repositories;
using Intership.Services;
using Intership.Services.Abstracts;
using Intership.LoggerService.Abstracts;

namespace Intership.Extensions
{
    public static class UnityExtensions
    {
        public static void ConfirureFilters(this IUnityContainer container)
        {
            container.RegisterType<IStartupFilter, DatabaseInitFilter>();
            container.RegisterType<ValidationFilterAttribute>();
        }

        public static void ConfigureLoggerManager(this IUnityContainer container)
        {
            container.RegisterType<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureData(this IUnityContainer container)
        {
            container.RegisterType<IClientRepository, ClientRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IRepairRepository, RepairRepository>();
            container.RegisterType<IRepairInfoRepository, RepairInfoRepository>();
        }

        public static void ConfigureLogic(this IUnityContainer container)
        {
            container.RegisterType<IClientService, ClientService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IRepairService, RepairService>();
            container.RegisterType<IRepairInfoService, RepairInfoService>();
        }
    }
}
