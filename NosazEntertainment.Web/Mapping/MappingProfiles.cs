using AutoMapper;
using NosazEntertainment.Dto;
using NosazEntertainment.Model;

namespace NosazEntertainment.Web.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
