namespace MAISCONSULTAS.API.Models
{
    public class Atendimento
    {
        public int Id { get; set; }
        public int AgendamentoId { get; set; }
        public string DataAtendimento { get; set; }
        public string Observacoes { get; set; }
    }
}