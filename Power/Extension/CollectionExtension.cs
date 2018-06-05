using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Power.Extension
{
    public static class CollectionExtension
    {
        public static IEnumerable<Equipamento> Ativos(this IEnumerable<Equipamento> equipamentos)
        {
            return equipamentos.Where(x => x.Ativo);
        }

        public static IEnumerable<Equipamento> EquipamentosComMaiorCapacidadePrimeiro(this IEnumerable<Equipamento> equipamentos)
        {
            return equipamentos.OrderByDescending(x => x.CapacidadeTransmissao);
        }
    }
}
