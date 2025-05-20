using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MAISCONSULTAS.API.Models;

namespace MAISCONSULTAS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspecialidadesController : ControllerBase
    {
        private static List<Especialidade> _especialidades = new List<Especialidade>();
        private static int _nextId = 1;

        [HttpGet]
        public ActionResult<IEnumerable<Especialidade>> GetAll()
        {
            return Ok(_especialidades);
        }

        [HttpGet("{id}")]
        public ActionResult<Especialidade> GetById(int id)
        {
            var item = _especialidades.Find(x => x.Id == id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public ActionResult<Especialidade> Create(Especialidade item)
        {
            item.Id = _nextId++;
            _especialidades.Add(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Especialidade updated)
        {
            var index = _especialidades.FindIndex(x => x.Id == id);
            if (index == -1) return NotFound();
            updated.Id = id;
            _especialidades[index] = updated;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var index = _especialidades.FindIndex(x => x.Id == id);
            if (index == -1) return NotFound();
            _especialidades.RemoveAt(index);
            return NoContent();
        }
    }
}