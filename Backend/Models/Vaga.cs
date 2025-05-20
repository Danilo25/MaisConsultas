namespace MAISCONSULTAS.API.Models
{
    public class Vaga
    {
        public int Id { get; set; }
        public int? AgendamentoId { get; set; }
        public string? Paciente { get; set; }  
        public bool Disponivel { get; set; }
        public string HoraInicio { get; set; } = string.Empty;
        public string HoraFim { get; set; } = string.Empty;
    }
}