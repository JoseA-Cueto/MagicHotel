using System.ComponentModel.DataAnnotations;

namespace MagicHotel.Modelos.DTO
{
    public class HotelDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength (30)]
        public string Name { get; set; }
        public string Detalle { get; set; }
        [Required]
        public double Tarifa { get; set; }

        public int Tourist { get; set; }
        public int SquareMeters { get; set; }
        public string ImagenUrl { get; set; }
        public string Amenidad { get; set; }
    }
}
