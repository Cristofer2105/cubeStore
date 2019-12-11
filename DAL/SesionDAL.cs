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
		/// Metodo Insert Session
		/// </summary>
		public void Insert()
		{
			string query = "INSERT INTO Session(inicioSesion,idEmpleado) VALUES(@inicioSesion,@idEmpleado)";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Insert Session", DateTime.Now));
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@inicioSesion", ses.InicioSesion);
				cmd.Parameters.AddWithValue("@idEmpleado", ses.IdEmpleado);
				Methods.ExecuteBasicCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Fin del metodo Insert Session", DateTime.Now));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
		}
		}
		#endregion
	}
