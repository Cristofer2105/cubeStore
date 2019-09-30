using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
	public sealed class Methods
	{
		/// <summary>
		/// Cadena de conexion obtenida del app config
		/// </summary>
		private static string connectionString = ConfigurationManager.ConnectionStrings["BDDConectionStrings"].ConnectionString;
		#region Creacion de SqlCommanmd
		/// <summary>
		/// Crea un sqlCommand y relaciona a una conexion
		/// </summary>
		/// <returns>SqlCommand creado y relacionado</returns>
		public static SqlCommand CreateBasicCommand()
		{
			SqlConnection connection = new SqlConnection(connectionString);
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = connection;
			return cmd;
		}
		/// <summary>
		/// Crea N sqlCommand y retorna una lista con esos comandos
		/// </summary>
		/// <returns>SqlCommand creado y relacionado</returns>
		public static List<SqlCommand> CreateNBasicCommand(int n)
		{
			List<SqlCommand> res = new List<SqlCommand>();
			SqlConnection connection = new SqlConnection(connectionString);
			for (int i = 0; i < n; i++)
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = connection;
				cmd.CommandType = CommandType.Text;
				res.Add(cmd);
			}
			return res;
		}
		/// <summary>
		/// Crea un sqlCommand y relaciona a una conexion
		/// </summary>
		/// <param name="query">Una consulta sql</param>
		/// <returns>SqlCommand creado y relacionado</returns>
		public static SqlCommand CreateBasicCommand(string query)
		{
			SqlConnection connection = new SqlConnection(connectionString);
			SqlCommand cmd = new SqlCommand(query);
			cmd.Connection = connection;
			return cmd;
		}
		#endregion

		#region Ejecucion de SqlCommand

		public static void ExecuteBasicCommand(SqlCommand cmd)
		{
			try
			{
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				cmd.Connection.Close();
			}
		}

		public static void ExecuteBasicCommand(SqlCommand cmd, string query)
		{
			try
			{
				cmd.CommandText = query;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				cmd.Connection.Close();
			}
		}

		public static DataTable ExecuteDataTableCommand(SqlCommand cmd)
		{
			DataTable res = new DataTable();
			try
			{
				cmd.Connection.Open();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(res);
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				cmd.Connection.Close();
			}
			return res;
		}

		public static SqlDataReader ExecuteDataReaderCommand(SqlCommand cmd)
		{
			SqlDataReader res = null;
			try
			{
				cmd.Connection.Open();
				res = cmd.ExecuteReader();
			}
			catch (Exception ex)
			{

				throw ex;
			}
			
			return res;
		}
		#endregion
	}
}
