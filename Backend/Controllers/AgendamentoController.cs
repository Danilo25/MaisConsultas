using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MAISCONSULTAS.API.Models;

namespace MAISCONSULTAS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentosController : ControllerBase
    {
        private static List<Agendamento> _agendamentos = new List<Agendamento>();
        private static int _nextId = 1;

        [HttpGet]
        public ActionResult<IEnumerable<Agendamento>> GetAll() => Ok(_agendamentos);

        [HttpPost]
        public ActionResult<Agendamento> Create(Agendamento item)
        {
            item.Id = _nextId++;
            _agendamentos.Add(item);
            return CreatedAtAction(nameof(GetAll), new { id = item.Id }, item);
        }
    }
}