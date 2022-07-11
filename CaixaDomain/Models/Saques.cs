using System;

namespace CaixaDomain.Models
{
    public class Saques : Base
    {
        public decimal Valor { get; set; }

        public int QuantidadeNotas { get; set; }

        public DateTime Data { get; set; }
    }
}
