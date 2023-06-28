using ASP.NET_API.Model;
using ASP.NET_API.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace ASP.NET_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly ILogger<PessoaController> _logger;
        private IPessoaService _pessoaService;

        public PessoaController(ILogger<PessoaController> logger, IPessoaService pessoaService)
        {
            _logger = logger;
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public IActionResult ProcurarTodos()
        {
            return Ok(_pessoaService.ProcurarTodos());
        }       
        
        [HttpGet("{id}")]
        public IActionResult ProcurarPorID(long id)
        {
            var pessoa = _pessoaService.ProcurarPorID(id);
            if (pessoa == null) return NotFound();
            return Ok(pessoa);
        }        
        
        [HttpPost]
        public IActionResult Criar([FromBody] Pessoa pessoa)
        {
            if (pessoa == null) return BadRequest();
            return Ok(_pessoaService.Criar(pessoa));
        }      
        
        [HttpPut]
        public IActionResult Update([FromBody] Pessoa pessoa)
        {
            if (pessoa == null) return BadRequest();
            return Ok(_pessoaService.Criar(pessoa));
        }  
        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _pessoaService.Deletar(id);
            return NoContent();
        }
    }
}
