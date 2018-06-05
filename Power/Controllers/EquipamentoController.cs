using Domain.Core;
using Microsoft.AspNetCore.Mvc;
using Power.Model;
using Power.Repository;
using Power.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Power.Controllers
{
    [Route("api/[controller]")]
    public class EquipamentoController : Controller
    {

        private readonly IRepository<Equipamento> _equipamentoRepository;

     
        private readonly IEquipamentoService _equipamentoService;

        public EquipamentoController(IRepository<Equipamento> equipamentoRepository, IEquipamentoService equipamentoService)
        {
            _equipamentoRepository = equipamentoRepository;
            _equipamentoService = equipamentoService;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<EquipamentoModelApi>> Get()
        {
            return  await _equipamentoService.GetAllAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<EquipamentoModelApi> Get(int id)
        {
          return await _equipamentoService.GetbyIdAsync(id).ConfigureAwait(false);

        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Equipamento equipamento)
        {
            _equipamentoRepository.AddAsync(equipamento);
        }

        public void Put([FromBody]EquipamentoModelApi equipamento)
        {
           _equipamentoService.UpdateAsync(equipamento);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _equipamentoRepository.Delete(_equipamentoRepository.Get(id));
        }
    }
}
