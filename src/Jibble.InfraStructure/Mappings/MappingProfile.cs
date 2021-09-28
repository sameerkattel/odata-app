using AutoMapper;
using Jibble.Domain.Entities;
using Person = Microsoft.OData.SampleService.Models.TripPin.Person;
using Trip = Microsoft.OData.SampleService.Models.TripPin.Trip;

namespace Jibble.InfraStructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, Domain.Entities.Person>().ReverseMap();
            CreateMap<Person, PersonDetails>();
            CreateMap<Trip, Domain.Entities.Trip>().ReverseMap();
        }
    }
}