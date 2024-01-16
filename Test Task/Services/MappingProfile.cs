using AutoMapper;
using Test_Task.Models;

namespace Test_Task.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonDto, Person>();
        }
    }
}
