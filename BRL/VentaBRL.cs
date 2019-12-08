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

		private VentaDAL dal;

		public VentaDAL Dal
		{
			get { return dal; }
			set { dal = value; }
		}
		public VentaBRL()
		{

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

		public override DataTable Select()
		{
			throw new NotImplementedException();
		}

		public override void Update()
		{
			throw new NotImplementedException();
		}	
	}
}