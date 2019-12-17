using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Common;

namespace DAL
{
	/// <summary>
	/// Clase UsuarioDAL
	/// </summary>
	public class UsuarioDal : AbstractDAL
	{
		private Usuario user;

		public Usuario User
		{
			get { return user; }
			set { user = value; }
		}

		public UsuarioDal()
		{

		}
		public UsuarioDal(Usuario user)
		{
			this.user = user;
		}
		#region metodos de la clase
		/// <summary>
		/// Metodo Delete UsuarioDAL cambia el estado de un usuario a inactivo 0
		/// </summary>
		public override void Delete()
		{
			string query1 = "UPDATE Empleado SET estadoEmpleado=0 WHERE idEmpleado = @idEmpleado";
			string query2 = "INSERT INTO Auditoria(tabla,creaUpdDel,descripcion,idUsuario)VALUES(@tabla,@creaUpdDel,@descripcion,@idUsuario)";
			List<SqlCommand> cmdslist = new List<SqlCommand>();
			try
			{
				Methods.GenerateLogsActivities(DateTime.Now, "Inicio del Metodo Delete de un Empleado"+", Usuario: "+user.NombreUsuario+", Rol: "+user.Rol, Sesion.usuarioSesion);
				List<string> querys = new List<string>();
				querys.Add(query1);
				querys.Add(query2);
				cmdslist = Methods.CreateNCommands(querys);

				cmdslist[0].Parameters.AddWithValue("@idEmpleado", user.IdUsuario);

				string tabla = "Empleado";
				char cr = 'D';
				string descripcion = "ID Empleado: " + user.IdUsuario + ", Se Elimino: " + user.NombreUsuario + ", estadoEmpleado=0";

				cmdslist[1].Parameters.AddWithValue("@tabla", tabla);
				cmdslist[1].Parameters.AddWithValue("@creaUpdDel", cr);
				cmdslist[1].Parameters.AddWithValue("@descripcion", descripcion);
				cmdslist[1].Parameters.AddWithValue("@idUsuario", Sesion.idSesion);


				Methods.ExecuteNBasicCommand(cmdslist);

				Methods.GenerateLogsActivities(DateTime.Now, "Empleado Eliminado: " + ", Usuario: " + user.NombreUsuario + ", Rol: " + user.Rol, Sesion.usuarioSesion);
			}
			catch (SqlException ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
		}
		/// <summary>
		/// Metodo Insert UsuarioDAL permite agregar un nuevo empleado
		/// </summary>
		public override void Insert()
		{
			string query1 = "INSERT INTO Empleado(nombres,primerApellido,segundoApellido,sexo,usuario,contrasenia,rolEmpleado,email,fechaRegistro) VALUES(@nombres,@primerApellido,@segundoApellido,@sexo,@usuario,HASHBYTES('md5',@contrasenia),@rolEmpleado,@email,@fechaRegistro)";
			string query2 = "INSERT INTO Auditoria(tabla,creaUpdDel,descripcion,idUsuario)VALUES(@tabla,@creaUpdDel,@descripcion,@idUsuario)";
			List<SqlCommand> cmdslist = new List<SqlCommand>();
			try
			{
				Methods.GenerateLogsActivities(DateTime.Now, "Inicio del Metodo Insert de un Empleado" + ", Usuario: " + user.NombreUsuario + ", Rol: " + user.Rol, Sesion.usuarioSesion);

				List<string> querys = new List<string>();
				querys.Add(query1);
				querys.Add(query2);
				cmdslist = Methods.CreateNCommands(querys);

				cmdslist[0].Parameters.AddWithValue("@nombres", user.Nombres);
				cmdslist[0].Parameters.AddWithValue("@primerApellido", user.PrimerApellido);
				cmdslist[0].Parameters.AddWithValue("@segundoApellido", user.SegundoApellido);
				cmdslist[0].Parameters.AddWithValue("@sexo", user.Sexo);
				cmdslist[0].Parameters.AddWithValue("@usuario", user.NombreUsuario);
				cmdslist[0].Parameters.AddWithValue("@contrasenia", user.Contrasenia).SqlDbType = SqlDbType.VarChar;
				cmdslist[0].Parameters.AddWithValue("@rolEmpleado", user.Rol);
				cmdslist[0].Parameters.AddWithValue("@email", user.Correo);
				cmdslist[0].Parameters.AddWithValue("@fechaRegistro", user.FechaRegistro);

				int idEmp = Methods.GetCurrentValueIDTable("Empleado");
				string tabla = "Empleado";
				char cr = 'C';
				string descripcion = "ID Empleado: " + idEmp + ", Se agrego: " + user.NombreUsuario+", Rol: "+user.Rol;
				cmdslist[1].Parameters.AddWithValue("@tabla", tabla);
				cmdslist[1].Parameters.AddWithValue("@creaUpdDel", cr);
				cmdslist[1].Parameters.AddWithValue("@descripcion", descripcion);
				cmdslist[1].Parameters.AddWithValue("@idUsuario", Sesion.idSesion);


				Methods.ExecuteNBasicCommand(cmdslist);
				Methods.GenerateLogsActivities(DateTime.Now, "Empleado Insertado: " + ", Usuario: " + user.NombreUsuario + ", Rol: " + user.Rol, Sesion.usuarioSesion);
			}
			catch (SqlException ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
		}
		/// <summary>
		/// Metodo Select UsuarioDAL recupera todos los usuarios activos 1
		/// </summary>
		/// <returns>DataTable</returns>
		public override DataTable Select()
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwEmpleadoSelect";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				res = Methods.ExecuteDataTableCommand(cmd);
			}
			catch (SqlException ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			return res;
		}
		/// <summary>
		/// Metodo Update UsuarioDAL actualiza datos del empleado
		/// </summary>
		public override void Update()
		{
			string query1 = "UPDATE Empleado SET nombres=@nombres,primerApellido=@primerApellido,segundoApellido=@segundoApellido,email=@email WHERE idEmpleado=@idEmpleado";
			string query2 = "INSERT INTO Auditoria(tabla,creaUpdDel,descripcion,idUsuario)VALUES(@tabla,@creaUpdDel,@descripcion,@idUsuario)";
			List<SqlCommand> cmdslist = new List<SqlCommand>();
			try
			{
				Methods.GenerateLogsActivities(DateTime.Now, "Inicio del Metodo Update de un Empleado" + ", Usuario: " + user.NombreUsuario + ", Rol: " + user.Rol, Sesion.usuarioSesion);

				List<string> querys = new List<string>();
				querys.Add(query1);
				querys.Add(query2);
				cmdslist = Methods.CreateNCommands(querys);

				cmdslist[0].Parameters.AddWithValue("@nombres", user.Nombres);
				cmdslist[0].Parameters.AddWithValue("@primerApellido", user.PrimerApellido);
				cmdslist[0].Parameters.AddWithValue("@segundoApellido", user.SegundoApellido);
				cmdslist[0].Parameters.AddWithValue("@email", user.Correo);
				cmdslist[0].Parameters.AddWithValue("@idEmpleado", user.IdUsuario);

				string tabla = "Empleado";
				char cr = 'U';
				string descripcion = "ID Empleado: " + user.IdUsuario + ", Se Modifico: " + user.Nombres+" "+user.PrimerApellido+" "+user.SegundoApellido+", Rol: "+user.Rol;
				cmdslist[1].Parameters.AddWithValue("@tabla", tabla);
				cmdslist[1].Parameters.AddWithValue("@creaUpdDel", cr);
				cmdslist[1].Parameters.AddWithValue("@descripcion", descripcion);
				cmdslist[1].Parameters.AddWithValue("@idUsuario", Sesion.idSesion);


				Methods.ExecuteNBasicCommand(cmdslist);
				Methods.GenerateLogsActivities(DateTime.Now, "Empleado Actualizado: " + ", Usuario: " + user.NombreUsuario + ", Rol: " + user.Rol, Sesion.usuarioSesion);

			}
			catch (SqlException ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
		}
		/// <summary>
		/// Metodo UpdateDatosPerfil actualiza datos del perfil del empleado
		/// </summary>
		public void UpdateDatosPerfil()
		{
			string query = "UPDATE Empleado SET nombres=@nombres,primerApellido=@primerApellido,segundoApellido=@segundoApellido,contrasenia=HASHBYTES('md5',@contrasenia) WHERE idEmpleado=@idEmpleado";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@nombres", user.Nombres);
				cmd.Parameters.AddWithValue("@primerApellido", user.PrimerApellido);
				cmd.Parameters.AddWithValue("@segundoApellido", user.SegundoApellido);
				cmd.Parameters.AddWithValue("@contrasenia", user.Contrasenia).SqlDbType = SqlDbType.VarChar;
				cmd.Parameters.AddWithValue("@idEmpleado", Sesion.idSesion);


				Methods.ExecuteBasicCommand(cmd);
			}
			catch (SqlException ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
		}
		/// <summary>
		/// Metodo UpdateContrasenias actualiza la contrasenia del usuario
		/// </summary>
		public void UpdateContrasenia()
		{
			string query = "UPDATE Empleado SET contrasenia=HASHBYTES('md5',@contrasenia),contraseniaInicial=0 WHERE usuario=@usuario";
			try
			{

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@contrasenia", user.Contrasenia).SqlDbType = SqlDbType.VarChar;
				cmd.Parameters.AddWithValue("@usuario", user.NombreUsuario);				
				Methods.ExecuteBasicCommand(cmd);

			}
			catch (SqlException ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
		}
		/// <summary>
		/// Metodo UpdateContraseniaRestablecida actualiza la contraseña cuando se restablece
		/// </summary>
		public void UpdateContraseniaRestablecida()
		{
			string query = "UPDATE Empleado SET contrasenia=HASHBYTES('md5',@contrasenia),contraseniaInicial=1 WHERE usuario=@usuario";
			try
			{

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@contrasenia", user.Contrasenia).SqlDbType = SqlDbType.VarChar;
				cmd.Parameters.AddWithValue("@usuario", user.NombreUsuario);
				Methods.ExecuteBasicCommand(cmd);


			}
			catch (SqlException ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
		}
		/// <summary>
		/// Metodo para restablecer la contraseña de un empleado a travez del administrador Usuario DAL
		/// </summary>
		public void UpdateContraseniaRestablecidaParaAdministrador()
		{
			string query = "UPDATE Empleado SET contrasenia=HASHBYTES('md5',@contrasenia),contraseniaInicial=1 WHERE idEmpleado=@idEmpleado";
			try
			{

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@contrasenia", user.Contrasenia).SqlDbType = SqlDbType.VarChar;
				cmd.Parameters.AddWithValue("@idEmpleado", user.IdUsuario);
				Methods.ExecuteBasicCommand(cmd);


			}
			catch (SqlException ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
		}
		/// <summary>
		/// Metodo Login Usuario DAL permite el ingreso al sistema
		/// </summary>
		/// <param name="usuario"></param>
		/// <param name="contrasenia"></param>
		/// <returns>DataTable</returns>
		public DataTable Login(string usuario, string contrasenia)
		{
			DataTable dt = new DataTable();
			string query = "SELECT idEmpleado, usuario,rolEmpleado,contraseniaInicial,nombres,primerApellido,segundoApellido,email FROM Empleado WHERE estadoEmpleado=1 AND usuario=@usuario AND contrasenia=HASHBYTES('md5',@contrasenia)";
			try
			{
				Methods.GenerateLogsActivities(DateTime.Now, "Inicio del Metodo Login de un Empleado", Sesion.usuarioSesion);
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@usuario", usuario);
				cmd.Parameters.AddWithValue("@contrasenia", contrasenia).SqlDbType=SqlDbType.VarChar;
				dt = Methods.ExecuteDataTableCommand(cmd);

				Methods.GenerateLogsActivities(DateTime.Now, "Login Aprobado: " + ", Usuario: " + usuario, Sesion.usuarioSesion);

			}
			catch (SqlException ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			return dt;
		}
		/// <summary>
		/// Metodo para verificar la existencia de un usuario habilitado en el sistema
		/// </summary>
		/// <param name="usuario"></param>
		/// <param name="correo"></param>
		/// <returns>DataTable</returns>
		public DataTable VerificarUser(string usuario)
		{
			DataTable dt = new DataTable();
			string query = "SELECT idEmpleado, usuario,rolEmpleado,contraseniaInicial,nombres,primerApellido,segundoApellido,email FROM Empleado WHERE estadoEmpleado=1 AND usuario=@usuario";
			try
			{

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@usuario", usuario);
				dt = Methods.ExecuteDataTableCommand(cmd);


			}
			catch (SqlException ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			return dt;
		}
		/// <summary>
		///  Metodo para que el administrador pueda restablecer la contraseña del empleado UsuarioDAL
		/// </summary>
		/// <param name="id"></param>
		/// <returns>DataTable</returns>
		public DataTable RestablecerContraseñaDesdeAdministrador(int id)
		{
			DataTable dt = new DataTable();
			string query = "SELECT idEmpleado, usuario,rolEmpleado,contraseniaInicial,nombres,primerApellido,segundoApellido,email FROM Empleado WHERE estadoEmpleado=1 AND idEmpleado=@idEmpleado";
			try
			{

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idEmpleado", id);
				dt = Methods.ExecuteDataTableCommand(cmd);


			}
			catch (SqlException ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			return dt;
		}
		
		/// <summary>
		/// Metodo RestablecerContrasenia UsuarioDAL 
		/// </summary>
		/// <param name="usuario"></param>
		/// <returns>DataTable</returns>
		public DataTable RestablecerContrasenia(string usuario)
		{

			DataTable dt = new DataTable();
			string query = "SELECT idEmpleado,usuario,rolEmpleado,contraseniaInicial,contrasenia FROM Empleado WHERE estadoEmpleado=1 AND usuario=@usuario";
			try
			{

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@usuario", usuario);
				dt = Methods.ExecuteDataTableCommand(cmd);


			}
			catch (SqlException ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			return dt;
		}
		/// <summary>
		/// Metodo Get UsuarioDAL recupera un Usuario mediante su id
		/// </summary>
		/// <param name="idUsuario"></param>
		/// <returns>Usuario</returns>
		public Usuario Get(int idUsuario)
		{
			Usuario res = null;
			SqlCommand cmd = null;
			SqlDataReader dr = null;
			string query = "SELECT idEmpleado,nombres,primerApellido,segundoApellido,sexo,estadoEmpleado,fechaHoraActualizacionEmpleado,usuario,contrasenia,rolEmpleado,contraseniaInicial,email,fechaRegistro FROM Empleado WHERE idEmpleado=@idEmpleado";
			try
			{

				cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idEmpleado", idUsuario);
				dr = Methods.ExecuteDataReaderCommand(cmd);

				while (dr.Read())
				{
					res = new Usuario(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), byte.Parse(dr[4].ToString()), byte.Parse(dr[5].ToString()),Convert.ToDateTime(dr[6].ToString()),dr[7].ToString(),dr[8].ToString(),dr[9].ToString(), byte.Parse(dr[10].ToString()),dr[11].ToString(), Convert.ToDateTime(dr[12].ToString()));
				}
			}
			catch (SqlException ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			finally
			{
				cmd.Connection.Close();
				dr.Close();
			}
			return res;
		}
		/// <summary>
		/// Metodo SelectBusquedaUsuarios permite la busqueda de empleados mediante texto
		/// </summary>
		/// <param name="texto"></param>
		/// <returns>DataTable</returns>
		public DataTable SelectBusquedaUsarios(string texto)
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwEmpleadoSelect ";
			query = query + " WHERE  [Nombre Completo] LIKE @texto ";
			try
			{

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@texto", "%" + texto + "%");
				res = Methods.ExecuteDataTableCommand(cmd);

			}
			catch (SqlException ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			return res;
		}


		#endregion;
	}
}