using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core;
using Power.Extension;
using Power.Model;
using Power.Repository;

namespace Power.Services
{
    public class EquipamentoService : IEquipamentoService
    {

        private readonly IRepository<Equipamento> _equipamentoRepository;

        private readonly IRepository<Agente> _agenteController;

        public EquipamentoService(IRepository<Equipamento> equipamentoRepository, IRepository<Agente> agenteController)
        {
            _equipamentoRepository = equipamentoRepository;
            _agenteController = agenteController;
        }

        public async Task<IEnumerable<EquipamentoModelApi>> GetAllAsync()
        {
            var equipamentos = await _equipamentoRepository.GetAllAsync().ConfigureAwait(false);
            var list = new List<EquipamentoModelApi>();
            foreach (var eq in equipamentos)
            {
                eq.Agente = await _agenteController.GetAsync(eq.AgenteId).ConfigureAwait(false);

                list.Add(eq.ToModel());
            }

            return list;
        }

        public async Task<EquipamentoModelApi> GetbyIdAsync(int id)
        {
            var eq = await _equipamentoRepository.GetAsync(id).ConfigureAwait(false);
            eq.Agente = await _agenteController.GetAsync(eq.AgenteId).ConfigureAwait(false);
            return eq.ToModel();
        }

        public  void UpdateAsync(EquipamentoModelApi equipamentoModel)
        {
            var eq =  _equipamentoRepository.Get(equipamentoModel.Id);
            eq.Nome = equipamentoModel.Nome;
            eq.Ativo = equipamentoModel.Ativo;
            eq.CapacidadeTransmissao = equipamentoModel.CapacidadeTransmissao;

            _equipamentoRepository.Update(eq);
        }
    }
}
