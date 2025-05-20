namespace MAISCONSULTAS.API.Models
{
    public class Disponibilidade
    {
        public int Id { get; set; }
        public string Medico{ get; set; }
        public int EspecialidadeId { get; set; }
        public string DiaSemana { get; set; } = string.Empty;
        public string HoraInicio { get; set; } = string.Empty;
        public string HoraFim { get; set; } = string.Empty;
        public int DuracaoConsultaMinutos { get; set; }

        public List<Vaga> Vagas { get; set; } = new();
    }
}