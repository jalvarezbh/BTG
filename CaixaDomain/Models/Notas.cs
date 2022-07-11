using System;

namespace CaixaDomain.Models
{
    public class Notas : Base
    {
        public decimal Valor { get; set; }

        public int Quantidade { get; set; }

        public DateTime DataAtualizacao { get; set; }
    }
}
