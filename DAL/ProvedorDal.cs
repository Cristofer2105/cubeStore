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
	/// Clase ProvedorDAL
	/// </summary>
	public class ProvedorDal : AbstractDAL
	{
		private Provedor prov;

		public Provedor Prov
		{
			get { return prov; }
			set { prov = value; }
		}
		public ProvedorDal()
		{

		}
		public ProvedorDal(Provedor prov)
		{
			this.prov = prov;
		}
		/// <summary>
		/// Metodo Delete ProvedorDAL cambia el estado de un Provedor a inactivo 0
		/// </summary>
		public override void Delete()
		{
			string query1 = "UPDATE Provedor SET estadoProvedor=0 , fechaHoraActualizacionProvedor=CURRENT_TIMESTAMP WHERE idProvedor = @idProvedor";
			string query2 = "INSERT INTO Auditoria(tabla,creaUpdDel,descripcion,idUsuario)VALUES(@tabla,@creaUpdDel,@descripcion,@idUsuario)";
			List<SqlCommand> cmdslist = new List<SqlCommand>();
			try
			{
				Methods.GenerateLogsActivities(DateTime.Now, "Inicio del Metodo Delete de un Provedor" + ", Provedor: " + prov.RazonSocial, Sesion.usuarioSesion);
				List<string> querys = new List<string>();
				querys.Add(query1);
				querys.Add(query2);
				cmdslist = Methods.CreateNCommands(querys);

				cmdslist[0].Parameters.AddWithValue("@idProvedor", prov.IdProvedor);

				string tabla = "Provedor";
				char cr = 'D';
				string descripcion = "ID Provedor: " + prov.IdProvedor + ", Se Elimino: " + prov.RazonSocial + ", estadoProvedor=0";

				cmdslist[1].Parameters.AddWithValue("@tabla", tabla);
				cmdslist[1].Parameters.AddWithValue("@creaUpdDel", cr);
				cmdslist[1].Parameters.AddWithValue("@descripcion", descripcion);
				cmdslist[1].Parameters.AddWithValue("@idUsuario", Sesion.idSesion);


				Methods.ExecuteNBasicCommand(cmdslist);

				Methods.GenerateLogsActivities(DateTime.Now, "Provedor Eliminado: " + ", Provedor: " + prov.RazonSocial, Sesion.usuarioSesion);

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
		/// Metodo Insert ProvedorDAL inserta un nuevo Provedor
		/// </summary>
		public override void Insert()
		{
			string query1 = "INSERT INTO Provedor(razonSocialProvedor,latitud,longitud,fechaRegistro) VALUES(@razonSocialProvedor,@latitud,@longitud,@fechaRegistro)";
			string query2 = "INSERT INTO Auditoria(tabla,creaUpdDel,descripcion,idUsuario)VALUES(@tabla,@creaUpdDel,@descripcion,@idUsuario)";
			List<SqlCommand> cmdslist = new List<SqlCommand>();
			try
			{
				Methods.GenerateLogsActivities(DateTime.Now, "Inicio del Metodo Insert de un Provedor" + ", Provedor: " + prov.RazonSocial, Sesion.usuarioSesion);
				List<string> querys = new List<string>();
				querys.Add(query1);
				querys.Add(query2);
				cmdslist = Methods.CreateNCommands(querys);

				cmdslist[0].Parameters.AddWithValue("@razonSocialProvedor", prov.RazonSocial);
				cmdslist[0].Parameters.AddWithValue("@latitud", prov.Latitud);
				cmdslist[0].Parameters.AddWithValue("@longitud", prov.Longitud);
				cmdslist[0].Parameters.AddWithValue("@fechaRegistro", prov.FechaHoraRegistro);

				int idPro = Methods.GetCurrentValueIDTable("Provedor");
				string tabla = "Provedor";
				char cr = 'C';
				string descripcion = "ID Provedor: " + idPro + ", Se agrego: " + prov.RazonSocial;
				cmdslist[1].Parameters.AddWithValue("@tabla", tabla);
				cmdslist[1].Parameters.AddWithValue("@creaUpdDel", cr);
				cmdslist[1].Parameters.AddWithValue("@descripcion", descripcion);
				cmdslist[1].Parameters.AddWithValue("@idUsuario", Sesion.idSesion);


				Methods.ExecuteNBasicCommand(cmdslist);
				Methods.GenerateLogsActivities(DateTime.Now, "Provedor Insertado: " + ", Provedor: " + prov.RazonSocial, Sesion.usuarioSesion);

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
		/// Metodo Select ProvedorDAL recupera todos los provedores Activos 1
		/// </summary>
		/// <returns>DataTable</returns>
		public override DataTable Select()
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwProvedorSelect";
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
		/// Metodo SelectTodo ProvedorDAL recupera todos los provedores
		/// </summary>
		/// <returns>DataTable</returns>
		public DataTable SelectTodo()
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwProvedorSelectTodo";
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
		/// Metodo Update ProvedorDAL actualiza los datos de un Provedor
		/// </summary>
		public override void Update()
		{
			string query1 = "UPDATE Provedor SET razonSocialProvedor=@razonSocialProvedor,latitud=@latitud,longitud=@longitud,fechaHoraActualizacionProvedor=CURRENT_TIMESTAMP WHERE idProvedor = @idProvedor";
			string query2 = "INSERT INTO Auditoria(tabla,creaUpdDel,descripcion,idUsuario)VALUES(@tabla,@creaUpdDel,@descripcion,@idUsuario)";
			List<SqlCommand> cmdslist = new List<SqlCommand>();
			try
			{
				Methods.GenerateLogsActivities(DateTime.Now, "Inicio del Metodo Update de un Provedor" + ", Provedor: " + prov.RazonSocial, Sesion.usuarioSesion);

				List<string> querys = new List<string>();
				querys.Add(query1);
				querys.Add(query2);
				cmdslist = Methods.CreateNCommands(querys);

				cmdslist[0].Parameters.AddWithValue("@idProvedor", prov.IdProvedor);
				cmdslist[0].Parameters.AddWithValue("@razonSocialProvedor", prov.RazonSocial);
				cmdslist[0].Parameters.AddWithValue("@latitud", prov.Latitud);
				cmdslist[0].Parameters.AddWithValue("@longitud", prov.Longitud);

				string tabla = "Provedor";
				char cr = 'U';
				string descripcion = "ID Provedor: " + prov.IdProvedor + ", Se Modifico: " + prov.RazonSocial;
				cmdslist[1].Parameters.AddWithValue("@tabla", tabla);
				cmdslist[1].Parameters.AddWithValue("@creaUpdDel", cr);
				cmdslist[1].Parameters.AddWithValue("@descripcion", descripcion);
				cmdslist[1].Parameters.AddWithValue("@idUsuario", Sesion.idSesion);


				Methods.ExecuteNBasicCommand(cmdslist);
				Methods.GenerateLogsActivities(DateTime.Now, "Provedor Actualizado: " + ", Provedor: " + prov.RazonSocial, Sesion.usuarioSesion);
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
		/// Metodo Get ProvedorDAL recupera un Provedor mediante su id
		/// </summary>
		/// <param name="idProvedor"></param>
		/// <returns>Provedor</returns>
		public Provedor Get(int idProvedor)
		{
			Provedor res = null;
			SqlCommand cmd = null;
			SqlDataReader dr = null;
			string query = "SELECT idProvedor,razonSocialProvedor,estadoProvedor,fechaHoraActualizacionProvedor,latitud,longitud,fechaRegistro FROM Provedor WHERE idProvedor=@idProvedor";
			try
			{
				cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idProvedor", idProvedor);
				dr = Methods.ExecuteDataReaderCommand(cmd);

				while (dr.Read())
				{
					res = new Provedor( int.Parse(dr[0].ToString()), dr[1].ToString(),byte.Parse(dr[2].ToString()), Convert.ToDateTime(dr[3].ToString()),double.Parse(dr[4].ToString()), double.Parse(dr[5].ToString()), Convert.ToDateTime(dr[6].ToString()));
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
		/// Metodo SelectProvedores ProvedorDAL recupera todos los provedores activos 1
		/// </summary>
		/// <returns>DataTable</returns>
		public DataTable SelectProvedores()
		{
			DataTable res = new DataTable();
			string query = "SELECT idProvedor,razonSocialProvedor FROM Provedor WHERE estadoProvedor=1";
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
		/// Metodo SelectBusquedaProvedores ProvedorDAL realiza la busqueda de provedores mediante texto
		/// </summary>
		/// <param name="texto"></param>
		/// <returns>DataTable</returns>
		public DataTable SelectBusquedaProvedores(string texto)
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwProvedorSelect ";
			query = query + " WHERE  [Razon Social] LIKE @texto ";
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
		/// <summary>
		/// Metodo VerificarProvedor ProvedorDAL verifica la existencia de un Provedor
		/// </summary>
		/// <param name="provedor"></param>
		/// <returns>DataTable</returns>
		public DataTable VerificarProvedor(string provedor)
		{
			DataTable dt = new DataTable();
			string query = "SELECT * FROM Provedor WHERE razonSocialProvedor=@razonSocialProvedor";
			try
			{

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@razonSocialProvedor", provedor);
				dt = Methods.ExecuteDataTableCommand(cmd);
			}
			catch (SqlException ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			return dt;
		}
		/// <summary>
		/// Metodo VerificarProvedorEliminar verifica que el provedor no tenga articulos asociados a el
		/// </summary>
		/// <param name="id"></param>
		/// <returns>DataTable</returns>
		public DataTable VerificarProvedorEliminar(int id)
		{
			DataTable dt = new DataTable();
			string query = "SELECT * FROM Categoria C INNER JOIN Articulo A ON A.idCategoria=C.idCategoria WHERE C.idCategoria=@id AND A.estadoArticulo=1";
			try
			{

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@id", id);
				dt = Methods.ExecuteDataTableCommand(cmd);
			}
			catch (SqlException ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			return dt;
		}
	}
}