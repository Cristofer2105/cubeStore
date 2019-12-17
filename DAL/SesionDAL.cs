using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DAL
{
	/// <summary>
	/// Clase SessionDAL
	/// </summary>
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
			/// <summary>
			/// Metodo Insert para insertar la sesion de un empleado
			/// </summary>
			public void Insert()
			{
				string query = "INSERT INTO Session(inicioSesion,idEmpleado) VALUES(@inicioSesion,@idEmpleado)";
				try
				{
					Methods.GenerateLogsActivities(DateTime.Now, "Inicio del Metodo Insert de una Session", Sesion.usuarioSesion);
					SqlCommand cmd = Methods.CreateBasicCommand(query);
					cmd.Parameters.AddWithValue("@inicioSesion", ses.InicioSesion);
					cmd.Parameters.AddWithValue("@idEmpleado", ses.IdEmpleado);
					Methods.ExecuteBasicCommand(cmd);
					Methods.GenerateLogsActivities(DateTime.Now, "Session Insertado: " + ", Session: " + ses.InicioSesion, Sesion.usuarioSesion);

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
		#endregion
	}		
}
