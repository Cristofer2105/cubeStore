using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace DAL
{
	/// <summary>
	/// Clase Methods DAL
	/// </summary>
	public sealed class Methods
	{
		/// <summary>
		/// Cadena de conexion obtenida del app config
		/// </summary>
		private static string connectionString = ConfigurationManager.ConnectionStrings["BDDConectionStrings"].ConnectionString;
		public static TraceSource dataSource = new TraceSource("DataSource");
		public static TraceSource errorSource = new TraceSource("ErrorSource");
		/// <summary>
		/// Metodo Get Connection MethodsD:\Univalle\Base de Datos 3\Proyecto\cubeStore\DAL\Methods.cs
		/// </summary>
		/// <returns>SqlConnection</returns>
		public static SqlConnection GetConnection()
		{
			SqlConnection connection = new SqlConnection(connectionString);
			return connection;
		}
		/// <summary>
		/// Metodo GetCurrentValueIDTable
		/// </summary>
		/// <param name="tabla"></param>
		/// <returns>int</returns>
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
		/// <summary>
		/// Metodo GetMaxIDTable
		/// </summary>
		/// <param name="id"></param>
		/// <param name="tabla"></param>
		/// <returns>int</returns>
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
		/// Crea n comandos para ejecutarlos despues recibiendo una lista de consultas
		/// </summary>
		/// <param name="lista"></param>
		/// <returns></returns>
		public static List<SqlCommand> CreateNCommands(List<string> lista)
		{
			List<SqlCommand> res = new List<SqlCommand>();
			try
			{
				SqlConnection connection = new SqlConnection(connectionString);
				for (int i = 0; i < lista.Count; i++)
				{
					SqlCommand cmd = new SqlCommand(lista[i]);
					cmd.Connection = connection;
					res.Add(cmd);
				}

				return res;
			}
			catch (Exception ex)
			{

				throw ex;
			}

		}

		/// <summary>
		/// Ejecuta n comandos en una transaccion
		/// </summary>
		/// <param name="cmds">lista de comandos a ejecutar</param>
		public static void ExecuteNBasicCommand(List<SqlCommand> cmds)
		{
			SqlTransaction tran = null;
			SqlCommand cmd1 = cmds[0];
			try
			{
				cmd1.Connection.Open();
				tran = cmd1.Connection.BeginTransaction();

				foreach (SqlCommand cmd in cmds)
				{
					cmd.Transaction = tran;
					cmd.ExecuteNonQuery();
				}

				tran.Commit();
			}
			catch (SqlException ex)
			{
				tran.Rollback();
				// WriteLogsRelease("MetodosSQL", "SqlException in ExecuteNBasicCommand", string.Format("{0} {1}", ex.Message, ex.StackTrace));
				throw new Exception("Se ha producido un error en el método ExecuteNBasicCommand(List<SqlCommand> cmds)", ex);
			}
			catch (Exception ex)
			{
				tran.Rollback();
				// WriteLogsRelease("MetodosSQL", "Exception in ExecuteNBasicCommand", string.Format("{0} {1}", ex.Message, ex.StackTrace));
				throw new Exception("Se ha producido un error en el método ExecuteNBasicCommand(List<SqlCommand> cmds)", ex);
			}
			finally
			{
				cmd1.Connection.Close();
			}
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

		#region log
		public static void GenerateLogsActivities(DateTime fecha, string mensaje,string usuario)
		{
			Trace.Listeners[0].WriteLine(string.Format("Fecha: {0} Info: {1} Usuario:{2}", fecha, mensaje, usuario));
			Trace.Flush();
		}
		public static void GenerateLogsErrors(DateTime fecha, string mensaje, string usuario)
		{
			Trace.Listeners[1].WriteLine(string.Format("Fecha: {0} Error: {1} Usuario: {2}", fecha, mensaje, usuario));
			Trace.Flush();
		}
		#endregion

	}
}
