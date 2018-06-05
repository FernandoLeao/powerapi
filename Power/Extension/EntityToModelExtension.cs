using Domain.Core;
using Power.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Power.Extension
{
    public static class EntityToModelExtension
    {
        public static EquipamentoModelApi ToModel(this Equipamento equipamento)
        {
            return new EquipamentoModelApi()
            {
                Id = equipamento.Id,
                Agente = equipamento.Agente.Nome,
                AgenteId = equipamento.AgenteId,
                Nome = equipamento.Nome,
                Ativo = equipamento.Ativo,
                CapacidadeTransmissao = equipamento.CapacidadeTransmissao
            };
        }
    }
}
