using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
	public class UsuarioDal : AbstractDAL
	{
		public UsuarioDal()
		{

		}
		#region metodos de la clase
		public override void Delete()
		{
			throw new NotImplementedException();
		}

		public override void Insert()
		{
			throw new NotImplementedException();
		}

		public override DataTable Select()
		{
			throw new NotImplementedException();
		}

		public override void Update()
		{
			throw new NotImplementedException();
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