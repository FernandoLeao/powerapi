using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core
{
    public class Usina : BaseEntity
    {
        public string  Nome { get; set; }
        public int CapacidadeGeracao { get; set; }
        public decimal ValorHora { get; set; }
    }
}
