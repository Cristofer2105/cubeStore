using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common;

namespace DAL
{
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
		public override void Delete()
		{
			string query = "UPDATE Item SET estadoItem=0 , fechaHoraActualizacionItem=CURRENT_TIMESTAMP WHERE idItem = @idItem";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Delete de un Item", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idItem", itm.IdItem);
				Methods.ExecuteBasicCommand(cmd);

				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Eliminado, Codigo Item: {1}, Usuario:{2}", DateTime.Now, itm.CodigoItem, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
		}

		public override void Insert()
		{
			string query = "INSERT INTO Item(codigoItem,idArticulo,precioBase,fechaRegistro) VALUES(@codigoItem,@idArticulo,@precioBase,@fechaRegistro)";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Insert de un Item", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@codigoItem", itm.CodigoItem);
				cmd.Parameters.AddWithValue("@idArticulo", itm.IdArticulo);
				cmd.Parameters.AddWithValue("@precioBase", itm.PrecioBaseItem);
				cmd.Parameters.AddWithValue("@fechaRegistro", itm.FehaRegistroItem);
				Methods.ExecuteBasicCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Insertado, Codigo Item: {1}, Usuario:{2}", DateTime.Now, itm.CodigoItem, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
		}

		public override DataTable Select()
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwItemSelect ORDER BY 5";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Select de Items", DateTime.Now));
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
			string query = "UPDATE Item SET codigoItem=@codigoItem,precioBase=@precioBase WHERE idItem = @idItem";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Update de Item", DateTime.Now));
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@codigoItem", itm.CodigoItem);
				cmd.Parameters.AddWithValue("@precioBase", itm.PrecioBaseItem);
				cmd.Parameters.AddWithValue("@idItem", itm.IdItem);
				Methods.ExecuteBasicCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Actualizado, Usuario:{1}", DateTime.Now, Sesion.usuarioSesion));
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
		}
		public Item Get(int id)
		{
			Item res = null;
			SqlCommand cmd = null;
			SqlDataReader dr = null;
			string query = "SELECT idItem,codigoItem,idArticulo,estadoItem,fechaHoraActualizacionItem,precioBase,fechaRegistro FROM Item WHERE idItem=@idItem";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Get de Item", DateTime.Now));

				cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idItem",id);
				dr = Methods.ExecuteDataReaderCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Conseguido, Usuario:{1}", DateTime.Now, Sesion.usuarioSesion));

				while (dr.Read())
				{
					res = new Item(int.Parse(dr[0].ToString()), dr[1].ToString(), int.Parse(dr[2].ToString()), byte.Parse(dr[3].ToString()), DateTime.Parse(dr[4].ToString()), double.Parse(dr[5].ToString()), DateTime.Parse(dr[6].ToString()));
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
		public DataTable SelectArticulos(string texto)
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwBusquedaArticulos ";
			query = query + " WHERE Articulo LIKE @texto";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Busqueda de Articulos", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@texto", "%"+texto+"%");
				res = Methods.ExecuteDataTableCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Buscado, Usuario:{1}", DateTime.Now, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return res;
		}
		public DataTable SelectItems(string texto)
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwSelectItemsBusq ";
			query = query + " WHERE Articulo LIKE @texto";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Busqueda de Items", DateTime.Now));

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
		public DataTable SelectItemsComprar()
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwSelectItemsComprar";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Select de Items para Comprar", DateTime.Now));

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
		public void UpdateEstadoParaComprar()
		{

			string query = "UPDATE Item SET estadoItem=2 , fechaHoraActualizacionItem=CURRENT_TIMESTAMP WHERE idItem = @idItem";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Update de Items para Comprar", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idItem", itm.IdItem);
				Methods.ExecuteBasicCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registros Actualizados, Usuario:{1}", DateTime.Now, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
		}
		public void UpdateEstadoQuitarCompra()
		{
			string query = "UPDATE Item SET estadoItem=1 , fechaHoraActualizacionItem=CURRENT_TIMESTAMP WHERE idItem = @idItem";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Update de Items para cancelar Compra", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idItem", itm.IdItem);
				Methods.ExecuteBasicCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registros Actualizados, Usuario:{1}", DateTime.Now, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
		}
		public void UpdateEstadoNormalItem()
		{
			string query = "UPDATE Item SET estadoItem=1 , fechaHoraActualizacionItem=CURRENT_TIMESTAMP WHERE estadoItem = 2";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Update de Items Modificados", DateTime.Now));
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				Methods.ExecuteBasicCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registros Actualizados, Usuario:{1}", DateTime.Now, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
		}
		public DataTable TotalVenta()
		{
			DataTable res = new DataTable();
			string query = "SELECT SUM(precioBase) FROM Item WHERE estadoItem=2";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Total Venta de Items", DateTime.Now));
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				res = Methods.ExecuteDataTableCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Total Venta Conseguido, Usuario:{1}", DateTime.Now, Sesion.usuarioSesion));
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return res;
		}
	
		public DataTable CantidadVenta()
		{
			DataTable res = new DataTable();
			string query = "SELECT COUNT(idArticulo) FROM Item WHERE estadoItem=2";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Cantidad Venta de Items", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				res = Methods.ExecuteDataTableCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Cantidad Venta Conseguido, Usuario:{1}", DateTime.Now, Sesion.usuarioSesion));

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