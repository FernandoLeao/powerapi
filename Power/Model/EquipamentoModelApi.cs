using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Power.Model
{
    public class EquipamentoModelApi
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CapacidadeTransmissao { get; set; }
        public bool Ativo { get; set; }
        public string AtivoFormatado
        {
            get
            {
                return Ativo ? "Sim" : "Não";
            }
        }

        public string  Agente { get; set; }
        public  int AgenteId { get; set; }
    }
}
