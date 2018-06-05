using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Power.Model
{
    public class CompraModel
    {
        public CompraModel(Usina usina, Agente agente, Equipamento equipamento, int cargaEnviada)
        {
            UsinaId = usina.Id;
            NomeUsina = usina.Nome;
            CapacidadeUsina = usina.CapacidadeGeracao;

            AgenteId = agente.Id;
            NomeAgente = agente.Nome;
            NecessidadeDiariaEnergia = agente.NecessidadeDiariaEnergia;

            EquipamentoId = equipamento.Id;
            NomeEquipamento = equipamento.Nome;
            Custo = usina.ValorHora * cargaEnviada;
            CargaEnviada = cargaEnviada;
            CapacidadeEquipamento = equipamento.CapacidadeTransmissao;
        }

        public int UsinaId { get; set; }
        public string NomeUsina { get; set; }
        public int CapacidadeUsina { get; set; }

        public int AgenteId { get; set; }
        public string NomeAgente { get; set; }
        public int NecessidadeDiariaEnergia { get; set; }

        public int EquipamentoId { get; set; }
        public string NomeEquipamento { get; set; }
        public int CargaEnviada { get; set; }
        public decimal Custo { get; set; }
        public int CapacidadeEquipamento { get; set; }
    }

   
}
