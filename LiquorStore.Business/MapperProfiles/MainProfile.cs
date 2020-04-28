using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using AutoMapper;
using LiquorStore.Business.Dtos;
using LiquorStore.DAL.Entities;
using LiquorStore.DAL.Entities.DatabaseEntities;
using LiquorStore.DAL.Entities.ParameterEntities;
using LiquorStore.DAL.Entities.ReadEntities;

namespace LiquorStore.Business.MapperProfiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            MappingProfile();
        }

        private void MappingProfile()
        {
            CreateMap<LiquorOutput, LiquorOutputDto>();
            CreateMap<PaginatedInputDto, PaginatedDataInput>();
            CreateMap<PaginatedOutput<LiquorOutput>, PaginatedOutputDto<LiquorOutputDto>>();
            CreateMap<PaginatedInformationOutput, PaginatedInformationOutputDto>();
        }
    }
}
