using Domain.Core;
using Power.Extension;
using Power.Model;
using Power.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Power.Services
{
    public class DistribuirCargaService : IDistribuirCargaService
    {
        private readonly IRepository<Usina> _usinaRepository;
        private readonly IRepository<Equipamento> _equipamentoRepository;
        private readonly IRepository<Agente> _agenteRepository;

        public DistribuirCargaService(IRepository<Usina> usinaRepository, IRepository<Equipamento> equipamentoRepository, IRepository<Agente> agenteRepository)
        {
            _usinaRepository = usinaRepository;
            _equipamentoRepository = equipamentoRepository;
            _agenteRepository = agenteRepository;
        }
        public async Task<IEnumerable<UsinaModel>> CalcularCobertura()
        {
            var taskUsinas  = await _usinaRepository.GetAllAsync().ConfigureAwait(false);

            var taskAgentes = await _agenteRepository.GetAllAsync().ConfigureAwait(false);

            var equipamentosTask = await _equipamentoRepository.GetAllAsync().ConfigureAwait(false);

            var agentes     = taskAgentes.OrderByDescending(x => x.NecessidadeDiariaEnergia).ToList();

            var usinas      = taskUsinas.OrderBy(x => x.ValorHora).ToList();


            var compras = new List<CompraModel>();

            foreach(var ag in agentes)
            {
                var equipamentos = equipamentosTask.Where(x=>x.AgenteId == ag.Id)
                                                    .Ativos()
                                                    .EquipamentosComMaiorCapacidadePrimeiro()
                                                    .ToList();

                var necessidadeDiaria = ag.NecessidadeDiariaEnergia;

                foreach (var eq in equipamentos)
                {
                    var quantidadeEnergiaComprada = 0;
                    if (necessidadeDiaria > eq.CapacidadeTransmissao)
                        quantidadeEnergiaComprada = eq.CapacidadeTransmissao;
                    else
                        quantidadeEnergiaComprada = necessidadeDiaria;

                    ComprarEnergia(ag, eq, usinas,compras, quantidadeEnergiaComprada);

                    necessidadeDiaria = necessidadeDiaria - quantidadeEnergiaComprada;

                    if (necessidadeDiaria == 0)
                        break;
                }
            }

            return new DistribuicaoModel(compras).Formatar(); 
           
        }

        private void ComprarEnergia(Agente ag, Equipamento eq, List<Usina> usinas,IList<CompraModel> compras, int quantidadeEnergiaComprada)
        {
            var totalComprado = 0;
            var quantidadeEnergiaCompradaTemp = quantidadeEnergiaComprada;
            foreach (var usina in usinas.Where(x => x.CapacidadeGeracao > 0))
            {
                var capacidadeComprada = 0;
               
                if (usina.CapacidadeGeracao >= quantidadeEnergiaCompradaTemp)
                    capacidadeComprada = quantidadeEnergiaCompradaTemp;
                else
                    capacidadeComprada = usina.CapacidadeGeracao;

                compras.Add(new CompraModel(usina, ag, eq, capacidadeComprada));

                totalComprado += capacidadeComprada;
                usina.CapacidadeGeracao = usina.CapacidadeGeracao - capacidadeComprada;

               

                if (totalComprado == quantidadeEnergiaComprada)
                    break;

                quantidadeEnergiaCompradaTemp -= capacidadeComprada;
            }
        }
    }
}
