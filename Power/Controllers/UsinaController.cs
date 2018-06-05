using Domain.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Power.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Power.Controllers
{
    [Route("api/[controller]")]
    public class UsinaController : Controller
    {
        private readonly IRepository<Usina> _usinaRepository;


        public UsinaController(IRepository<Usina> usinaRepository)
        {
            _usinaRepository = usinaRepository;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Usina>> Get()
        {
            return await _usinaRepository.GetAllAsync().ConfigureAwait(false);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Usina> Get(int id)
        {
            var usina =  await _usinaRepository.GetAsync(id).ConfigureAwait(false);
            return usina;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Usina usina)
        {
            _usinaRepository.AddAsync(usina);
        }

        public void Put( [FromBody]Usina usina)
        {
             _usinaRepository.Update(usina);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _usinaRepository.Delete(_usinaRepository.Get(id));
        }
    }
}
