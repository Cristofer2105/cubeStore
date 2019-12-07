using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DAL
{
	public class SesionDAL
	{
		#region Atributos Propiedades y Constructores de clase
		private Session ses;
		
		public Session Ses
		{
			get { return ses; }
			set { ses = value; }
		}
		public SesionDAL()
		{

		}
		public SesionDAL(Session ses)
		{
			this.ses = ses;
		}

		#endregion
		#region metodos
		public void Insert()
		{
			string query = "INSERT INTO Session(fecha,idEmpleado) VALUES(@fecha,@idEmpleado)";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@fecha", ses.Fecha);
				cmd.Parameters.AddWithValue("@idEmpleado", ses.IdEmpleado);
				Methods.ExecuteBasicCommand(cmd);
			}
			catch (Exception ex)
			{
				//Escribir Log
				throw ex;
			}
		}
		#endregion
	}
}
