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
            CreateMap<Client, ClientDto>().ReverseMap();

            CreateMap<ClientForCreateDto, Client>();

            CreateMap<ClientForManipulationDto, Client>().ReverseMap();
            #endregion

        }
    }
}
