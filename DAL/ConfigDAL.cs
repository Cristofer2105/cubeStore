using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
	public sealed class ConfigDAL
	{
		public DataTable Select()
		{
			DataTable dt = new DataTable();
			string query = "SELECT pathImagen FROM Config";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Login de Usuarios", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				dt = Methods.ExecuteDataTableCommand(cmd);


			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return dt;
		}
	}
}