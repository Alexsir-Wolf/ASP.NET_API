using System.Collections.Generic;
using System.Security.Claims;

namespace ASP.NET_API.Services
{
	public interface ITokenService
	{
		string GerarTokenAcesso(IEnumerable<Claim> claims);
		string GerarRefreshToken();
		ClaimsPrincipal PrincipalTokemExpirado(string token);
	}
}
