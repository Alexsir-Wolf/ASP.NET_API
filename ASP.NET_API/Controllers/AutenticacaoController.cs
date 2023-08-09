using ASP.NET_API.Business;
using ASP.NET_API.Data.VO;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_API.Controllers
{
	[ApiVersion("1")]
	[Route("api/[controller]/v{version:apiVersion}")]
	[ApiController]
	public class AutenticacaoController : ControllerBase
	{
		private ILoginBusiness _loginBusiness;

		public AutenticacaoController(ILoginBusiness loginBusiness)
		{
			_loginBusiness = loginBusiness;
		}

		[HttpPost]
		[Route("entrar")]
		public ActionResult Entrar([FromBody] UsuarioVO usuario) 
		{
			if (usuario == null)
				return BadRequest("Requisição inválida.");

			var token = _loginBusiness.ValidarCredencial(usuario);
			if (token == null)
				return Unauthorized();
			
			return Ok(token);
		}
	}
}
