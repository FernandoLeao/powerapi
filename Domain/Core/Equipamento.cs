using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core
{
    public class Equipamento : BaseEntity
    {
        public string Nome { get; set; }
        public int CapacidadeTransmissao { get; set; }
        public bool Ativo { get; set; }

        public Agente Agente { get; set; }
        public int AgenteId { get; set; }
    }
}
