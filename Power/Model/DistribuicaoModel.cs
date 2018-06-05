using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Power.Model
{
    public class DistribuicaoModel
    {
        private readonly IEnumerable<CompraModel> _compras;

        public DistribuicaoModel(IEnumerable<CompraModel>  compras)
        {
            _compras = compras;
        }

        public IEnumerable<UsinaModel> Formatar()
        {
            var usinas = new Dictionary<int, UsinaModel>();
            foreach(var compra in _compras)
            {
                var equipamento = new EquipamentoModel() { CargaEnviada = compra.CargaEnviada, Custo = compra.Custo, Nome = compra.NomeEquipamento, CapacidadeEquipamento = compra.CapacidadeEquipamento };

                if (usinas.ContainsKey(compra.UsinaId))
                {
                    if (usinas[compra.UsinaId].Agentes.ContainsKey(compra.AgenteId))
                    {
                        usinas[compra.UsinaId].Agentes[compra.AgenteId].Equipamentos.Add(equipamento);
                    }
                    else
                    {
                        usinas[compra.UsinaId].Agentes.Add(compra.AgenteId, 
                            new AgenteModel()
                            {
                                NecessidadeAgente = compra.NecessidadeDiariaEnergia,
                                Nome = compra.NomeAgente,
                                Equipamentos = new List<EquipamentoModel>() { equipamento }
                            });
                    }
                }
                else
                {
                    var usina = new UsinaModel() { CapacidadeGeracao = compra.CapacidadeUsina, Nome = compra.NomeUsina };
                    var agente = new AgenteModel() { NecessidadeAgente = compra.NecessidadeDiariaEnergia, Nome = compra.NomeAgente };
                    agente.Equipamentos.Add(equipamento);
                    usina.Agentes.Add( compra.AgenteId, agente);

                    usinas.Add(compra.UsinaId, usina);
                }
            }

            return usinas.Select(x => x.Value);

        }
    }

    public class UsinaModel
    {
        public UsinaModel()
        {
            Agentes = new Dictionary<int, AgenteModel>();
        }
        public string Nome { get; set; }
        public int CapacidadeGeracao { get; set; }
        public Dictionary<int,AgenteModel> Agentes { get; set; }
    }

    public class AgenteModel
    {
        public AgenteModel()
        {
            Equipamentos = new List<EquipamentoModel>();
        }
        public string Nome { get; set; }
        public int NecessidadeAgente { get; set; }
        public IList<EquipamentoModel> Equipamentos { get; set; }
    }

    public class EquipamentoModel
    {
        public string Nome { get; set; }
        public int CapacidadeEquipamento { get; set; }
        public int CargaEnviada { get; set; }
        public decimal Custo { get; set; }
    }
}
