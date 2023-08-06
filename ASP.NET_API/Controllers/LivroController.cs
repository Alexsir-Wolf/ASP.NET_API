using ASP.NET_API.Model;
using ASP.NET_API.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP.NET_API.Hypermedia.Filters;

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
		[TypeFilter(typeof(HyperMediaFilter))]
		public IActionResult ProcurarTodos()
        {
            return Ok(_livroBusiness.ProcurarTodos());
        }       
        
        [HttpGet("{id}")]
		[TypeFilter(typeof(HyperMediaFilter))]
		public IActionResult ProcurarPorID(long id)
        {
            var livro = _livroBusiness.ProcurarPorID(id);
            if (livro == null) return NotFound();
            return Ok(livro);
        }        
        
        [HttpPost]
		[TypeFilter(typeof(HyperMediaFilter))]
		public IActionResult Criar([FromBody] LivroVO livro)
        {
            if (livro == null) return BadRequest();
            return Ok(_livroBusiness.Criar(livro));
        }      
        
        [HttpPut]
		[TypeFilter(typeof(HyperMediaFilter))]
		public IActionResult Update([FromBody] LivroVO livro)
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
