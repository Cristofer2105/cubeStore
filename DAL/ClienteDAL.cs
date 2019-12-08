using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common;

namespace DAL
{
	public class ClienteDAL : AbstractDAL
	{
		#region Atributos Propiedades y Constructores de clase
		private Cliente cli;

		public Cliente Cli
		{
			get { return cli; }
			set { cli = value; }
		}
		public ClienteDAL()
		{

		}
		public ClienteDAL(Cliente cli)
		{
			this.cli = cli;
		}
		#endregion
		#region metodos de la clase
		/// <summary>
		/// metodo que elimina un cliente
		/// </summary>
		public override void Delete()
		{
			string query = "UPDATE Cliente SET estadoCliente=0 , fechaHoraActualizacionCliente=CURRENT_TIMESTAMP WHERE idCliente = @idCliente";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idCliente", cli.IdCliente);
				Methods.ExecuteBasicCommand(cmd);
			}
			catch (Exception ex)
			{
				//Escribir Log
				throw ex;
			}
		}
		/// <summary>
		/// Metodo que inserta un cliente
		/// </summary>
		public override void Insert()
		{
			string query = "INSERT INTO Cliente(nombres,primerApellido,segundoApellido,fechaHoraRegistro) VALUES(@nombres,@primerApellido,@segundoApellido,@fechaHoraRegistro)";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@nombres", cli.Nombres);
				cmd.Parameters.AddWithValue("@primerApellido", cli.PrimerApellido);
				cmd.Parameters.AddWithValue("@segundoApellido", cli.SegundoApellido);
				cmd.Parameters.AddWithValue("@fechaHoraRegistro", cli.FechaHoraRegistro);
				Methods.ExecuteBasicCommand(cmd);
			}
			catch (Exception ex)
			{
				//Escribir Log
				throw ex;
			}
		}
		/// <summary>
		/// Metodo que selecciona datos de cliente
		/// </summary>
		/// <returns>DataTable</returns>
		public override DataTable Select()
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwClientsSel ORDER BY 2";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				res = Methods.ExecuteDataTableCommand(cmd);
			}
			catch (Exception ex)
			{

				throw ex;
			}
			return res;
		}
		/// <summary>
		/// Metodo para actualizar cliente
		/// </summary>
		public override void Update()
		{
			string query = "UPDATE Cliente SET nombres=@nombres,primerApellido=@primerApellido,segundoApellido=@segundoApellido,fechaHoraActualizacionCliente=CURRENT_TIMESTAMP WHERE idCliente = @idCliente";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@nombres", cli.Nombres);
				cmd.Parameters.AddWithValue("@primerApellido", cli.PrimerApellido);
				cmd.Parameters.AddWithValue("@segundoApellido", cli.SegundoApellido);
				cmd.Parameters.AddWithValue("@idCliente", cli.IdCliente);
				Methods.ExecuteBasicCommand(cmd);
			}
			catch (Exception ex)
			{
				//Escribir Log
				throw ex;
			}
		}
		public Cliente Get(int id)
		{
			Cliente res = null;
			SqlCommand cmd = null;
			SqlDataReader dr = null;
			string query = "SELECT idCliente,nombres,primerApellido,segundoApellido,estadoCliente,fechaHoraActualizacionCliente,fechaHoraRegistro FROM Cliente WHERE idCliente=@idCliente";
			try
			{
				cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idCliente", id);
				dr = Methods.ExecuteDataReaderCommand(cmd);

				while (dr.Read())
				{
					res = new Cliente(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), byte.Parse(dr[4].ToString()), DateTime.Parse(dr[5].ToString()), DateTime.Parse(dr[6].ToString()));
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				cmd.Connection.Close();
				dr.Close();
			}
			return res;
		}
		public DataTable SelectClientesBusqueda(string texto)
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwClientsBusqSelect ";
			query = query + " WHERE Clientes LIKE @texto";
			query = query + " ORDER BY 3 DESC ";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@texto", "%" + texto + "%");
				res = Methods.ExecuteDataTableCommand(cmd);
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