using ASP.NET_API.Data.VO;
using ASP.NET_API.Model;

namespace ASP.NET_API.Repository
{
	public interface IUsuarioRepository
	{
		Usuario ValidarCredencial(UsuarioVO usuario);
		Usuario UpdateUsuario(Usuario usuario);
	}
}
