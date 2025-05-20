using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MAISCONSULTAS.API.Models;

namespace MAISCONSULTAS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtendimentosController : ControllerBase
    {
        private static List<Atendimento> _atendimentos = new List<Atendimento>();
        private static int _nextId = 1;

        [HttpGet]
        public ActionResult<IEnumerable<Atendimento>> GetAll() => Ok(_atendimentos);

        [HttpPost]
        public ActionResult<Atendimento> Registrar(Atendimento item)
        {
            item.Id = _nextId++;
            _atendimentos.Add(item);
            return CreatedAtAction(nameof(GetAll), new { id = item.Id }, item);
        }
    }
}