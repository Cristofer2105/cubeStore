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
		/// <summary>
		/// Metodo insert sesion
		/// </summary>
		public void Insert()
		{
			string query = "INSERT INTO Session(inicioSesion,idEmpleado) VALUES(@inicioSesion,@idEmpleado)";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@inicioSesion", ses.InicioSesion);
				cmd.Parameters.AddWithValue("@idEmpleado", ses.IdEmpleado);
				Methods.ExecuteBasicCommand(cmd);
			}
			catch (Exception ex)
			{
				//Escribir Log
				throw ex;
			}
		}
		}
		#endregion
	}
