using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common;

namespace DAL
{
	public sealed class CategoriaDAL : AbstractDAL
	{
		#region Atributos Propiedades y Constructores de clase
		private Categoria cat;

		public Categoria Cat
		{
			get { return cat; }
			set { cat = value; }
		}
		public CategoriaDAL()
		{

		}
		public CategoriaDAL(Categoria cat)
		{
			this.cat = cat;
		}

		#endregion
		public override void Delete()
		{
			string query = "UPDATE Categoria SET estadoCategoria=0 , fechaHoraActualizacionCategoria=CURRENT_TIMESTAMP WHERE idCategoria = @idCategoria";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo de eliminacion de una Categoria", DateTime.Now));
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idCategoria", cat.IdCategoria);
				Methods.ExecuteBasicCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Eliminado, Nombre Categoria: {1}, Usuario:{2}", DateTime.Now, cat.NombreCategoria, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
		}
		
		public override void Insert()
		{
			string query = "INSERT INTO Categoria(nombreCategoria,fechaRegistro) VALUES(@nombreCategoria,@fechaRegistro)";
			try 
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo de Insercion de una Categoria",DateTime.Now));
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@nombreCategoria",cat.NombreCategoria);
				cmd.Parameters.AddWithValue("@fechaRegistro", cat.FechaHoraRegistroCat);
				Methods.ExecuteBasicCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Insertado, Nombre Categoria: {1}, Usuario:{2}", DateTime.Now,cat.NombreCategoria,Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{				
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
				throw ex;
			}
		}

		public override DataTable Select()
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwCategoriaSelect ORDER BY 2";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo de Seleccion de una Categoria", DateTime.Now));
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				res=Methods.ExecuteDataTableCommand(cmd);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
				throw ex;
			}
			return res;
		}

		public override void Update()
		{
			string query = "UPDATE Categoria SET nombreCategoria=@nombreCategoria,fechaHoraActualizacionCategoria=CURRENT_TIMESTAMP WHERE idCategoria = @idCategoria";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo de Actualizacion de una Categoria", DateTime.Now));
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idCategoria", cat.IdCategoria);
				cmd.Parameters.AddWithValue("@nombreCategoria", cat.NombreCategoria);
				Methods.ExecuteBasicCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Modificado,Nombre Categoria: {1}, Usuario:{2}", DateTime.Now,cat.NombreCategoria, Sesion.usuarioSesion));
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
				throw ex;
			}
		}
		public Categoria Get(byte idCategoria)
		{
			Categoria res = null;
			SqlCommand cmd = null;
			SqlDataReader dr = null;
			string query = "SELECT idCategoria,nombreCategoria,estadoCategoria,fechaHoraActualizacionCategoria FROM Categoria WHERE idCategoria=@idCategoria";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo de Get de una Categoria", DateTime.Now));
				cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
				dr = Methods.ExecuteDataReaderCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Conseguido, Usuario:{1}", DateTime.Now, Sesion.usuarioSesion));
				while (dr.Read())
				{
					res = new Categoria(byte.Parse(dr[0].ToString()), dr[1].ToString(), byte.Parse(dr[2].ToString()), DateTime.Parse(dr[3].ToString()));
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
				throw ex;
			}
			finally
			{
				cmd.Connection.Close();
				dr.Close();
			}
			return res;
		}
		public DataTable SelectCategorias()
		{
			DataTable res = new DataTable();
			string query = "SELECT idCategoria,nombreCategoria FROM Categoria WHERE estadoCategoria=1";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo de Seleccion de una Categoria", DateTime.Now));
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				res = Methods.ExecuteDataTableCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Seleccionado, Usuario:{1}", DateTime.Now, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
				throw ex;
			}
			return res;
		}
		public DataTable SelectBusquedaCategorias(string texto)
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwCategoriaSelect ";
			query = query + " WHERE  [Nombre de la Categoria] LIKE @texto ";
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
		public DataTable VerificarCategoria(string categoria)
		{
			DataTable dt = new DataTable();
			string query = "SELECT * FROM Categoria WHERE nombreCategoria=@nombreCategoria";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo verificar Usuarios", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@nombreCategoria", categoria);
				dt = Methods.ExecuteDataTableCommand(cmd);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return dt;
		}
		public DataTable VerificarCategoriaEliminar(int id)
		{
			DataTable dt = new DataTable();
			string query = "SELECT * FROM Categoria C INNER JOIN Articulo A ON A.idCategoria=C.idCategoria WHERE C.idCategoria=@id AND A.estadoArticulo=1";
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