using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zoologico1_Modelos;

namespace Zoologico1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalesController : ControllerBase
    {
        private readonly Zoologico1_APIContext _context;

        public AnimalesController(Zoologico1_APIContext context)
        {
            _context = context;
        }

        // GET: api/Animales - CORREGIDO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimal()
        {
            return await _context.Animales
                .Include(a => a.Especie)  
                .Include(a => a.Raza)     
                .ToListAsync();
        }

        // GET: api/Animales/5 - YA ESTÁ CORRECTO
        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(int id)
        {
            var animal = await _context.Animales
                .Include(a => a.Especie)
                .Include(a => a.Raza)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            if (animal == null)
            {
                return NotFound();
            }

            return animal;
        }

        // PUT: api/Animales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimal(int id, Animal animal)
        {
            if (id != animal.Id)
            {
                return BadRequest();
            }

            _context.Entry(animal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Animales - MEJORADO
        [HttpPost]
        public async Task<ActionResult<Animal>> PostAnimal(Animal animal)
        {
            _context.Animales.Add(animal);
            await _context.SaveChangesAsync();

            animal.Especie = await _context.Especies.FindAsync(animal.EspecieId);
            animal.Raza = await _context.Razas.FindAsync(animal.RazaId);

            return CreatedAtAction("GetAnimal", new { id = animal.Id }, animal);
        }

        // DELETE: api/Animales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            var animal = await _context.Animales.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            _context.Animales.Remove(animal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimalExists(int id)
        {
            return _context.Animales.Any(e => e.Id == id);
        }
    }
}