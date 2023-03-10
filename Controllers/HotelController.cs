using AutoMapper;
using MagicHotel.Datos;
using MagicHotel.Modelos;
using MagicHotel.Modelos.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class HotelController : ControllerBase
    {
        private readonly ILogger<HotelController> _logger;
        private readonly AplicationDbContextcs _db;
        private readonly IMapper _automapper;


        public HotelController(ILogger<HotelController> logguer, AplicationDbContextcs db , IMapper mapper )
        {
            _logger = logguer;
            _db = db;
            _automapper = mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task< ActionResult<IEnumerable<HotelDto>>>GetHoteles()
        {
            _logger.LogInformation("Obtuvo lista de hoteles");
            IEnumerable<Hotel> HotelList = await _db.Hoteles.ToListAsync();
            return Ok(_automapper.Map<IEnumerable<HotelDto>>(HotelList));
        }
        [HttpGet("id:int", Name = "GetHotel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task< ActionResult<HotelDto>> GetHotel(int id)
        {
            if (id == 0)
            {
                _logger.LogError("No existe el Hotel con el Id " + id);
                return BadRequest();
            }
            var hotel =await _db.Hoteles.FirstOrDefaultAsync(h => h.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(_automapper.Map<HotelDto>(hotel));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task <ActionResult<HotelDto>> CrearHotel([FromBody]HotelCreatedDto hotelDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (  await _db.Hoteles.FirstOrDefaultAsync(h => h.Name.ToLower() == hotelDto.Name.ToLower()) != null)
            {
                ModelState.AddModelError("NombreExiste", "Un Hotel con ese nombre ya existe");
                return BadRequest(ModelState);
            }
            if (hotelDto == null)
            {
                return BadRequest(hotelDto);
            }

            Hotel modelo = _automapper.Map<Hotel>(hotelDto);


         
            await _db.Hoteles.AddAsync(modelo);
           await _db.SaveChangesAsync();

            return CreatedAtRoute("GetHotel", new { id = modelo.Id }, modelo);
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var hotel =await _db.Hoteles.FirstOrDefaultAsync(h => h.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }
            _db.Hoteles.Remove(hotel);
          await  _db.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task< IActionResult>UpdateHotel(int id, [FromBody] HotelUpdateDto hotelDto)
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
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
