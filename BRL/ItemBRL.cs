using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;
using DAL;

namespace BRL
{
	/// <summary>
	/// Clase ItemBRL
	/// </summary>
	public class ItemBRL : AbstractBRL
	{
		#region Atributos propiedades y constructores
		private Item itm;

		public Item Itm
		{
			get { return itm; }
			set { itm = value; }
		}

		private ItemDAL dal;

		public ItemDAL Dal
		{
			get { return dal; }
			set { dal = value; }
		}
		public ItemBRL()
		{

		}
		public ItemBRL(Item itm)
		{
			this.itm = itm;
			dal = new ItemDAL(itm);
		}
		#endregion
		#region Metodos de la clase
		/// <summary>
		/// Metodo Delete ItemBRL
		/// </summary>
		public override void Delete()
		{
			dal.Delete();
		}
		/// <summary>
		/// Metodo Insert ItemBRL
		/// </summary>
		public override void Insert()
		{
			dal.Insert();
		}
		/// <summary>
		/// Metodo Select ItemBRL
		/// </summary>
		/// <returns>DataTable</returns>
		public override DataTable Select()
		{
			dal = new ItemDAL();
			return dal.Select();
		}
		/// <summary>
		/// Metodo que permite la busqueda de items mediante el nombre del articulo
		/// </summary>
		/// <param name="texto"></param>
		/// <returns></returns>
		public DataTable SelectBusquedaItems(string texto)
		{
			dal = new ItemDAL();
			return dal.SelectBusquedaItems(texto);
		}
		/// <summary>
		/// Metodo Update ItemBRL
		/// </summary>
		public override void Update()
		{
			dal.Update();
		}
		/// <summary>
		/// Metodo Get ItemBRL
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Item</returns>
		public Item Get(int id)
		{
			dal = new ItemDAL();
			return dal.Get(id);
		}
		/// <summary>
		/// Metodo SelectArticulos ItemBRL
		/// </summary>
		/// <param name="texto"></param>
		/// <returns>DataTable</returns>
		public DataTable SelectArticulos(string texto)
		{
			dal = new ItemDAL();
			return dal.SelectArticulos(texto);
		}
		/// <summary>
		/// Metodo SelectItems ItemBRL
		/// </summary>
		/// <param name="texto"></param>
		/// <returns>DataTable</returns>
		public DataTable SelectItems(string texto)
		{
			dal = new ItemDAL();
			return dal.SelectItems(texto);
		}
		/// <summary>
		/// Metodo UpdateEstadoParaComprar ItemBRL
		/// </summary>
		public void UpdateEstadoParaComprar()
		{
			dal.UpdateEstadoParaComprar();
		}
		/// <summary>
		/// Metodo UpdateEstadoNormalItem
		/// </summary>
		public void UpdateEstadoNormalItem()
		{
			dal.UpdateEstadoNormalItem();
		}
		/// <summary>
		/// Metodo UpdateEstadoQuitarCompra
		/// </summary>
		public void UpdateEstadoQuitarCompra()
		{
			dal.UpdateEstadoQuitarCompra();
		}
		/// <summary>
		/// Metodo SelectItemsComprar ItemBRL
		/// </summary>
		/// <returns>DataTable</returns>
		public DataTable SelectItemsComprar()
		{
			dal = new ItemDAL();
			return dal.SelectItemsComprar();
		}
		/// <summary>
		/// Metodo TotalVenta ItemBRL
		/// </summary>
		/// <returns>DataTable</returns>
		public DataTable TotalVenta()
		{
			dal = new ItemDAL();
			return dal.TotalVenta();
		}
		/// <summary>
		/// Metodo CantidadVenta ItemBRL
		/// </summary>
		/// <returns>DataTable</returns>
		public DataTable CantidadVenta()
		{
			dal = new ItemDAL();
			return dal.CantidadVenta();
		}
		/// <summary>
		/// Metodo VerificarItem ItemBRL
		/// </summary>
		/// <param name="item"></param>
		/// <returns>DataTable</returns>
		public DataTable VerificarItem(string item)
		{
			dal = new ItemDAL();
			return dal.VerificarItem(item);
		}
		
		#endregion
	}
}