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
			string query = "INSERT INTO Empleado(nombres,primerApellido,segundoApellido,sexo,telefonosEmpleado,usuario,contrasenia,rolEmpleado,email) VALUES(@nombres,@primerApellido,@segundoApellido,@sexo,@telefonosEmpleado,@usuario,@contrasenia,@rolEmpleado,@email)";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@nombres", user.Nombres);
				cmd.Parameters.AddWithValue("@primerApellido", user.PrimerApellido);
				cmd.Parameters.AddWithValue("@segundoApellido", user.SegundoApellido);
				cmd.Parameters.AddWithValue("@sexo", user.Sexo);
				cmd.Parameters.AddWithValue("@telefonosEmpleado", user.Telefonos);
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
			throw new NotImplementedException();
		}

		public override void Update()
		{
			string query = "UPDATE Empleado SET nombres=@nombres,primerApellido=@primerApellido,segundoApellido=@segundoApellido,sexo=@sexo,telefonosEmpleado=@telefonosEmpleado,usuario=@usuario,contrasenia=@contrasenia,rolEmpleado=@rolEmpleado,email=@email WHERE idEmpleado=@idEmpleado";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@nombres", user.Nombres);
				cmd.Parameters.AddWithValue("@primerApellido", user.PrimerApellido);
				cmd.Parameters.AddWithValue("@segundoApellido", user.SegundoApellido);
				cmd.Parameters.AddWithValue("@sexo", user.Sexo);
				cmd.Parameters.AddWithValue("@telefonosEmpleado", user.Telefonos);
				cmd.Parameters.AddWithValue("@usuario", user.NombreUsuario);
				cmd.Parameters.AddWithValue("@contrasenia", user.Contrasenia);
				cmd.Parameters.AddWithValue("@rolEmpleado", user.Rol);
				cmd.Parameters.AddWithValue("@email", user.Correo);
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
		#endregion;
	}
}