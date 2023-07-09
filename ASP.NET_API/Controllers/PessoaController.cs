using ASP.NET_API.Model;
using ASP.NET_API.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASP.NET_API.Controllers
{
    [ApiVersion("1")]
	[ApiController]
    [Route("api/pessoa/v{version:apiVersion}")]
    public class PessoaController : ControllerBase
    {
        private readonly ILogger<PessoaController> _logger;
        private IPessoaBusiness _pessoaBusiness;

        public PessoaController(ILogger<PessoaController> logger, IPessoaBusiness pessoaBusiness)
        {
            _logger = logger;
            _pessoaBusiness = pessoaBusiness;
        }

        [HttpGet]
        public IActionResult ProcurarTodos()
        {
            return Ok(_pessoaBusiness.ProcurarTodos());
        }       
        
        [HttpGet("{id}")]
        public IActionResult ProcurarPorID(long id)
        {
            var pessoa = _pessoaBusiness.ProcurarPorID(id);
            if (pessoa == null) return NotFound();
            return Ok(pessoa);
        }        
        
        [HttpPost]
        public IActionResult Criar([FromBody] Pessoa pessoa)
        {
            if (pessoa == null) return BadRequest();
            return Ok(_pessoaBusiness.Criar(pessoa));
        }      
        
        [HttpPut]
        public IActionResult Update([FromBody] Pessoa pessoa)
        {
            if (pessoa == null) return BadRequest();
            return Ok(_pessoaBusiness.Update(pessoa));
        }  
        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _pessoaBusiness.Deletar(id);
            return NoContent();
        }
    }
    //aula 65
}
