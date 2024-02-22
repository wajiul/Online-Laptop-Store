using AutoMapper;
using LaptopStoreAPI.Controllers.DTOs;
using LaptopStoreAPI.Persistence.Models;

namespace LaptopStoreAPI.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ProcessorDto, Processor>();
            CreateMap<RamDto, Ram>();
        }
    }
}
