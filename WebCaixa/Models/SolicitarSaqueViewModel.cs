namespace WebCaixa.Models
{
    public class SolicitarSaqueViewModel
    {
        public int? IdNotas10 { get; set; }

        public int? IdNotas20 { get; set; }

        public int? IdNotas50 { get; set; }

        public int? IdNotas100 { get; set; }

        public int? QuantidadeNotas10 { get; set; }

        public int? QuantidadeNotas20 { get; set; }

        public int? QuantidadeNotas50 { get; set; }

        public int? QuantidadeNotas100 { get; set; }

        public decimal? ValorSaque { get; set; }

        public string Erro { get; set; }        
    }
}
