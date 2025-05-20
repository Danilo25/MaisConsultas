namespace MAISCONSULTAS.API.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public string Paciente { get; set; } 
        public int EspecialidadeId { get; set; }
        public string EspecialidadeNome { get; set; }
        public int ConvenioId { get; set; }
        public string ConvenioNome { get; set; }
        public string DataHora { get; set; }
        public string Medico { get; set; } 
    }
}