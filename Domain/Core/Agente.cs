using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core
{
    public class Agente : BaseEntity
    {
        public virtual string Nome { get; set; }

        public virtual int NecessidadeDiariaEnergia { get; set; }


        public virtual ICollection<Equipamento> Equipamentos
        {
            get { return _equipamentos ?? (_equipamentos = new List<Equipamento>()); }
            set { _equipamentos = value; }
        }

        private ICollection<Equipamento> _equipamentos { get; set; }
    }
}
