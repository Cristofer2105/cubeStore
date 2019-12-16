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
	/// Clase CategoriaDAL
	/// </summary>
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
		/// <summary>
		/// Metodo Delete Categoria
		/// </summary>
		public override void Delete()
		{
			string query1 = "UPDATE Categoria SET estadoCategoria=0 , fechaHoraActualizacionCategoria=CURRENT_TIMESTAMP WHERE idCategoria = @idCategoria";
			string query2 = "INSERT INTO Auditoria(tabla,creaUpdDel,descripcion,idUsuario)VALUES(@tabla,@creaUpdDel,@descripcion,@idUsuario)";
			List<SqlCommand> cmdslist = new List<SqlCommand>();

			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo de eliminacion de una Categoria", DateTime.Now));
				List<string> querys = new List<string>();
				querys.Add(query1);
				querys.Add(query2);
				cmdslist = Methods.CreateNCommands(querys);

				cmdslist[0].Parameters.AddWithValue("@idCategoria", cat.IdCategoria);

				string tabla = "Categoria";
				char cr = 'D';
				string descripcion = "ID Categoria: " + cat.IdCategoria + ", Se Elimino: " + cat.NombreCategoria + ", estadoArticulo=0";
				cmdslist[1].Parameters.AddWithValue("@tabla", tabla);
				cmdslist[1].Parameters.AddWithValue("@creaUpdDel", cr);
				cmdslist[1].Parameters.AddWithValue("@descripcion", descripcion);
				cmdslist[1].Parameters.AddWithValue("@idUsuario", Sesion.idSesion);


				Methods.ExecuteNBasicCommand(cmdslist);

				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Eliminado, Nombre Categoria: {1}, Usuario:{2}", DateTime.Now, cat.NombreCategoria, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
		}
		/// <summary>
		/// Metodo Insert Categoria
		/// </summary>
		public override void Insert()
		{
			string query1 = "INSERT INTO Categoria(nombreCategoria,fechaRegistro) VALUES(@nombreCategoria,@fechaRegistro)";
			string query2 = "INSERT INTO Auditoria(tabla,creaUpdDel,descripcion,idUsuario)VALUES(@tabla,@creaUpdDel,@descripcion,@idUsuario)";
			List<SqlCommand> cmdslist = new List<SqlCommand>();

			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo de Insercion de una Categoria",DateTime.Now));
				List<string> querys = new List<string>();
				querys.Add(query1);
				querys.Add(query2);
				cmdslist = Methods.CreateNCommands(querys);

				cmdslist[0].Parameters.AddWithValue("@nombreCategoria",cat.NombreCategoria);
				cmdslist[0].Parameters.AddWithValue("@fechaRegistro", cat.FechaHoraRegistroCat);

				int idCat = Methods.GetCurrentValueIDTable("Categoria");
				string tabla = "Categoria";
				char cr = 'C';
				string descripcion = "ID Categoria: " + idCat + ", Se agrego: " + cat.NombreCategoria;
				cmdslist[1].Parameters.AddWithValue("@tabla", tabla);
				cmdslist[1].Parameters.AddWithValue("@creaUpdDel", cr);
				cmdslist[1].Parameters.AddWithValue("@descripcion", descripcion);
				cmdslist[1].Parameters.AddWithValue("@idUsuario", Sesion.idSesion);


				Methods.ExecuteNBasicCommand(cmdslist);

				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Insertado, Nombre Categoria: {1}, Usuario:{2}", DateTime.Now,cat.NombreCategoria,Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{				
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
				throw ex;
			}
		}
		/// <summary>
		/// Metodo Select Categoria
		/// </summary>
		/// <returns>DataTable</returns>
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
		/// <summary>
		/// Metodo Update para modificar una Categoria
		/// </summary>
		public override void Update()
		{
			string query1 = "UPDATE Categoria SET nombreCategoria=@nombreCategoria,fechaHoraActualizacionCategoria=CURRENT_TIMESTAMP WHERE idCategoria = @idCategoria";
			string query2 = "INSERT INTO Auditoria(tabla,creaUpdDel,descripcion,idUsuario)VALUES(@tabla,@creaUpdDel,@descripcion,@idUsuario)";
			List<SqlCommand> cmdslist = new List<SqlCommand>();

			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo de Actualizacion de una Categoria", DateTime.Now));
				List<string> querys = new List<string>();
				querys.Add(query1);
				querys.Add(query2);
				cmdslist = Methods.CreateNCommands(querys);

				cmdslist[0].Parameters.AddWithValue("@idCategoria", cat.IdCategoria);
				cmdslist[0].Parameters.AddWithValue("@nombreCategoria", cat.NombreCategoria);

				string tabla = "Categoria";
				char cr = 'U';
				string descripcion = "ID Categoria: " + cat.IdCategoria + ", Se Modifico: " + cat.NombreCategoria;
				cmdslist[1].Parameters.AddWithValue("@tabla", tabla);
				cmdslist[1].Parameters.AddWithValue("@creaUpdDel", cr);
				cmdslist[1].Parameters.AddWithValue("@descripcion", descripcion);
				cmdslist[1].Parameters.AddWithValue("@idUsuario", Sesion.idSesion);


				Methods.ExecuteNBasicCommand(cmdslist);

				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Modificado,Nombre Categoria: {1}, Usuario:{2}", DateTime.Now,cat.NombreCategoria, Sesion.usuarioSesion));
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
				throw ex;
			}
		}
		/// <summary>
		/// Metodo Get Categoria
		/// </summary>
		/// <param name="idCategoria"></param>
		/// <returns>Categoria</returns>
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
		/// <summary>
		/// Metodo Select Categorias
		/// </summary>
		/// <returns>DataTable</returns>
		public DataTable SelectCategorias()
		{
			DataTable res = new DataTable();
			string query = "SELECT idCategoria,nombreCategoria FROM Categoria WHERE estadoCategoria=1";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo de Seleccion de una Categoria", DateTime.Now));
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				res = Methods.ExecuteDataTableCommand(cmd);

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
				throw ex;
			}
			return res;
		}
		/// <summary>
		/// Metodo SelectBusquedaCategoria
		/// </summary>
		/// <param name="texto"></param>
		/// <returns>DataTable</returns>
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

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return res;
		}
		/// <summary>
		/// Metodo VerificarCategoria
		/// </summary>
		/// <param name="categoria"></param>
		/// <returns>DataTable</returns>
		public DataTable VerificarCategoria(string categoria)
		{
			DataTable dt = new DataTable();
			string query = "SELECT * FROM Categoria WHERE nombreCategoria=@nombreCategoria";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo verificar Categoria", DateTime.Now));

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
		/// <summary>
		/// Metodo VerificarCategoriaEliminar
		/// </summary>
		/// <param name="id"></param>
		/// <returns>DataTable</returns>
		public DataTable VerificarCategoriaEliminar(int id)
		{
			DataTable dt = new DataTable();
			string query = "SELECT * FROM Categoria C INNER JOIN Articulo A ON A.idCategoria=C.idCategoria WHERE C.idCategoria=@id AND A.estadoArticulo=1";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo verificar Categoria para Eliminar", DateTime.Now));

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