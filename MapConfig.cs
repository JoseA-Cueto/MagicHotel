using AutoMapper;
using MagicHotel.Modelos;
using MagicHotel.Modelos.DTO;

namespace MagicHotel
{
    public class MapConfig : Profile 
    {
        public MapConfig()
        {
            CreateMap<Hotel, HotelDto>();
            CreateMap<HotelDto, Hotel>();
            CreateMap<Hotel,HotelCreatedDto>().ReverseMap();
            CreateMap<Hotel, HotelUpdateDto>().ReverseMap();
        }
    }
}
