using Intership.Filters;
using Microsoft.AspNetCore.Hosting;
using Unity;
using Intership.Data.Abstracts;
using Intership.Data.Repositories;
using Intership.Services;
using Intership.Services.Abstracts;

namespace Intership.Extensions
{
    public static class UnityExtensions
    {
        public static void ConfirureFilters(this IUnityContainer container)
        {
            container.RegisterType<IStartupFilter, DatabaseInitFilter>();
        }

        public static void ConfigureData(this IUnityContainer container)
        {
            container.RegisterType<IClientRepository, ClientRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IRepairRepository, RepairRepository>();
            container.RegisterType<IRepairInfoRepository, RepairInfoRepository>();
            container.RegisterType<IStatusRepository, StatusRepository>();
            container.RegisterType<IReplacedPartRepository, ReplacedPartRepository>();
        }

        public static void ConfigureLogic(this IUnityContainer container)
        {
            container.RegisterType<IClientService, ClientService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IRepairService, RepairService>();
            container.RegisterType<IStatusService, StatusService>();
            container.RegisterType<IReplacedPartService, ReplacedPartService>();
        }
    }
}
