using ASP.NET_API.Data.VO;
using ASP.NET_API.Model;
using ASP.NET_API.Model.Contexto;
using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;

namespace ASP.NET_API.Repository
{
	public class UsuarioRepository : IUsuarioRepository
	{
		private readonly SQLServerContext _context;

		public UsuarioRepository(SQLServerContext context)
		{
			_context = context;
		}

		public Usuario ValidarCredencial(UsuarioVO usuario)
		{
			var senhaEncryptada = Encryptar(usuario.Senha, new SHA256CryptoServiceProvider());

			return _context.Usuarios.FirstOrDefault(x => (x.NomeUsuario == usuario.NomeUsuario) && (x.Senha == senhaEncryptada));
		}

		public Usuario UpdateUsuario(Usuario usuario)
		{
			if (!_context.Usuarios.Any(x => x.Id.Equals(usuario.Id)))
				return null;

			var result = _context.Usuarios.SingleOrDefault(x => x.Id.Equals(usuario.Id));
			if (result != null)
			{
				try
				{
					_context.Entry(result).CurrentValues.SetValues(usuario);
					_context.SaveChanges();
					return result;
				}
				catch (System.Exception)
				{
					throw;
				}
			}
			return result;
		}

		private string Encryptar(string senha, SHA256CryptoServiceProvider algoritmo)
		{
			Byte[] hashedBytes = algoritmo.ComputeHash(Encoding.UTF8.GetBytes(senha));
			return BitConverter.ToString(hashedBytes);			 
		}
	}
}
