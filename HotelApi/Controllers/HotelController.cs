using HotelApi.Modelos;
using HotelApi.Utiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly Conexion conexion;
        public HotelController(Conexion conexion)
        {
            this.conexion = conexion;
        }

        // GET: api/<HotelController>
        [HttpGet]
        public IEnumerable<ConsultaHotelCiudad> GetHoteles()
        {
            var resultados = conexion.consultaHotelCiudades.FromSqlRaw(@"SELECT 
                        tblHotel.idHotel, 
                        tblCiudad.nombreCiudad,
                        tblHotel.habitacionesEstandar, 
                        tblHotel.habitacionesPremium, 
                        tblHotel.cupoMaximoHabitaciones 
                        FROM tblHotel JOIN tblCiudad ON tblHotel.fkCiudad = tblCiudad.idCiudad");
            return resultados;
        }

        // POST api/<HotelController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TblHotel hotel)
        {
            conexion.tblHotel.Add(hotel);
            await conexion.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHoteles), new { id = hotel.IdHotel }, hotel);
        }

        // PUT api/<HotelController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TblHotel hotel)
        {
            if (id != hotel.IdHotel)
            {
                return BadRequest();
            }
            conexion.Entry(hotel).State = EntityState.Modified;

            try
            {
                await conexion.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok();

        }

        // DELETE api/<HotelController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(byte id)
        {
            if (conexion.tblHotel == null)
            {
                return NotFound();
            }

            var hotel = await conexion.tblHotel.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            conexion.tblHotel.Remove(hotel);
            await conexion.SaveChangesAsync();

            return Ok();
        }
    }
}
