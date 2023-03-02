using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicHotel.Modelos
{
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detalle { get; set; }
        [Required]
        public double Tarifa { get; set; }
        public int Tourist { get; set; }
        public int SquareMeters { get; set; }
        public string ImagenUrl { get; set; }
        public string Amenidad { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaUpdate { get; set; }

    }
}
