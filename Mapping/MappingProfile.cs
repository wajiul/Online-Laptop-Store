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
            CreateMap<DisplayDto, Display>();
            CreateMap<DriveDto, Drive>();
            CreateMap<GraphicsCardDto, GraphicsCard>();
            CreateMap<Processor, LaptopShortDescription>()
                .ForMember(dest => dest.ProcessorInfo, opt =>
                opt.MapFrom(src => $"{src.Brand} {src.Model} ({src.FrequencyGHz} GHz, {src.Cache}M Cache, {src.Core} Cores, {src.Thread} Threads)"));
        }

    }
}
