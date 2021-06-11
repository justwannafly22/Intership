using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Intership.DTO.Client;
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

        }
    }
}
