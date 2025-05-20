using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MAISCONSULTAS.API.Models;

namespace MAISCONSULTAS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConveniosController : ControllerBase
    {
        private static List<Convenio> _convenios = new List<Convenio>();
        private static int _nextId = 1;

        [HttpGet]
        public ActionResult<IEnumerable<Convenio>> GetAll() => Ok(_convenios);

        [HttpGet("{id}")]
        public ActionResult<Convenio> GetById(int id)
        {
            var item = _convenios.Find(x => x.Id == id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public ActionResult<Convenio> Create(Convenio item)
        {
            item.Id = _nextId++;
            _convenios.Add(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Convenio updated)
        {
            var index = _convenios.FindIndex(x => x.Id == id);
            if (index == -1) return NotFound();
            updated.Id = id;
            _convenios[index] = updated;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var index = _convenios.FindIndex(x => x.Id == id);
            if (index == -1) return NotFound();
            _convenios.RemoveAt(index);
            return NoContent();
        }
    }
}