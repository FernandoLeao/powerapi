using Power.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Power.Services
{
    public interface IEquipamentoService 
    {
        Task<IEnumerable<EquipamentoModelApi>> GetAllAsync();
        Task<EquipamentoModelApi> GetbyIdAsync(int id);
        void UpdateAsync(EquipamentoModelApi equipamentoModel);
    }
}
