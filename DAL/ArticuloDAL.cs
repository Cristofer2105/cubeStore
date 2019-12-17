using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
	/// <summary>
	/// Clase ArticuloDAL
	/// </summary>
	public class ArticuloDAL : AbstractDAL
	{
		#region Atributos Propiedades y Constructores de clase
		private Articulo art;

		public Articulo  Art
		{
			get { return art; }
			set { art = value; }
		}
		public ArticuloDAL()
		{

		}
		public ArticuloDAL(Articulo art)
		{
			this.art = art;
		}

		#endregion
		/// <summary>
		/// Metodo Delete Articulo para cambiar el estado de un Articulo a Inactivo 0
		/// </summary>
		public override void Delete()
		{
			string query1 = "UPDATE Articulo SET estadoArticulo=0 , fechaHoraActualizacionArticulo=CURRENT_TIMESTAMP WHERE idArticulo = @idArticulo";
			string query2 = "INSERT INTO Auditoria(tabla,creaUpdDel,descripcion,idUsuario)VALUES(@tabla,@creaUpdDel,@descripcion,@idUsuario)";
			List<SqlCommand> cmdslist = new List<SqlCommand>();
			try
			{
				Methods.GenerateLogsActivities(DateTime.Now, "Inicio del Metodo Delete de un Articulo"+", Articulo: "+art.NombreArticulo, Sesion.usuarioSesion);
				List<string> querys = new List<string>();
				querys.Add(query1);
				querys.Add(query2);
				cmdslist = Methods.CreateNCommands(querys);

				cmdslist[0].Parameters.AddWithValue("@idArticulo", art.IdArticulo);

				string tabla = "Articulo";
				char cr = 'D';
				string descripcion = "ID Articulo: " + art.IdArticulo + ", Se Elimino: " + art.NombreArticulo+ ", estadoArticulo=0";
				cmdslist[1].Parameters.AddWithValue("@tabla", tabla);
				cmdslist[1].Parameters.AddWithValue("@creaUpdDel", cr);
				cmdslist[1].Parameters.AddWithValue("@descripcion", descripcion);
				cmdslist[1].Parameters.AddWithValue("@idUsuario", Sesion.idSesion);


				Methods.ExecuteNBasicCommand(cmdslist);
				Methods.GenerateLogsActivities(DateTime.Now, "Articulo Eliminado: " + ", Articulo: " + art.NombreArticulo, Sesion.usuarioSesion);
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
		/// Metodo Insert para agragar un Articulo
		/// </summary>
		public override void Insert()
		{
			string query1 = "INSERT INTO Articulo(nombreArticulo,idCategoria,idProvedor,fechaHoraRegistro,foto) VALUES(@nombreCategoria,@idCategoria,@idProvedor,@fechaHoraRegistro,@foto)";
			string query2 = "INSERT INTO Auditoria(tabla,creaUpdDel,descripcion,idUsuario)VALUES(@tabla,@creaUpdDel,@descripcion,@idUsuario)";
			List<SqlCommand> cmdslist = new List<SqlCommand>();
			try
			{
				Methods.GenerateLogsActivities(DateTime.Now, "Inicio del Metodo Insert de un Articulo" + ", Articulo: " + art.NombreArticulo, Sesion.usuarioSesion);
				List<string> querys = new List<string>();
				querys.Add(query1);
				querys.Add(query2);
				cmdslist = Methods.CreateNCommands(querys);

				cmdslist[0].Parameters.AddWithValue("@nombreCategoria", art.NombreArticulo);
				cmdslist[0].Parameters.AddWithValue("@idCategoria", art.IdCategoria);
				cmdslist[0].Parameters.AddWithValue("@idProvedor", art.IdProvedor);
				cmdslist[0].Parameters.AddWithValue("@fechaHoraRegistro", art.FechaHoraRegistro);
				cmdslist[0].Parameters.AddWithValue("@foto", art.Foto);

				int idArt = Methods.GetCurrentValueIDTable("Articulo");
				string tabla = "Articulo";
				char cr = 'C';
				string descripcion ="ID Articulo: "+idArt+", Se agrego: "+art.NombreArticulo+", ID Categoria: "+art.IdCategoria+", ID Provedor: "+art.IdProvedor;
				cmdslist[1].Parameters.AddWithValue("@tabla", tabla);
				cmdslist[1].Parameters.AddWithValue("@creaUpdDel", cr);
				cmdslist[1].Parameters.AddWithValue("@descripcion", descripcion);
				cmdslist[1].Parameters.AddWithValue("@idUsuario", Sesion.idSesion);


				Methods.ExecuteNBasicCommand(cmdslist);

				Methods.GenerateLogsActivities(DateTime.Now, "Articulo Insertado: " + ", Articulo: " + art.NombreArticulo, Sesion.usuarioSesion);

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
		/// Metodo Select Articulo recupera todos los articulos activos
		/// </summary>
		/// <returns>DataTable</returns>
		public override DataTable Select()
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwArticuloSelect ORDER BY 2";
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
		/// Metodo Update Articulo permite actualizar datos de un Articulo
		/// </summary>
		public override void Update()
		{
			string query1 = "UPDATE Articulo SET nombreArticulo=@nombreArticulo,fechaHoraActualizacionArticulo=CURRENT_TIMESTAMP, idCategoria=@idCategoria,idProvedor=@idProvedor,foto=1 WHERE idArticulo = @idArticulo";
			string query2 = "INSERT INTO Auditoria(tabla,creaUpdDel,descripcion,idUsuario)VALUES(@tabla,@creaUpdDel,@descripcion,@idUsuario)";
			List<SqlCommand> cmdslist = new List<SqlCommand>();
			try
			{
				Methods.GenerateLogsActivities(DateTime.Now, "Inicio del Metodo Update de un Articulo" + ", Articulo: " + art.NombreArticulo, Sesion.usuarioSesion);
				List<string> querys = new List<string>();
				querys.Add(query1);
				querys.Add(query2);
				cmdslist = Methods.CreateNCommands(querys);

				cmdslist[0].Parameters.AddWithValue("@nombreArticulo", art.NombreArticulo);
				cmdslist[0].Parameters.AddWithValue("@idCategoria", art.IdCategoria);
				cmdslist[0].Parameters.AddWithValue("@idArticulo", art.IdArticulo);
				cmdslist[0].Parameters.AddWithValue("@idProvedor", art.IdProvedor);

				string tabla = "Articulo";
				char cr = 'U';
				string descripcion = "ID Articulo: " + art.IdArticulo + ", Se Modifico: " + art.NombreArticulo + ", ID Categoria: "+ art.IdCategoria+", ID Provedor: "+ art.IdProvedor;
				cmdslist[1].Parameters.AddWithValue("@tabla", tabla);
				cmdslist[1].Parameters.AddWithValue("@creaUpdDel", cr);
				cmdslist[1].Parameters.AddWithValue("@descripcion", descripcion);
				cmdslist[1].Parameters.AddWithValue("@idUsuario", Sesion.idSesion);


				Methods.ExecuteNBasicCommand(cmdslist);
				Methods.GenerateLogsActivities(DateTime.Now, "Articulo Actualizado: " + ", Articulo: " + art.NombreArticulo, Sesion.usuarioSesion);
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
		/// Metodo Get Articulo permite recuperar un Articulo mediante el id del Articulo
		/// </summary>
		/// <param name="idArticulo"></param>
		/// <returns>Articulo</returns>
		public Articulo Get(int idArticulo)
		{
			Articulo res = null;
			SqlCommand cmd = null;
			SqlDataReader dr = null;
			string query = "SELECT idArticulo,nombreArticulo,estadoArticulo,fechaHoraActualizacionArticulo,idCategoria,idProvedor,fechaHoraRegistro,foto FROM Articulo WHERE idArticulo=@idArticulo";
			try
			{
				cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idArticulo", idArticulo);
				dr = Methods.ExecuteDataReaderCommand(cmd);
				while (dr.Read())
				{
					res = new Articulo(int.Parse(dr[0].ToString()), dr[1].ToString(), byte.Parse(dr[2].ToString()), DateTime.Parse(dr[3].ToString()), byte.Parse(dr[4].ToString()), int.Parse(dr[5].ToString()), DateTime.Parse(dr[6].ToString()),byte.Parse(dr[7].ToString()));
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
		/// Metodo SelectBusquedaArticulo permite buscar un Articulo mediante un texto
		/// </summary>
		/// <param name="texto"></param>
		/// <returns>DataTable</returns>
		public DataTable SelectBusquedaArticulos(string texto)
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwArticuloSelect ";
			query = query + " WHERE  [Nombre del Articulo] LIKE @texto ";
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
		/// Metodo VerificarArticulo permite verificar si el nombre de un articulo ya existe
		/// </summary>
		/// <param name="articulo"></param>
		/// <returns>DataTable</returns>
		public DataTable VerificarArticulo(string articulo)
		{
			DataTable dt = new DataTable();
			string query = "SELECT * FROM Articulo WHERE nombreArticulo=@nombreArticulo";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@nombreArticulo", articulo);
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
		/// Metodo VerificarArticuloEliminar permite verificar si el articulo tiene items activos
		/// </summary>
		/// <param name="id"></param>
		/// <returns>DataTable</returns>
		public DataTable VerificarArticuloEliminar(int id)
		{
			DataTable dt = new DataTable();
			string query = "SELECT * FROM Articulo A INNER JOIN Item I ON I.idArticulo=A.idArticulo WHERE A.idArticulo=@id AND I.estadoItem=1";
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