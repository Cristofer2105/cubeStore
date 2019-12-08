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
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idItem", itm.IdItem);
				Methods.ExecuteBasicCommand(cmd);
			}
			catch (Exception ex)
			{
				//Escribir Log
				throw ex;
			}
		}

		public override void Insert()
		{
			string query = "INSERT INTO Item(codigoItem,idArticulo,precioBase,fechaRegistro) VALUES(@codigoItem,@idArticulo,@precioBase,@fechaRegistro)";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@codigoItem", itm.CodigoItem);
				cmd.Parameters.AddWithValue("@idArticulo", itm.IdArticulo);
				cmd.Parameters.AddWithValue("@precioBase", itm.PrecioBaseItem);
				cmd.Parameters.AddWithValue("@fechaRegistro", itm.FehaRegistroItem);
				Methods.ExecuteBasicCommand(cmd);
			}
			catch (Exception ex)
			{
				//Escribir Log
				throw ex;
			}
		}

		public override DataTable Select()
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwItemSelect ORDER BY 5";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				res = Methods.ExecuteDataTableCommand(cmd);
			}
			catch (Exception ex)
			{

				throw ex;
			}
			return res;
		}

		public override void Update()
		{
			string query = "UPDATE Item SET codigoItem=@codigoItem,precioBase=@precioBase WHERE idItem = @idItem";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@codigoItem", itm.CodigoItem);
				cmd.Parameters.AddWithValue("@precioBase", itm.PrecioBaseItem);
				cmd.Parameters.AddWithValue("@idItem", itm.IdItem);
				Methods.ExecuteBasicCommand(cmd);
			}
			catch (Exception ex)
			{
				//Escribir Log
				throw ex;
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
				cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idItem",id);
				dr = Methods.ExecuteDataReaderCommand(cmd);

				while (dr.Read())
				{
					res = new Item(int.Parse(dr[0].ToString()), dr[1].ToString(), int.Parse(dr[2].ToString()), byte.Parse(dr[3].ToString()), DateTime.Parse(dr[4].ToString()), double.Parse(dr[5].ToString()), DateTime.Parse(dr[6].ToString()));
				}
			}
			catch (Exception ex)
			{

				throw ex;
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
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@texto", "%"+texto+"%");
				res = Methods.ExecuteDataTableCommand(cmd);
			}
			catch (Exception ex)
			{

				throw ex;
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
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@texto", "%" + texto + "%");
				res = Methods.ExecuteDataTableCommand(cmd);
			}
			catch (Exception ex)
			{

				throw ex;
			}
			return res;
		}
		public DataTable SelectItemsComprar()
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwSelectItemsComprar";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				res = Methods.ExecuteDataTableCommand(cmd);
			}
			catch (Exception ex)
			{

				throw ex;
			}
			return res;
		}
		public void UpdateEstadoParaComprar()
		{
			string query = "UPDATE Item SET estadoItem=2 , fechaHoraActualizacionItem=CURRENT_TIMESTAMP WHERE idItem = @idItem";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idItem", itm.IdItem);
				Methods.ExecuteBasicCommand(cmd);
			}
			catch (Exception ex)
			{
				//Escribir Log
				throw ex;
			}
		}
		public void UpdateEstadoQuitarCompra()
		{
			string query = "UPDATE Item SET estadoItem=1 , fechaHoraActualizacionItem=CURRENT_TIMESTAMP WHERE idItem = @idItem";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idItem", itm.IdItem);
				Methods.ExecuteBasicCommand(cmd);
			}
			catch (Exception ex)
			{
				//Escribir Log
				throw ex;
			}
		}
		public DataTable TotalVenta()
		{
			DataTable res = new DataTable();
			string query = "SELECT SUM(precioBase) FROM Item WHERE estadoItem=2";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				res = Methods.ExecuteDataTableCommand(cmd);
			}
			catch (Exception ex)
			{

				throw ex;
			}
			return res;
		}
	
		public DataTable CantidadVenta()
		{
			DataTable res = new DataTable();
			string query = "SELECT COUNT(idArticulo) FROM Item WHERE estadoItem=2";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				res = Methods.ExecuteDataTableCommand(cmd);
			}
			catch (Exception ex)
			{

				throw ex;
			}
			return res;
		}
		


		#endregion
	}
}