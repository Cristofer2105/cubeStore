using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
using Common;

namespace BRL
{
	public class VentaBRL : AbstractBRL
	{
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
		public override void Delete()
		{
			throw new NotImplementedException();
		}

		public override void Insert()
		{
			throw new NotImplementedException();
		}
		public void InsertVentas()
		{
			dal.InsertVentas();
		}
		
		public override DataTable Select()
		{
			dal = new VentaDAL();
			return dal.Select();
		}
		public DataTable SelectBusquedaVenta(string texto)
		{
			dal = new VentaDAL();
			return dal.SelectBusquedaVenta(texto);
		}
		public Venta Get(int id)
		{
			dal = new VentaDAL();
			return dal.Get(id);
		}



		public override void Update()
		{
			throw new NotImplementedException();
		}	
	}
}