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
	/// Clase ItemDAL
	/// </summary>
	public class ItemDAL : AbstractDAL
	{
		#region Atributos Propiedades y Constructores de clase
		private Item itm;

		public Item Art
		{
			get { return itm; }
			set { itm = value; }
		}
		public ItemDAL()
		{

		}
		public ItemDAL(Item itm)
		{
			this.itm = itm;
		}

		#endregion
		#region metodos de la clase
		/// <summary>
		/// Metodo Delete ItemDAL cambia el estado de un item a inactivo 0
		/// </summary>
		public override void Delete()
		{
			string query1 = "UPDATE Item SET estadoItem=0 , fechaHoraActualizacionItem=CURRENT_TIMESTAMP WHERE idItem = @idItem";
			string query2 = "INSERT INTO Auditoria(tabla,creaUpdDel,descripcion,idUsuario)VALUES(@tabla,@creaUpdDel,@descripcion,@idUsuario)";
			List<SqlCommand> cmdslist = new List<SqlCommand>();

			try
			{
				Methods.GenerateLogsActivities(DateTime.Now, "Inicio del Metodo Delete de un Item", Sesion.usuarioSesion);
				List<string> querys = new List<string>();
				querys.Add(query1);
				querys.Add(query2);
				cmdslist = Methods.CreateNCommands(querys);

				cmdslist[0].Parameters.AddWithValue("@idItem", itm.IdItem);

				string tabla = "Item";
				char cr = 'D';
				string descripcion = "ID Item: " + itm.IdItem + ", Se elimino"+", estadoItem=0";
				cmdslist[1].Parameters.AddWithValue("@tabla", tabla);
				cmdslist[1].Parameters.AddWithValue("@creaUpdDel", cr);
				cmdslist[1].Parameters.AddWithValue("@descripcion", descripcion);
				cmdslist[1].Parameters.AddWithValue("@idUsuario", Sesion.idSesion);


				Methods.ExecuteNBasicCommand(cmdslist);

				Methods.GenerateLogsActivities(DateTime.Now, "Item Eliminado: " + ", Item: " +itm.IdItem, Sesion.usuarioSesion);

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
		/// Metodo Insert ItemDAL agrega un nuevo item
		/// </summary>
		public override void Insert()
		{
			string query1 = "INSERT INTO Item(codigoItem,idArticulo,precioBase,fechaRegistro) VALUES(@codigoItem,@idArticulo,@precioBase,@fechaRegistro)";
			string query2 = "INSERT INTO Auditoria(tabla,creaUpdDel,descripcion,idUsuario)VALUES(@tabla,@creaUpdDel,@descripcion,@idUsuario)";
			List<SqlCommand> cmdslist = new List<SqlCommand>();
			try
			{
				Methods.GenerateLogsActivities(DateTime.Now, "Inicio del Metodo Insert de un Item", Sesion.usuarioSesion);

				List<string> querys = new List<string>();
				querys.Add(query1);
				querys.Add(query2);
				cmdslist = Methods.CreateNCommands(querys);

				cmdslist[0].Parameters.AddWithValue("@codigoItem", itm.CodigoItem);
				cmdslist[0].Parameters.AddWithValue("@idArticulo", itm.IdArticulo);
				cmdslist[0].Parameters.AddWithValue("@precioBase", itm.PrecioBaseItem);
				cmdslist[0].Parameters.AddWithValue("@fechaRegistro", itm.FehaRegistroItem);

				int idIte = Methods.GetCurrentValueIDTable("Item");
				string tabla = "Item";
				char cr = 'C';
				string descripcion = "ID Item: " + idIte + ", Se agrego: " + itm.CodigoItem+ ", Precio: " + itm.PrecioBaseItem +", ID Articulo: " + itm.IdArticulo;
				cmdslist[1].Parameters.AddWithValue("@tabla", tabla);
				cmdslist[1].Parameters.AddWithValue("@creaUpdDel", cr);
				cmdslist[1].Parameters.AddWithValue("@descripcion", descripcion);
				cmdslist[1].Parameters.AddWithValue("@idUsuario", Sesion.idSesion);


				Methods.ExecuteNBasicCommand(cmdslist);
				Methods.GenerateLogsActivities(DateTime.Now, "Item Insertado: " + ", Item: " + itm.CodigoItem, Sesion.usuarioSesion);

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
		/// Metodo Select ItemDAL recupera todos los items activos
		/// </summary>
		/// <returns>DataTable</returns>
		public override DataTable Select()
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwItemSelect ORDER BY 5";
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
		/// Metodo que permite hacer busqueda de un item mediante el articulo 
		/// </summary>
		/// <param name="texto"></param>
		/// <returns>DataTable</returns>
		public DataTable SelectBusquedaItems(string texto)
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwItemSelect ";
			query = query + " WHERE  Articulo LIKE @texto ";
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
		/// Metodo Update ItemDAL actualiza datos del Item
		/// </summary>
		public override void Update()
		{
			string query1 = "UPDATE Item SET codigoItem=@codigoItem,precioBase=@precioBase WHERE idItem = @idItem";
			string query2 = "INSERT INTO Auditoria(tabla,creaUpdDel,descripcion,idUsuario)VALUES(@tabla,@creaUpdDel,@descripcion,@idUsuario)";
			List<SqlCommand> cmdslist = new List<SqlCommand>();
			try
			{
				Methods.GenerateLogsActivities(DateTime.Now, "Inicio del Metodo Update de un Item", Sesion.usuarioSesion);

				List<string> querys = new List<string>();
				querys.Add(query1);
				querys.Add(query2);
				cmdslist = Methods.CreateNCommands(querys);

				cmdslist[0].Parameters.AddWithValue("@codigoItem", itm.CodigoItem);
				cmdslist[0].Parameters.AddWithValue("@precioBase", itm.PrecioBaseItem);
				cmdslist[0].Parameters.AddWithValue("@idItem", itm.IdItem);

				string tabla = "Item";
				char cr = 'U';
				string descripcion = "ID Item: " + itm.IdItem + ", Se Modifico: " + itm.CodigoItem + ", Precio: " + itm.PrecioBaseItem;
				cmdslist[1].Parameters.AddWithValue("@tabla", tabla);
				cmdslist[1].Parameters.AddWithValue("@creaUpdDel", cr);
				cmdslist[1].Parameters.AddWithValue("@descripcion", descripcion);
				cmdslist[1].Parameters.AddWithValue("@idUsuario", Sesion.idSesion);


				Methods.ExecuteNBasicCommand(cmdslist);

				Methods.GenerateLogsActivities(DateTime.Now, "Item Actualizado: " + ", Item: " + itm.CodigoItem, Sesion.usuarioSesion);
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
		/// Metodo Get ItemDAL recupera un Item mediante el id del Item
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Item</returns>
		public Item Get(int id)
		{
			Item res = null;
			SqlCommand cmd = null;
			SqlDataReader dr = null;
			string query = "SELECT idItem,codigoItem,idArticulo,estadoItem,fechaHoraActualizacionItem,precioBase,fechaRegistro FROM Item WHERE idItem=@idItem";
			try
			{

				cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idItem",id);
				dr = Methods.ExecuteDataReaderCommand(cmd);

				while (dr.Read())
				{
					res = new Item(int.Parse(dr[0].ToString()), dr[1].ToString(), int.Parse(dr[2].ToString()), byte.Parse(dr[3].ToString()), DateTime.Parse(dr[4].ToString()), double.Parse(dr[5].ToString()), DateTime.Parse(dr[6].ToString()));
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
		/// Metodo SelectArticulos ItemDAL realiza una busqueda de articulos mediante texto
		/// </summary>
		/// <param name="texto"></param>
		/// <returns>DataTable</returns>
		public DataTable SelectArticulos(string texto)
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwBusquedaArticulos ";
			query = query + " WHERE Articulo LIKE @texto";
			try
			{

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@texto", "%"+texto+"%");
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
		/// Metodo SelectItems realiza la busqueda de items mediante texto
		/// </summary>
		/// <param name="texto"></param>
		/// <returns>DataTable</returns>
		public DataTable SelectItems(string texto)
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwSelectItemsBusq ";
			query = query + " WHERE Articulo LIKE @texto";
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
		/// Metodo SelectItemsComprar selecciona los items que estan en medio de una compra
		/// </summary>
		/// <returns>DataTable</returns>
		public DataTable SelectItemsComprar()
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwSelectItemsComprar";
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
		/// Metodo UpdateEstadoParaComprar Actualiza el estado del item para su psible compra
		/// </summary>
		public void UpdateEstadoParaComprar()
		{

			string query = "UPDATE Item SET estadoItem=2 , fechaHoraActualizacionItem=CURRENT_TIMESTAMP WHERE idItem = @idItem";
			try
			{

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idItem", itm.IdItem);
				Methods.ExecuteBasicCommand(cmd);

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
		/// Metodo UpdateEstadoQuitarComprar actualiza el estado de los items a activos 1
		/// </summary>
		public void UpdateEstadoQuitarCompra()
		{
			string query = "UPDATE Item SET estadoItem=1 , fechaHoraActualizacionItem=CURRENT_TIMESTAMP WHERE idItem = @idItem";
			try
			{

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idItem", itm.IdItem);
				Methods.ExecuteBasicCommand(cmd);

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
		/// Metodo UpdateEstadoNormalItem actualiza el estado de los items a activos 1
		/// </summary>
		public void UpdateEstadoNormalItem()
		{
			string query = "UPDATE Item SET estadoItem=1 , fechaHoraActualizacionItem=CURRENT_TIMESTAMP WHERE estadoItem = 2";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				Methods.ExecuteBasicCommand(cmd);

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
		/// Metodo TotalVenta recupera el total de una Venta
		/// </summary>
		/// <returns>DataTable</returns>
		public DataTable TotalVenta()
		{
			DataTable res = new DataTable();
			string query = "SELECT SUM(precioBase) FROM Item WHERE estadoItem=2";
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
		/// Metodo CantidadVenta ItemDAL recupera la cantidad de articulos que compra
		/// </summary>
		/// <returns>DataTable</returns>
		public DataTable CantidadVenta()
		{
			DataTable res = new DataTable();
			string query = "SELECT COUNT(idArticulo) FROM Item WHERE estadoItem=2";
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
		/// Metodo VerificarItem ItemDAL verifica la existencia de un item
		/// </summary>
		/// <param name="item"></param>
		/// <returns>DataTable</returns>
		public DataTable VerificarItem(string item)
		{
			DataTable dt = new DataTable();
			string query = "SELECT * FROM Item WHERE codigoItem=@codigoItem";
			try
			{

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@codigoItem", item);
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
		#endregion
	}
}