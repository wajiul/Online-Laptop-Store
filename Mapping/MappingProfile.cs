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
            CreateMap<LaptopDto, Laptop>();
            CreateMap<Laptop, LaptopShortDescription>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt =>
                    opt.MapFrom(src => $"{src.Brand} {src.Model} {src.Processor.Model} {src.Display.Size} {src.Display.Type} Laptop"))
                .ForMember(dest => dest.Ram, opt =>
                    opt.MapFrom(src => $"{src.Ram.Capacity}GB {src.Ram.Type} {src.Ram.FrequencyMHz} MHz"))
                .ForMember(dest => dest.Storage, opt =>
                    opt.MapFrom(src => $"{src.Drive.Capacity} {src.Drive.Type}"))
                .ForMember(dest => dest.Display, opt =>
                    opt.MapFrom(src => $"{src.Display.Size} {src.Display.Type} {src.Display.Resolution}"))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

        }

    }
}
