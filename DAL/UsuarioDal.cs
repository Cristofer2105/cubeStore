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
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idEmpleado", user.IdUsuario);
				Methods.ExecuteBasicCommand(cmd);
			}
			catch (Exception ex)
			{
				//Escribir Log
				throw ex;
			}
		}

		public override void Insert()
		{
			string query = "INSERT INTO Empleado(nombres,primerApellido,segundoApellido,sexo,usuario,contrasenia,rolEmpleado,email) VALUES(@nombres,@primerApellido,@segundoApellido,@sexo,@usuario,@contrasenia,@rolEmpleado,@email)";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@nombres", user.Nombres);
				cmd.Parameters.AddWithValue("@primerApellido", user.PrimerApellido);
				cmd.Parameters.AddWithValue("@segundoApellido", user.SegundoApellido);
				cmd.Parameters.AddWithValue("@sexo", user.Sexo);
				cmd.Parameters.AddWithValue("@usuario", user.NombreUsuario);
				cmd.Parameters.AddWithValue("@contrasenia", user.Contrasenia);
				cmd.Parameters.AddWithValue("@rolEmpleado", user.Rol);
				cmd.Parameters.AddWithValue("@email", user.Correo);
				Methods.ExecuteBasicCommand(cmd);
			}
			catch (Exception ex)
			{
				//Escribir Log
				throw ex;
			}
		}

		public override DataTable Select()
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwEmpleadoSelect";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				res = Methods.ExecuteDataTableCommand(cmd);
			}
			catch (Exception ex)
			{

				throw ex;
			}
			return res;
		}

		public override void Update()
		{
			string query = "UPDATE Empleado SET nombres=@nombres,primerApellido=@primerApellido,segundoApellido=@segundoApellido,email=@email WHERE idEmpleado=@idEmpleado";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@nombres", user.Nombres);
				cmd.Parameters.AddWithValue("@primerApellido", user.PrimerApellido);
				cmd.Parameters.AddWithValue("@segundoApellido", user.SegundoApellido);												
				cmd.Parameters.AddWithValue("@email", user.SegundoApellido);
				cmd.Parameters.AddWithValue("@idEmpleado", user.IdUsuario);

				Methods.ExecuteBasicCommand(cmd);
			}
			catch (Exception ex)
			{
				//Escribir Log
				throw ex;
			}
		}
		public DataTable Login(string usuario, string contrasenia)
		{
	
			DataTable dt = new DataTable();
			string query = "SELECT idEmpleado,usuario,rolEmpleado FROM Empleado WHERE estadoEmpleado=1 AND usuario=@usuario AND contrasenia=@contrasenia";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@usuario", usuario);
				cmd.Parameters.AddWithValue("@contrasenia", contrasenia);
				dt = Methods.ExecuteDataTableCommand(cmd);
				
			}
			catch (Exception ex)
			{

				throw ex;
			}
			return dt;
		}
		public Usuario Get(int idUsuario)
		{
			Usuario res = null;
			SqlCommand cmd = null;
			SqlDataReader dr = null;
			string query = "SELECT idEmpleado,nombres,primerApellido,segundoApellido,sexo,estadoEmpleado,fechaHoraActualizacionEmpleado,usuario,contrasenia,rolEmpleado,contraseniaInicial,email FROM Empleado WHERE idEmpleado=@idEmpleado";
			try
			{
				cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idEmpleado", idUsuario);
				dr = Methods.ExecuteDataReaderCommand(cmd);

				while (dr.Read())
				{
					res = new Usuario(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), byte.Parse(dr[4].ToString()), byte.Parse(dr[5].ToString()),Convert.ToDateTime(dr[6].ToString()),dr[7].ToString(),dr[8].ToString(),dr[9].ToString(), byte.Parse(dr[10].ToString()),dr[11].ToString());
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				cmd.Connection.Close();
				dr.Close();
			}
			return res;
		}
		#endregion;
	}
}