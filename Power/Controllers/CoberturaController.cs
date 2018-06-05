using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Power.Model;
using Power.Services;

namespace Power.Controllers
{
    [Route("api/[controller]")]
    public class CoberturaController : Controller
    {
        private readonly IDistribuirCargaService _distribuirCargaService;
        private readonly IFileService _fileService;
        public CoberturaController(IDistribuirCargaService distribuirCargaService, IFileService fileService)
        {
            _distribuirCargaService = distribuirCargaService;
            _fileService = fileService;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cobertura =  await _distribuirCargaService.CalcularCobertura();
            var stream  = _fileService.CriarStream(cobertura);
            var response = File(stream, "application/octet-stream"); // FileStreamResult
            return response;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
