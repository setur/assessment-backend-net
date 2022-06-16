using AutoMapper;
using Contact.API.DTOs;
using Contact.Data.Entities;

namespace Contact.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonDTO, Person>();
            CreateMap<InfoDTO, Info>();
        }
    }
}
