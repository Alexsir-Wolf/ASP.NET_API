using ASP.NET_API.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP.NET_API.Data.VO;
using ASP.NET_API.Hypermedia.Filters;
using System.Collections.Generic;

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
		[ProducesResponseType(200, Type = typeof(List<PessoaVO>))]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		[ProducesResponseType(401)]
		[TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult ProcurarTodos()
        {
            return Ok(_pessoaBusiness.ProcurarTodos());
        }       
        
        [HttpGet("{id}")]
		[ProducesResponseType(200, Type = typeof(PessoaVO))]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		[ProducesResponseType(401)]
		[TypeFilter(typeof(HyperMediaFilter))]
		public IActionResult ProcurarPorID(long id)
        {
            var pessoa = _pessoaBusiness.ProcurarPorID(id);
            if (pessoa == null) return NotFound();
            return Ok(pessoa);
        }        
        
        [HttpPost]
		[ProducesResponseType(200, Type = typeof(PessoaVO))]
		[ProducesResponseType(400)]
		[ProducesResponseType(401)]
		[TypeFilter(typeof(HyperMediaFilter))]
		public IActionResult Criar([FromBody] PessoaVO pessoa)
        {
            if (pessoa == null) return BadRequest();
            return Ok(_pessoaBusiness.Criar(pessoa));
        }      
        
        [HttpPut]
		[ProducesResponseType(200, Type = typeof(PessoaVO))]
		[ProducesResponseType(400)]
		[ProducesResponseType(401)]
		[TypeFilter(typeof(HyperMediaFilter))]
		public IActionResult Update([FromBody] PessoaVO pessoa)
        {
            if (pessoa == null) return BadRequest();
            return Ok(_pessoaBusiness.Update(pessoa));
        }  
        
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
		public IActionResult Delete(long id)
        {
            _pessoaBusiness.Deletar(id);
            return NoContent();
        }
    }
}
