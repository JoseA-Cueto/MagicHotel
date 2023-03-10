using MagicHotel.Modelos;
using Microsoft.EntityFrameworkCore;

namespace MagicHotel.Datos
{
    public class AplicationDbContextcs : DbContext
    {
        public AplicationDbContextcs(DbContextOptions<AplicationDbContextcs> options) : base(options)
        {

        }
        public DbSet<Hotel> Hoteles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel()
                {
                    Id = 1,
                    Name = "Hotel Habana Libre...",
                    ImagenUrl = "",
                    Tourist = 5,
                    SquareMeters = 50,
                    Tarifa = 200,
                    Amenidad = "",
                    FechaInicio = DateTime.Now,
                    FechaUpdate = DateTime.Now,
                    Detalle = "",

                },
                      new Hotel()
                      {
                          Id = 2,
                          Name = "Hotel Nacional...",
                          ImagenUrl = "",
                          Tourist = 3,
                          SquareMeters = 60,
                          Tarifa = 250,
                          Amenidad = "",
                          FechaInicio = DateTime.Now,
                          FechaUpdate = DateTime.Now,
                          Detalle = "",

                      },
                             new Hotel()
                             {
                                 Id = 3,
                                 Name = "Hotel Copacavana...",
                                 ImagenUrl = "",
                                 Tourist = 10,
                                 SquareMeters = 70,
                                 Tarifa = 300,
                                 Amenidad = "",
                                 FechaInicio = DateTime.Now,
                                 FechaUpdate = DateTime.Now,
                                 Detalle = "",
                             }

                );
        }


    }
}
