using DAL;
using System.Data;
using Common;

namespace BRL
{
	/// <summary>
	/// Clase UsuarioBRL
	/// </summary>
	public class UsuarioBRL : AbstractBRL
	{
		/// <summary>
		/// atributos, propiedades, constructores UsuarioBRL
		/// </summary>
		#region atributos, propiedades, constructores
		private Usuario user;

		public Usuario User
		{
			get { return user; }
			set { user = value; }
		}
		private UsuarioDal dal;

		public UsuarioDal Dal
		{
			get { return dal; }
			set { dal = value; }
		}
		public UsuarioBRL()
		{

		}
		public UsuarioBRL(Usuario user)
		{
			this.user = user;
			dal = new UsuarioDal(user);
		}

		#endregion
		public override void Delete()
		{
			dal.Delete();
		}
		/// <summary>
		/// Metodo Insert UsuarioBRL
		/// </summary>
		public override void Insert()
		{
			dal.Insert();
		}
		/// <summary>
		/// Metodo Select UsuarioBRL
		/// </summary>
		/// <returns>DataTable</returns>
		public override DataTable Select()
		{
			dal = new UsuarioDal();
			return dal.Select();
		}
		/// <summary>
		/// Metodo Update UsuarioBRL
		/// </summary>
		public override void Update()
		{
			dal.Update();
		}
		/// <summary>
		/// Metodo UpdateDatosPerfil UsuarioBRL
		/// </summary>
		public void UpdateDatosPerfil()
		{
			dal.UpdateDatosPerfil();
		}
		/// <summary>
		/// Metodo UpdateContrasenia UsuarioBRL
		/// </summary>
		public void UpdateContrasenia()
		{
			dal.UpdateContrasenia();
		}
		/// <summary>
		/// Metodo UpdateContraseniaRestablecida UsuarioBRL
		/// </summary>
		public void UpdateContraseniaRestablecida()
		{
			dal.UpdateContraseniaRestablecida();
		}

		/// <summary>
		/// Metodo para restablecer la contraseña de empleado a travez del administrador
		/// </summary>
		public void UpdateContraseniaRestablecidaParaAdministrador()
		{
			dal.UpdateContraseniaRestablecidaParaAdministrador();
		}
		
		/// <summary>
		/// Metodo Login UsuarioBRL
		/// </summary>
		/// <param name="usuario"></param>
		/// <param name="contrasenia"></param>
		/// <returns>DataTable</returns>
		public DataTable Login(string usuario, string contrasenia)
		{
			dal = new UsuarioDal();
			return dal.Login(usuario, contrasenia);
		}
		/// <summary>
		/// Metodo VerificarUser UsuarioBRL
		/// </summary>
		/// <param name="usuario"></param>
		/// <param name="correo"></param>
		/// <returns>DataTable</returns>
		public DataTable VerificarUser(string usuario)
		{
			dal = new UsuarioDal();
			return dal.VerificarUser(usuario);
		}
		/// <summary>
		/// Metodo para que el administrador pueda restablecer la contraseña del empleado UsuarioBRL
		/// </summary>
		/// <param name="id"></param>
		/// <returns>DataTable</returns>
		public DataTable RestablecerContraseñaDesdeAdministrador(int id)
		{
			dal = new UsuarioDal();
			return dal.RestablecerContraseñaDesdeAdministrador(id);
		}
		/// <summary>
		/// Metodo RestablecerContrasenia UsuarioBRL
		/// </summary>
		/// <param name="usuario"></param>
		/// <returns>DataTable</returns>
		public DataTable RestablecerContrasenia(string usuario)
		{
			dal = new UsuarioDal();
			return dal.RestablecerContrasenia(usuario);
		}
		/// <summary>
		/// Metodo Get UsuarioBRL
		/// </summary>
		/// <param name="idUsuario"></param>
		/// <returns>Usuario</returns>
		public Usuario Get(int idUsuario)
		{
			dal = new UsuarioDal();
			return dal.Get(idUsuario);
		}
		/// <summary>
		/// Metodo SelectBusquedaUsarios UsuarioBRL
		/// </summary>
		/// <param name="texto"></param>
		/// <returns></returns>
		public DataTable SelectBusquedaUsarios(string texto)
		{
			dal = new UsuarioDal();
			return dal.SelectBusquedaUsarios(texto);
		}
		
	}
}
