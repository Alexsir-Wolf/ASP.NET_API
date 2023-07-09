using ASP.NET_API.Model;
using ASP.NET_API.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASP.NET_API.Controllers
{
	[ApiVersion("2")]
	[ApiController]
	[Route("api/pessoa/v{version:apiVersion}")]
	public class PessoaControllerV2 : ControllerBase
	{
		private readonly ILogger<PessoaControllerV2> _logger;
		private IPessoaService _pessoaService;

		public PessoaControllerV2(ILogger<PessoaControllerV2> logger, IPessoaService pessoaService)
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
			return Ok(_pessoaService.Update(pessoa));
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			_pessoaService.Deletar(id);
			return NoContent();
		}
	}
	//aula 65
}
