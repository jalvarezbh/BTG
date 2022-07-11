using System;

namespace WebCaixa.Models
{
    public class NotasBancoViewModel
    {
        public int? Id { get; set; }

        public decimal Valor { get; set; }

        public int Quantidade { get; set; }

        public DateTime DataAtualizacao { get; set; }
    }
}
