using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
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
		public override void Delete()
		{
			string query = "UPDATE Articulo SET estadoArticulo=0 , fechaHoraActualizacionArticulo=CURRENT_TIMESTAMP WHERE idArticulo = @idArticulo";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Delete de un Articulo", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idArticulo", art.IdArticulo);
				Methods.ExecuteBasicCommand(cmd);

				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Eliminado, Nombre Articulo: {1}, Usuario:{2}", DateTime.Now, art.NombreArticulo, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
		}

		public override void Insert()
		{
			string query = "INSERT INTO Articulo(nombreArticulo,idCategoria,idProvedor,fechaHoraRegistro,foto) VALUES(@nombreCategoria,@idCategoria,@idProvedor,@fechaHoraRegistro,@foto)";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Insert de un Articulo", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@nombreCategoria", art.NombreArticulo);
				cmd.Parameters.AddWithValue("@idCategoria", art.IdCategoria);
				cmd.Parameters.AddWithValue("@idProvedor", art.IdProvedor);
				cmd.Parameters.AddWithValue("@fechaHoraRegistro", art.FechaHoraRegistro);			
				cmd.Parameters.AddWithValue("@foto", art.Foto);
				Methods.ExecuteBasicCommand(cmd);

				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Insertado, Nombre Articulo: {1}, Usuario:{2}", DateTime.Now, art.NombreArticulo, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));

			}
		}

		public override DataTable Select()
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwArticuloSelect ORDER BY 2";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Select de un Articulo", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				res = Methods.ExecuteDataTableCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registros Seleccionados, Usuario:{1}", DateTime.Now, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));

			}
			return res;
		}

		public override void Update()
		{
			string query = "UPDATE Articulo SET nombreArticulo=@nombreArticulo,fechaHoraActualizacionArticulo=CURRENT_TIMESTAMP, idCategoria=@idCategoria,idProvedor=@idProvedor,foto=1 WHERE idArticulo = @idArticulo";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Update de un Articulo", DateTime.Now));
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@nombreArticulo", art.NombreArticulo);
				cmd.Parameters.AddWithValue("@idCategoria", art.IdCategoria);
				cmd.Parameters.AddWithValue("@idArticulo", art.IdArticulo);
				cmd.Parameters.AddWithValue("@idProvedor", art.IdProvedor);
				Methods.ExecuteBasicCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Actualizado, Nombre Articulo: {1}, Usuario:{1}", DateTime.Now,art.NombreArticulo, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
		}
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
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Buscado, Usuario:{1}", DateTime.Now, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return res;
		}
		
		public DataTable VerificarArticulo(string articulo)
		{
			DataTable dt = new DataTable();
			string query = "SELECT * FROM Articulo WHERE nombreArticulo=@nombreArticulo";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo verificar Usuarios", DateTime.Now));

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
		public DataTable VerificarArticuloEliminar(int id)
		{
			DataTable dt = new DataTable();
			string query = "SELECT * FROM Articulo A INNER JOIN Item I ON I.idArticulo=A.idArticulo WHERE A.idArticulo=@id AND I.estadoItem=1";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo verificar Usuarios", DateTime.Now));

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