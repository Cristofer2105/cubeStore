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
		/// Metodo Delete Articulo
		/// </summary>
		public override void Delete()
		{
			string query1 = "UPDATE Articulo SET estadoArticulo=0 , fechaHoraActualizacionArticulo=CURRENT_TIMESTAMP WHERE idArticulo = @idArticulo";
			string query2 = "INSERT INTO Auditoria(tabla,creaUpdDel,descripcion,idUsuario)VALUES(@tabla,@creaUpdDel,@descripcion,@idUsuario)";
			List<SqlCommand> cmdslist = new List<SqlCommand>();
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Delete de un Articulo", DateTime.Now));

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

				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Eliminado, Nombre Articulo: {1}, Usuario:{2}", DateTime.Now, art.NombreArticulo, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
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
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Insert de un Articulo", DateTime.Now));
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

				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Insertado, Nombre Articulo: {1}, Usuario:{2}", DateTime.Now, art.NombreArticulo, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));

			}
		}
		/// <summary>
		/// Metodo Select Articulo
		/// </summary>
		/// <returns>DataTable</returns>
		public override DataTable Select()
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwArticuloSelect ORDER BY 2";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Select de un Articulo", DateTime.Now));
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				res = Methods.ExecuteDataTableCommand(cmd);

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));

			}
			return res;
		}
		/// <summary>
		/// Metodo Update Articulo
		/// </summary>
		public override void Update()
		{
			string query1 = "UPDATE Articulo SET nombreArticulo=@nombreArticulo,fechaHoraActualizacionArticulo=CURRENT_TIMESTAMP, idCategoria=@idCategoria,idProvedor=@idProvedor,foto=1 WHERE idArticulo = @idArticulo";
			string query2 = "INSERT INTO Auditoria(tabla,creaUpdDel,descripcion,idUsuario)VALUES(@tabla,@creaUpdDel,@descripcion,@idUsuario)";
			List<SqlCommand> cmdslist = new List<SqlCommand>();
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Update de un Articulo", DateTime.Now));

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

				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Actualizado, Nombre Articulo: {1}, Usuario:{1}", DateTime.Now,art.NombreArticulo, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
		}
		/// <summary>
		/// Metodo Get Articulo
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
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Get de un Articulo", DateTime.Now));
				cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idArticulo", idArticulo);
				dr = Methods.ExecuteDataReaderCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Conseguido, Usuario:{1}", DateTime.Now, Sesion.usuarioSesion));
				while (dr.Read())
				{
					res = new Articulo(int.Parse(dr[0].ToString()), dr[1].ToString(), byte.Parse(dr[2].ToString()), DateTime.Parse(dr[3].ToString()), byte.Parse(dr[4].ToString()), int.Parse(dr[5].ToString()), DateTime.Parse(dr[6].ToString()),byte.Parse(dr[7].ToString()));
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
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Busqueda de Articulo", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@texto", "%" + texto + "%");
				res = Methods.ExecuteDataTableCommand(cmd);

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return res;
		}
		/// <summary>
		/// Metodo VerificarArticulo
		/// </summary>
		/// <param name="articulo"></param>
		/// <returns>DataTable</returns>
		public DataTable VerificarArticulo(string articulo)
		{
			DataTable dt = new DataTable();
			string query = "SELECT * FROM Articulo WHERE nombreArticulo=@nombreArticulo";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo verificar Articulos", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@nombreArticulo", articulo);
				dt = Methods.ExecuteDataTableCommand(cmd);

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return dt;
		}
		/// <summary>
		/// Metodo VerificarArticuloEliminar
		/// </summary>
		/// <param name="id"></param>
		/// <returns>DataTable</returns>
		public DataTable VerificarArticuloEliminar(int id)
		{
			DataTable dt = new DataTable();
			string query = "SELECT * FROM Articulo A INNER JOIN Item I ON I.idArticulo=A.idArticulo WHERE A.idArticulo=@id AND I.estadoItem=1";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo verificar Articulo para Eliminar", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@id", id);
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