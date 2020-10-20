using AutoMapper;
using BSWTranslationTools.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementAPI.Mappings
{
    /// <summary>
    /// Mapping Entities
    /// </summary>
    public class Maps : Profile
    {
        /// <summary>
        /// Constructor for mapping
        /// </summary>
        public Maps()
        {
            CreateMap<JsonDetails, JsonDetailsDTO>().ReverseMap();
            CreateMap<JsonDetails, JsonDetailsNewDTO>().ReverseMap();
            CreateMap<JsonDetails, JsonDetailsCreatedDTO>().ReverseMap();
            CreateMap<JsonDetails, JsonDetailsUpdatedDTO>().ReverseMap();
            CreateMap<JsonDetailsKey, JsonDetailsKeyDTO>().ReverseMap();
            CreateMap<JsonDetailsKey, JsonDetailsKeyCreateDTO>().ReverseMap();
            CreateMap<JsonDetailsKey, JsonDetailsKeyUpdateDTO>().ReverseMap();

        }
    }
}
