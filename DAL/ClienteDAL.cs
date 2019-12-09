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
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Delete de un Cliente", DateTime.Now));
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idCliente", cli.IdCliente);
				Methods.ExecuteBasicCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Eliminado, Nombre Cliente: {1}, Usuario:{2}", DateTime.Now, cli.Nombres+" "+cli.PrimerApellido+" "+cli.SegundoApellido, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
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
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Insert de un Cliente", DateTime.Now));
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@nombres", cli.Nombres);
				cmd.Parameters.AddWithValue("@primerApellido", cli.PrimerApellido);
				cmd.Parameters.AddWithValue("@segundoApellido", cli.SegundoApellido);
				cmd.Parameters.AddWithValue("@fechaHoraRegistro", cli.FechaHoraRegistro);
				Methods.ExecuteBasicCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Insertado, Nombre Cliente: {1}, Usuario:{2}", DateTime.Now, cli.Nombres + " " + cli.PrimerApellido + " " + cli.SegundoApellido, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
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
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Select de Clientes", DateTime.Now));
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				res = Methods.ExecuteDataTableCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registros seleccionados Usuario:{1}", DateTime.Now, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
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
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Update de un Cliente", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@nombres", cli.Nombres);
				cmd.Parameters.AddWithValue("@primerApellido", cli.PrimerApellido);
				cmd.Parameters.AddWithValue("@segundoApellido", cli.SegundoApellido);
				cmd.Parameters.AddWithValue("@idCliente", cli.IdCliente);
				Methods.ExecuteBasicCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registros Actualizado Nombre Cliente: {1} Usuario:{2}", DateTime.Now, cli.Nombres + " " + cli.PrimerApellido + " " + cli.SegundoApellido, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
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
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Get de un Cliente", DateTime.Now));

				cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idCliente", id);
				dr = Methods.ExecuteDataReaderCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Conseguido Usuario:{1}", DateTime.Now, Sesion.usuarioSesion));

				while (dr.Read())
				{
					res = new Cliente(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), byte.Parse(dr[4].ToString()), DateTime.Parse(dr[5].ToString()), DateTime.Parse(dr[6].ToString()));
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
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
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Select Busqueda de Clientes", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@texto", "%" + texto + "%");
				res = Methods.ExecuteDataTableCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Buscado Usuario:{1}", DateTime.Now, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return res;
		}
		#endregion
	}
}