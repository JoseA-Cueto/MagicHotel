using MagicHotel.Modelos.DTO;

namespace MagicHotel.Datos
{
    public static class HotelStore
    {
        public static List<HotelDto> hotelList = new List<HotelDto>
        {
              new HotelDto {Id = 1, Name = "Habana Libre",Tourist =300,SquareMeters=80 },
              new HotelDto {Id = 2,Name = "Hotel Nacional" , Tourist =250,SquareMeters=50 },
                 new HotelDto {Id = 3, Name = "Copacavana",Tourist =1000,SquareMeters=100}
        };
    }
}
