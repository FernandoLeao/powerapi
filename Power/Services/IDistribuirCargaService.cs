using Power.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Power.Services
{
    public interface IDistribuirCargaService
    {
        Task<IEnumerable<UsinaModel>> CalcularCobertura();
    }
}
