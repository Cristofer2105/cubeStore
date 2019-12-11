using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
using Common;

namespace BRL
{
	/// <summary>
	/// Clase VentaBRL
	/// </summary>
	public class VentaBRL : AbstractBRL
	{
		/// <summary>
		/// Atributos propiedades y constructores
		/// </summary>
		#region Atributos propiedades y constructores
		private Venta vtn;

		public Venta Vtn
		{
			get { return vtn; }
			set { vtn = value; }
		}
		private List<VentaItem> vti;

		public List<VentaItem> Vti
		{
			get { return vti; }
			set { vti = value; }
		}
		private Garantia grt;

		public Garantia Grt
		{
			get { return grt; }
			set { grt = value; }
		}
		private Cliente cli;

		public Cliente Cli
		{
			get { return cli; }
			set { cli = value; }
		}
		private Item itm;

		public Item Art
		{
			get { return itm; }
			set { itm = value; }
		}
		private VentaDAL dal;

		public VentaDAL Dal
		{
			get { return dal; }
			set { dal = value; }
		}
		public VentaBRL()
		{

		}

		public VentaBRL(Venta vtn,List<VentaItem> vti, Garantia grt)
		{
			this.Vtn = vtn;
			this.Vti = vti;
			this.Grt = grt;
			dal = new VentaDAL(vtn,vti,grt);

		}
		public VentaBRL(Venta vtn)
		{
			this.vtn = vtn;
			dal = new VentaDAL(vtn);
		}
		#endregion
		/// <summary>
		/// Metodo Delete VentaBRL
		/// </summary>
		public override void Delete()
		{
			throw new NotImplementedException();
		}
		/// <summary>
		/// Metodo Insert VentaBRL
		/// </summary>
		public override void Insert()
		{
			throw new NotImplementedException();
		}
		/// <summary>
		/// Metodo InsertVentas VentaBRL
		/// </summary>
		public void InsertVentas()
		{
			dal.InsertVentas();
		}
		/// <summary>
		/// Metodo Select VentaBRL
		/// </summary>
		/// <returns>DataTable</returns>
		public override DataTable Select()
		{
			dal = new VentaDAL();
			return dal.Select();
		}
		/// <summary>
		/// Metodo SelectMaxIdVenta VentaBRL
		/// </summary>
		/// <returns>DataTable</returns>
		public DataTable SelectMaxIdVenta()
		{
			dal = new VentaDAL();
			return dal.SelectMaxIdVenta();
		}
		/// <summary>
		/// Metodo SelectBusquedaVenta VentaBRL
		/// </summary>
		/// <param name="texto"></param>
		/// <returns>DataTable</returns>
		public DataTable SelectBusquedaVenta(string texto)
		{
			dal = new VentaDAL();
			return dal.SelectBusquedaVenta(texto);
		}
		/// <summary>
		/// Metodo Get VentaBRL
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Venta</returns>
		public Venta Get(int id)
		{
			dal = new VentaDAL();
			return dal.Get(id);
		}
		/// <summary>
		/// Metodo SelectIdItemsAnular VentaBRL
		/// </summary>
		/// <param name="id"></param>
		/// <returns>DataTable</returns>
		public DataTable SelectIdItemsAnular(int id)
		{
			dal = new VentaDAL();
			return dal.SelectIdItemsAnular(id);
		}
		/// <summary>
		/// Metodo AnularVentas VentaBRL
		/// </summary>
		/// <param name="venta"></param>
		/// <param name="garantia"></param>
		/// <param name="items"></param>
		/// <param name="ventaAnulada"></param>
		public void AnularVentas(Venta venta, Garantia garantia, List<Item> items, VentaAnulada ventaAnulada)
		{
			dal.AnularVenta(venta, garantia, items, ventaAnulada);
		}
		/// <summary>
		/// Metodo Update VentaBRL
		/// </summary>
		public override void Update()
		{
			throw new NotImplementedException();
		}	
	}
}