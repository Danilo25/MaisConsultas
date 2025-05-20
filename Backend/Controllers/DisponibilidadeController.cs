using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using MAISCONSULTAS.API.Models;

namespace MAISCONSULTAS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisponibilidadesController : ControllerBase
    {
        private static List<Disponibilidade> _disponibilidades = new List<Disponibilidade>();
        private static int _nextId = 1;
        private static int _nextVagaId = 1;

        [HttpGet]
        public ActionResult<IEnumerable<Disponibilidade>> GetAll() => Ok(_disponibilidades);

        [HttpPost("definir")]
        public ActionResult<Disponibilidade> Definir(Disponibilidade item)
        {
            item.Id = _nextId++;

            try
            {
                var horaInicio = TimeSpan.Parse(item.HoraInicio);
                var horaFim = TimeSpan.Parse(item.HoraFim);
                var duracao = TimeSpan.FromMinutes(item.DuracaoConsultaMinutos);

                var vagas = new List<Vaga>();

                while (horaInicio + duracao <= horaFim)
                {
                    vagas.Add(new Vaga
                    {
                        Id = _nextVagaId++,
                        HoraInicio = horaInicio.ToString(@"hh\:mm"),
                        HoraFim = (horaInicio + duracao).ToString(@"hh\:mm"),
                        Disponivel = true
                    });

                    horaInicio += duracao;
                }

                item.Vagas = vagas;
            }
            catch
            {
                return BadRequest("Horários inválidos ou duração inconsistente.");
            }

            _disponibilidades.Add(item);
            return CreatedAtAction(nameof(GetAll), new { id = item.Id }, item);
        }

        [HttpPost]
        public IActionResult PostDisponibilidades([FromBody] dynamic body)
        {
            try
            {
                int especialidadeId = (int)body.especialidadeId;
                string data = (string)body.data;
                string? medico = body.medico != null ? (string)body.medico : null;
        
                var diaSemana = DateTime.Parse(data).ToString("dddd", new System.Globalization.CultureInfo("pt-BR"));
        
                var resultado = new List<object>();
        
                // Busca disponibilidade do dia
                foreach (var disponibilidade in _disponibilidades)
                {
                    if (disponibilidade.EspecialidadeId == especialidadeId &&
                        disponibilidade.DiaSemana.Equals(diaSemana, StringComparison.OrdinalIgnoreCase) &&
                        (string.IsNullOrEmpty(medico) || disponibilidade.Medico == medico))
                    {
                        foreach (var vaga in disponibilidade.Vagas)
                        {
                            var obj = new Dictionary<string, object>
                            {
                                ["horaInicio"] = vaga.HoraInicio,
                                ["horaFim"] = vaga.HoraFim,
                                ["disponivel"] = vaga.Disponivel
                            };
        
                            if (!vaga.Disponivel)
                            {
                                if (vaga.AgendamentoId.HasValue)
                                    obj["agendamentoId"] = vaga.AgendamentoId.Value;
                                if (!string.IsNullOrEmpty(vaga.Paciente))
                                    obj["paciente"] = vaga.Paciente;
                            }
        
                            resultado.Add(obj);
                        }
                    }
                }
        
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao processar POST /api/disponibilidades:");
                Console.WriteLine(ex.Message);
                return BadRequest("Erro ao processar a solicitação.");
            }
        }
    }

    
}