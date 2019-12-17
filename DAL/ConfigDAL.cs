using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
	/// <summary>
	/// Clase ConfigDAL
	/// </summary>
	public sealed class ConfigDAL
	{
		/// <summary>
		/// Metodo Select ConfigDAL
		/// </summary>
		/// <returns>DataTable</returns>
		public DataTable Select()
		{
			DataTable dt = new DataTable();
			string query = "SELECT pathImagen FROM Config";
			try
			{

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				dt = Methods.ExecuteDataTableCommand(cmd);


			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			return dt;
		}
	}
}