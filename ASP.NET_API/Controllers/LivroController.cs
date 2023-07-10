using ASP.NET_API.Model;
using ASP.NET_API.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASP.NET_API.Controllers
{
    [ApiVersion("1")]
	[ApiController]
    [Route("api/livro/v{version:apiVersion}")]
    public class LivroController : ControllerBase
    {
        private readonly ILogger<LivroController> _logger;
        private ILivroBusiness _livroBusiness;

        public LivroController(ILogger<LivroController> logger, ILivroBusiness livroBusiness)
        {
            _logger = logger;
            _livroBusiness = livroBusiness;
        }

        [HttpGet]
        public IActionResult ProcurarTodos()
        {
            return Ok(_livroBusiness.ProcurarTodos());
        }       
        
        [HttpGet("{id}")]
        public IActionResult ProcurarPorID(long id)
        {
            var livro = _livroBusiness.ProcurarPorID(id);
            if (livro == null) return NotFound();
            return Ok(livro);
        }        
        
        [HttpPost]
        public IActionResult Criar([FromBody] Livro livro)
        {
            if (livro == null) return BadRequest();
            return Ok(_livroBusiness.Criar(livro));
        }      
        
        [HttpPut]
        public IActionResult Update([FromBody] Livro livro)
        {
            if (livro == null) return BadRequest();
            return Ok(_livroBusiness.Update(livro));
        }  
        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _livroBusiness.Deletar(id);
            return NoContent();
        }
    }
}
