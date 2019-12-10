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

		public static SqlConnection GetConnection()
		{
			SqlConnection connection = new SqlConnection(connectionString);
			return connection;
		}

		public static int GetCurrentValueIDTable(string tabla)
		{
			int res = -1;
			string query= "SELECT IDENT_CURRENT('"+tabla+"') + IDENT_INCR('"+tabla+"')";
			try
			{
				SqlCommand cmd = CreateBasicCommand(query);
				res=int.Parse(ExecuteScalarCommand(cmd));
			}
			catch (Exception)
			{

				throw;
			}
			
			return res;
		}
		public static int GetMaxIDTable(string id,string tabla)
		{
			int res = -1;
			string query = "SELECT MAX("+id+") FROM " + tabla;
			try
			{
				SqlCommand cmd = CreateBasicCommand(query);
				res = int.Parse(ExecuteScalarCommand(cmd));
			}
			catch (Exception)
			{

				throw;
			}

			return res;
		}
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
		public static string ExecuteScalarCommand(SqlCommand cmd)
		{
			try
			{
				cmd.Connection.Open();
				return cmd.ExecuteScalar().ToString();
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
		public static void Execute4BasicCommand(SqlCommand cmd1,SqlCommand cmd2, SqlCommand cmd3, SqlCommand cmd4)
		{
			SqlTransaction tran = null;
			try
			{
				cmd1.Connection.Open();
				tran = cmd1.Connection.BeginTransaction();

				cmd1.Transaction = tran;
				cmd1.ExecuteNonQuery();

				cmd2.Transaction = tran;
				cmd2.ExecuteNonQuery();

				cmd3.Transaction = tran;
				cmd3.ExecuteNonQuery();

				cmd4.Transaction = tran;
				cmd4.ExecuteNonQuery();

				tran.Commit();
			}
			catch (Exception ex)
			{
				tran.Rollback();
				throw ex;
			}
			finally
			{
				cmd1.Connection.Close();
			}
		}
		public static void Execute1BasicCommand(SqlCommand cmd1)
		{
			SqlTransaction tran = null;
			try
			{
				cmd1.Connection.Open();
				tran = cmd1.Connection.BeginTransaction();

				cmd1.Transaction = tran;
				cmd1.ExecuteNonQuery();

				tran.Commit();
			}
			catch (Exception ex)
			{
				tran.Rollback();
				throw ex;
			}
			finally
			{
				cmd1.Connection.Close();
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
