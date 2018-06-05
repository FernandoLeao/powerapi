using Domain.Core;
using Microsoft.AspNetCore.Mvc;
using Power.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Power.Controllers
{
    [Route("api/[controller]")]
    public class AgenteController : Controller
    {

        private readonly IRepository<Agente> _agenteRepository;


        public AgenteController(IRepository<Agente> agenteRepository)
        {
            _agenteRepository = agenteRepository;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Agente>> Get()
        {
            return await _agenteRepository.GetAllAsync().ConfigureAwait(false);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Agente> Get(int id)
        {
            var agente = await _agenteRepository.GetAsync(id).ConfigureAwait(false);
            return agente;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Agente agente)
        {
            _agenteRepository.AddAsync(agente);
        }

        public void Put([FromBody]Agente agente)
        {
            _agenteRepository.Update(agente);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _agenteRepository.Delete(_agenteRepository.Get(id));
        }
    }
}
