using MagicHotel.Datos;
using MagicHotel.Modelos;
using MagicHotel.Modelos.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class HotelController : ControllerBase
    {
        private readonly ILogger<HotelController> _logger;
        private readonly AplicationDbContextcs _db;


        public HotelController(ILogger<HotelController>logguer,AplicationDbContextcs db)
        {
            _logger = logguer;
            _db = db;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<HotelDto>> GetHoteles()
        {
            _logger.LogInformation("Obtuvo lista de hoteles");
            return Ok(_db.Hoteles.ToList());
        }
        [HttpGet("id:int", Name = "GetHotel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<HotelDto> GetHotel(int id)
        {
            if (id == 0)
            {
                _logger.LogError("No existe el Hotel con el Id " + id );
                return BadRequest();
            }
            var hotel = _db.Hoteles.FirstOrDefault(h => h.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<HotelDto> CrearHotel([FromBody] HotelDto hotelDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_db.Hoteles.FirstOrDefault(h => h.Name.ToLower() == hotelDto.Name.ToLower()) != null)
            {
                ModelState.AddModelError("NombreExiste", "Un Hotel con ese nombre ya existe");
                return BadRequest(ModelState);
            }
            if (hotelDto == null)
            {
                return BadRequest(hotelDto);
            }
            if (hotelDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Hotel modelo = new()
            {
                Id = hotelDto.Id,
                Name = hotelDto.Name,
                Detalle = hotelDto.Detalle,
                ImagenUrl = hotelDto.ImagenUrl,
                Tourist = hotelDto.Tourist,
                Amenidad = hotelDto.Amenidad,
                SquareMeters = hotelDto.SquareMeters,
                Tarifa = hotelDto.Tarifa, 
            };
            _db.Hoteles.Add(modelo);
            _db.SaveChanges(); 

            return CreatedAtRoute("GetHotel", new { id = hotelDto.Id }, hotelDto);
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteHotel(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var hotel = _db.Hoteles.FirstOrDefault(h => h.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }
            _db.Hoteles.Remove(hotel);
            _db.SaveChanges();

            return NoContent();
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
       
        public IActionResult UpdateHotel(int id, [FromBody] HotelDto hotelDto)
        {
            if (hotelDto == null || id != hotelDto.Id)
            {
                return BadRequest();
            }
            Hotel modelo = new()
            {
               Id = hotelDto.Id,
                Name = hotelDto.Name,
                Detalle = hotelDto.Detalle,
                ImagenUrl = hotelDto.ImagenUrl,
                Tourist = hotelDto.Tourist,
                Amenidad = hotelDto.Amenidad,
                SquareMeters = hotelDto.SquareMeters,
                Tarifa = hotelDto.Tarifa, 


            };
            _db.Hoteles.Update(modelo); 
            _db.SaveChanges();

            return NoContent();
        }
   

    }
}
