using ASP.NET_API.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP.NET_API.Data.VO;

namespace ASP.NET_API.Controllers
{
	[ApiVersion("2")]
	[ApiController]
	[Route("api/pessoa/v{version:apiVersion}")]
	public class PessoaControllerV2 : ControllerBase
	{
		private readonly ILogger<PessoaControllerV2> _logger;
		private IPessoaBusiness _pessoaBusiness;

		public PessoaControllerV2(ILogger<PessoaControllerV2> logger, IPessoaBusiness pessoaBusiness)
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
		public IActionResult Criar([FromBody] PessoaVO pessoa)
		{
			if (pessoa == null) return BadRequest();
			return Ok(_pessoaBusiness.Criar(pessoa));
		}

		[HttpPut]
		public IActionResult Update([FromBody] PessoaVO pessoa)
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
