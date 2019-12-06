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
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				dt = Methods.ExecuteDataTableCommand(cmd);

			}
			catch (Exception ex)
			{

				throw ex;
			}
			return dt;
		}
	}
}