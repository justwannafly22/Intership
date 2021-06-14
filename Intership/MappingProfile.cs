using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Intership.DTO.Client;
using Intership.DTO.Product;
using Intership.DTO.Repair;
using Intership.Models.Entities;

namespace Intership
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Client
            CreateMap<Client, ClientDto>()
                .ForMember(c => c.FullName,
                    opt => opt.MapFrom(x => string.Join(' ', x.Name, x.Surname)));
            
            CreateMap<ClientForCreateDto, Client>();

            CreateMap<ClientForUpdateDto, Client>().ReverseMap();
            #endregion

            #region Product
            CreateMap<Product, ProductDto>();

            CreateMap<ProductForCreateDto, Product>();

            CreateMap<ProductForUpdateDto, Product>().ReverseMap();
            #endregion

            #region Repair
            CreateMap<Repair, RepairDto>()
                .IncludeMembers(source => source.RepairInfo, source => source.RepairInfo.Status);

            CreateMap<RepairInfo, RepairDto>()
                .ForMember(r => r.Date,
                    opt => opt.MapFrom(x => x.Date))
                .ForMember(r => r.AdvancedInfo,
                    opt => opt.MapFrom(x => x.AdvancedInfo));

            CreateMap<Status, RepairDto>()
                .ForMember(r => r.StatusInfo,
                    opt => opt.MapFrom(x => x.StatusInfo));

            #endregion
        }
    }
}
