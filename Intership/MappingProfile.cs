using AutoMapper;
using Intership.Data.Entities;
using Intership.Data.Parameters;
using Intership.Models.RequestModels.Client;
using Intership.Models.RequestModels.Product;
using Intership.Models.RequestModels.Repair;
using Intership.Models.RequestModels.RepairInfo;
using Intership.Models.RequestModels.ReplacedPart;
using Intership.Models.RequestModels.Status;
using Intership.Models.ResponseModels;

namespace Intership
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Client
            CreateMap<Client, ClientResponseModel>()
                .ForMember(c => c.FullName,
                    opt => opt.MapFrom(x => string.Join(' ', x.Name, x.Surname)));

            CreateMap<AddClientModel, ClientParameter>();

            CreateMap<UpdateClientModel, ClientParameter>();

            #endregion

            #region Product
            CreateMap<Product, ProductResponseModel>();

            CreateMap<AddProductModel, ProductParameter>();

            CreateMap<UpdateProductModel, ProductParameter>();

            #endregion

            #region Repair
            CreateMap<Repair, RepairResponseModel>()
                .IncludeMembers(source => source.RepairInfo, source => source.RepairInfo.Status);

            CreateMap<RepairInfo, RepairResponseModel>()
                .ForMember(r => r.Date,
                    opt => opt.MapFrom(x => x.Date))
                .ForMember(r => r.AdvancedInfo,
                    opt => opt.MapFrom(x => x.AdvancedInfo));

            CreateMap<Status, RepairResponseModel>()
                .ForMember(r => r.StatusInfo,
                    opt => opt.MapFrom(x => x.StatusInfo));

            CreateMap<AddRepairModel, RepairParameter>();

            CreateMap<UpdateRepairModel, RepairParameter>();

            #endregion

            #region RepairInfo
            CreateMap<RepairInfo, RepairInfoResponseModel>()
                .IncludeMembers(source => source.Status);

            CreateMap<Status, RepairInfoResponseModel>()
                .ForMember(r => r.StatusInfo,
                    opt => opt.MapFrom(x => x.StatusInfo));

            CreateMap<AddRepairInfoModel, RepairInfoParameter>();

            CreateMap<UpdateRepairInfoModel, RepairInfoParameter>();

            #endregion

            #region Status
            CreateMap<Status, StatusResponseModel>();

            CreateMap<AddStatusModel, StatusParameter>();

            CreateMap<UpdateStatusModel, StatusParameter>();
            #endregion

            #region ReplacedPart
            CreateMap<ReplacedPart, ReplacedPartResponseModel>()
                .ForMember(r => r.TotalPrice,
                    opt => opt.MapFrom(x => x.Count * x.Price));

            CreateMap<AddReplacedPartModel, ReplacedPartParameter>();

            CreateMap<UpdateReplacedPartModel, ReplacedPartParameter>();
            #endregion
        }
    }
}
