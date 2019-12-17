using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common;

namespace DAL
{
	/// <summary>
	/// Clase ClienteDAL
	/// </summary>
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
		/// Metodo Delete ClienteDAL cambia el estado de un cliente a inactivo 0
		/// </summary>
		public override void Delete()
		{
			string query1 = "UPDATE Cliente SET estadoCliente=0 , fechaHoraActualizacionCliente=CURRENT_TIMESTAMP WHERE idCliente = @idCliente";
			string query2 = "INSERT INTO Auditoria(tabla,creaUpdDel,descripcion,idUsuario)VALUES(@tabla,@creaUpdDel,@descripcion,@idUsuario)";
			List<SqlCommand> cmdslist = new List<SqlCommand>();

			try
			{
				Methods.GenerateLogsActivities(DateTime.Now, "Inicio del Metodo Delete de un Cliente" + ", Cliente: " + cli.Nombres+" "+cli.PrimerApellido+" "+cli.SegundoApellido, Sesion.usuarioSesion);

				List<string> querys = new List<string>();
				querys.Add(query1);
				querys.Add(query2);
				cmdslist = Methods.CreateNCommands(querys);

				cmdslist[0].Parameters.AddWithValue("@idCliente", cli.IdCliente);

				string tabla = "Cliente";
				char cr = 'D';
				string descripcion = "ID Cliente: " + cli.IdCliente + ", Se Elimino: " + cli.Nombres+" "+cli.PrimerApellido +" "+cli.SegundoApellido+ ", estadoCliente=0";
				cmdslist[1].Parameters.AddWithValue("@tabla", tabla);
				cmdslist[1].Parameters.AddWithValue("@creaUpdDel", cr);
				cmdslist[1].Parameters.AddWithValue("@descripcion", descripcion);
				cmdslist[1].Parameters.AddWithValue("@idUsuario", Sesion.idSesion);


				Methods.ExecuteNBasicCommand(cmdslist);

				Methods.GenerateLogsActivities(DateTime.Now, "Cliente Eliminado: " + ", Cliente: " + cli.Nombres + " " + cli.PrimerApellido + " " + cli.SegundoApellido, Sesion.usuarioSesion);

			}
			catch (SqlException ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
		}
		/// <summary>
		/// Metodo Insert ClienteDAL inserta un nuevo cliente
		/// </summary>
		public override void Insert()
		{
			string query1 = "INSERT INTO Cliente(nombres,primerApellido,segundoApellido,fechaHoraRegistro) VALUES(@nombres,@primerApellido,@segundoApellido,@fechaHoraRegistro)";
			string query2 = "INSERT INTO Auditoria(tabla,creaUpdDel,descripcion,idUsuario)VALUES(@tabla,@creaUpdDel,@descripcion,@idUsuario)";
			List<SqlCommand> cmdslist = new List<SqlCommand>();
			try
			{
				Methods.GenerateLogsActivities(DateTime.Now, "Inicio del Metodo Insert de un Cliente" + ", Cliente: " + cli.Nombres + " " + cli.PrimerApellido + " " + cli.SegundoApellido, Sesion.usuarioSesion);


				List<string> querys = new List<string>();
				querys.Add(query1);
				querys.Add(query2);

				cmdslist = Methods.CreateNCommands(querys);
				cmdslist[0].Parameters.AddWithValue("@nombres", cli.Nombres);
				cmdslist[0].Parameters.AddWithValue("@primerApellido", cli.PrimerApellido);
				cmdslist[0].Parameters.AddWithValue("@segundoApellido", cli.SegundoApellido);
				cmdslist[0].Parameters.AddWithValue("@fechaHoraRegistro", cli.FechaHoraRegistro);

				int idCli = Methods.GetCurrentValueIDTable("Cliente");
				string tabla = "Cliente";
				char cr = 'C';
				string descripcion = "ID Cliente: " + idCli + ", Se agrego: " + cli.Nombres + " " + cli.PrimerApellido + " " + cli.SegundoApellido;
				cmdslist[1].Parameters.AddWithValue("@tabla", tabla);
				cmdslist[1].Parameters.AddWithValue("@creaUpdDel", cr);
				cmdslist[1].Parameters.AddWithValue("@descripcion", descripcion);
				cmdslist[1].Parameters.AddWithValue("@idUsuario", Sesion.idSesion);


				Methods.ExecuteNBasicCommand(cmdslist);

				Methods.GenerateLogsActivities(DateTime.Now, "Cliente Insertado: " + ", Cliente: " + cli.Nombres + " " + cli.PrimerApellido + " " + cli.SegundoApellido, Sesion.usuarioSesion);

			}
			catch (SqlException ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
		}
		/// <summary>
		/// Metodo Select ClienteDAL recupera todos los clientes activos
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
			catch (SqlException ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			return res;
		}
		/// <summary>
		/// Metodo Update ClienteDAL actualiza datos del cliente
		/// </summary>
		public override void Update()
		{
			string query1 = "UPDATE Cliente SET nombres=@nombres,primerApellido=@primerApellido,segundoApellido=@segundoApellido,fechaHoraActualizacionCliente=CURRENT_TIMESTAMP WHERE idCliente = @idCliente";
			string query2 = "INSERT INTO Auditoria(tabla,creaUpdDel,descripcion,idUsuario)VALUES(@tabla,@creaUpdDel,@descripcion,@idUsuario)";
			List<SqlCommand> cmdslist = new List<SqlCommand>();

			try
			{
				Methods.GenerateLogsActivities(DateTime.Now, "Inicio del Metodo Update de un Cliente" + ", Cliente: " + cli.Nombres + " " + cli.PrimerApellido + " " + cli.SegundoApellido, Sesion.usuarioSesion);

				List<string> querys = new List<string>();
				querys.Add(query1);
				querys.Add(query2);
				cmdslist = Methods.CreateNCommands(querys);

				cmdslist[0].Parameters.AddWithValue("@nombres", cli.Nombres);
				cmdslist[0].Parameters.AddWithValue("@primerApellido", cli.PrimerApellido);
				cmdslist[0].Parameters.AddWithValue("@segundoApellido", cli.SegundoApellido);
				cmdslist[0].Parameters.AddWithValue("@idCliente", cli.IdCliente);

				string tabla = "Cliente";
				char cr = 'U';
				string descripcion = "ID Cliente: " + cli.IdCliente + ", Se Modifico: " + cli.Nombres + " " + cli.PrimerApellido + " " + cli.SegundoApellido;
				cmdslist[1].Parameters.AddWithValue("@tabla", tabla);
				cmdslist[1].Parameters.AddWithValue("@creaUpdDel", cr);
				cmdslist[1].Parameters.AddWithValue("@descripcion", descripcion);
				cmdslist[1].Parameters.AddWithValue("@idUsuario", Sesion.idSesion);


				Methods.ExecuteNBasicCommand(cmdslist);

				Methods.GenerateLogsActivities(DateTime.Now, "Cliente Actualizado: " + ", Cliente: " + cli.Nombres + " " + cli.PrimerApellido + " " + cli.SegundoApellido, Sesion.usuarioSesion);

			}
			catch (SqlException ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
		}
		/// <summary>
		/// Metodo Get ClienteDAL recupera un Cliente mediante el id del Cliente
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Cliente</returns>
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
			catch (SqlException ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			finally
			{
				cmd.Connection.Close();
				dr.Close();
			}
			return res;
		}
		/// <summary>
		/// Metodo SelectClientesBusquedaDAL permite la busqueda de un Cliente mediante texto
		/// </summary>
		/// <param name="texto"></param>
		/// <returns>DataTable</returns>
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
			catch (SqlException ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			return res;
		}
		#endregion
	}
}