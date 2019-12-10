using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common;

namespace DAL
{
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
		public override void Delete()
		{
			string query = "UPDATE Empleado SET estadoEmpleado=0 WHERE idEmpleado = @idEmpleado";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo de eliminacion de un Usuario", DateTime.Now));
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idEmpleado", user.IdUsuario);
				Methods.ExecuteBasicCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Eliminado, Nombre Usuario: {1}, Usuario:{2}", DateTime.Now, user.NombreUsuario, Sesion.usuarioSesion));
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
		}

		public override void Insert()
		{
			string query = "INSERT INTO Empleado(nombres,primerApellido,segundoApellido,sexo,usuario,contrasenia,rolEmpleado,email,fechaRegistro) VALUES(@nombres,@primerApellido,@segundoApellido,@sexo,@usuario,HASHBYTES('md5',@contrasenia),@rolEmpleado,@email,@fechaRegistro)";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo de Insertar un Usuario", DateTime.Now));
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@nombres", user.Nombres);
				cmd.Parameters.AddWithValue("@primerApellido", user.PrimerApellido);
				cmd.Parameters.AddWithValue("@segundoApellido", user.SegundoApellido);
				cmd.Parameters.AddWithValue("@sexo", user.Sexo);
				cmd.Parameters.AddWithValue("@usuario", user.NombreUsuario);
				cmd.Parameters.AddWithValue("@contrasenia", user.Contrasenia).SqlDbType = SqlDbType.VarChar;
				cmd.Parameters.AddWithValue("@rolEmpleado", user.Rol);
				cmd.Parameters.AddWithValue("@email", user.Correo);
				cmd.Parameters.AddWithValue("@fechaRegistro", user.FechaRegistro);
				Methods.ExecuteBasicCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Insertado, Nombre Usuario: {1}, Usuario:{2}", DateTime.Now, user.NombreUsuario, Sesion.usuarioSesion));
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
		}

		public override DataTable Select()
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwEmpleadoSelect";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo de Select de Usuarios", DateTime.Now));
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				res = Methods.ExecuteDataTableCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registros Seleccionados, Usuario:{1}", DateTime.Now, Sesion.usuarioSesion));
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return res;
		}

		public override void Update()
		{
			string query = "UPDATE Empleado SET nombres=@nombres,primerApellido=@primerApellido,segundoApellido=@segundoApellido,email=@email WHERE idEmpleado=@idEmpleado";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo de Update de Usuarios", DateTime.Now));
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@nombres", user.Nombres);
				cmd.Parameters.AddWithValue("@primerApellido", user.PrimerApellido);
				cmd.Parameters.AddWithValue("@segundoApellido", user.SegundoApellido);												
				cmd.Parameters.AddWithValue("@email", user.SegundoApellido);
				cmd.Parameters.AddWithValue("@idEmpleado", user.IdUsuario);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Actualizado, Nombre Usuario: {1}, Usuario:{2}", DateTime.Now,user.NombreUsuario, Sesion.usuarioSesion));

				Methods.ExecuteBasicCommand(cmd);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
		}

		public void UpdateDatosPerfil()
		{
			string query = "UPDATE Empleado SET nombres=@nombres,primerApellido=@primerApellido,segundoApellido=@segundoApellido,contrasenia=HASHBYTES('md5',@contrasenia) WHERE idEmpleado=@idEmpleado";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo de Update de Perfil de Usuarios", DateTime.Now));
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@nombres", user.Nombres);
				cmd.Parameters.AddWithValue("@primerApellido", user.PrimerApellido);
				cmd.Parameters.AddWithValue("@segundoApellido", user.SegundoApellido);
				cmd.Parameters.AddWithValue("@contrasenia", user.Contrasenia).SqlDbType = SqlDbType.VarChar;
				cmd.Parameters.AddWithValue("@idEmpleado", Sesion.idSesion);

				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Actualizado, Nombre Usuario: {1}, Usuario:{2}", DateTime.Now, user.NombreUsuario, Sesion.usuarioSesion));

				Methods.ExecuteBasicCommand(cmd);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
		}
		public void UpdateContrasenia()
		{
			string query = "UPDATE Empleado SET contrasenia=HASHBYTES('md5',@contrasenia),contraseniaInicial=0 WHERE usuario=@usuario";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo de Update Contrasenia de Usuarios", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@contrasenia", user.Contrasenia).SqlDbType = SqlDbType.VarChar;
				cmd.Parameters.AddWithValue("@usuario", user.NombreUsuario);				
				Methods.ExecuteBasicCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Contrasenia Actualizada, Nombre Usuario: {1}, Usuario:{2}", DateTime.Now, user.NombreUsuario, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
		}
		public void UpdateContraseniaRestablecida()
		{
			string query = "UPDATE Empleado SET contrasenia=HASHBYTES('md5',@contrasenia),contraseniaInicial=1 WHERE usuario=@usuario";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo de Restablecer Contrasenia de Usuarios", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@contrasenia", user.Contrasenia).SqlDbType = SqlDbType.VarChar;
				cmd.Parameters.AddWithValue("@usuario", user.NombreUsuario);
				Methods.ExecuteBasicCommand(cmd);

				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Contrasenia Actualizada, Nombre Usuario: {1}, Usuario:{2}", DateTime.Now, user.NombreUsuario, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
		}
		public DataTable Login(string usuario, string contrasenia)
		{
			DataTable dt = new DataTable();
			string query = "SELECT idEmpleado, usuario,rolEmpleado,contraseniaInicial,nombres,primerApellido,segundoApellido FROM Empleado WHERE estadoEmpleado=1 AND usuario=@usuario AND contrasenia=HASHBYTES('md5',@contrasenia)";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Login de Usuarios", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@usuario", usuario);
				cmd.Parameters.AddWithValue("@contrasenia", contrasenia).SqlDbType=SqlDbType.VarChar;
				dt = Methods.ExecuteDataTableCommand(cmd);

				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Login realizado, Nombre Usuario: {1}, Usuario:{2}", DateTime.Now, user.NombreUsuario, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return dt;
		}
		public DataTable VerificarUser(string usuario, string correo)
		{
			DataTable dt = new DataTable();
			string query = "SELECT idEmpleado, usuario,rolEmpleado,contraseniaInicial,nombres,primerApellido,segundoApellido FROM Empleado WHERE estadoEmpleado=1 AND usuario=@usuario AND email=@email";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo verificar Usuarios", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@usuario", usuario);
				cmd.Parameters.AddWithValue("@email", correo);
				dt = Methods.ExecuteDataTableCommand(cmd);

				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Login realizado, Nombre Usuario: {1}, Usuario:{2}", DateTime.Now, user.NombreUsuario, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return dt;
		}
		public DataTable RestablecerContrasenia(string usuario)
		{

			DataTable dt = new DataTable();
			string query = "SELECT idEmpleado,usuario,rolEmpleado,contraseniaInicial,contrasenia FROM Empleado WHERE estadoEmpleado=1 AND usuario=@usuario";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Restablecer Contrasenia de Usuarios", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@usuario", usuario);
				dt = Methods.ExecuteDataTableCommand(cmd);

				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Restablecer Contrasenia Realizado, Nombre Usuario: {1}, Usuario:{2}", DateTime.Now, user.NombreUsuario, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return dt;
		}
		public Usuario Get(int idUsuario)
		{
			Usuario res = null;
			SqlCommand cmd = null;
			SqlDataReader dr = null;
			string query = "SELECT idEmpleado,nombres,primerApellido,segundoApellido,sexo,estadoEmpleado,fechaHoraActualizacionEmpleado,usuario,contrasenia,rolEmpleado,contraseniaInicial,email,fechaRegistro FROM Empleado WHERE idEmpleado=@idEmpleado";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Get de Usuarios", DateTime.Now));

				cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idEmpleado", idUsuario);
				dr = Methods.ExecuteDataReaderCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Get Usuarios Realizado, Usuario:{1}", DateTime.Now, Sesion.usuarioSesion));

				while (dr.Read())
				{
					res = new Usuario(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), byte.Parse(dr[4].ToString()), byte.Parse(dr[5].ToString()),Convert.ToDateTime(dr[6].ToString()),dr[7].ToString(),dr[8].ToString(),dr[9].ToString(), byte.Parse(dr[10].ToString()),dr[11].ToString(), Convert.ToDateTime(dr[12].ToString()));
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			finally
			{
				cmd.Connection.Close();
				dr.Close();
			}
			return res;
		}
		
		public DataTable SelectBusquedaUsarios(string texto)
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwEmpleadoSelect ";
			query = query + " WHERE  [Nombre Completo] LIKE @texto ";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Busqueda de Articulo", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@texto", "%" + texto + "%");
				res = Methods.ExecuteDataTableCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Buscado, Usuario:{1}", DateTime.Now, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return res;
		}
		#endregion;
	}
}