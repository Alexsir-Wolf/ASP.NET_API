using ASP.NET_API.Data.VO;
using ASP.NET_API.Model;

namespace ASP.NET_API.Business
{
	public interface ILoginBusiness
	{
		TokenVO ValidarCredencial(UsuarioVO usuario);
	}
}
