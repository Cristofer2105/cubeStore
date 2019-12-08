using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common;

namespace DAL
{
	public class VentaDAL : AbstractDAL
	{
		#region Atributos Propiedades y Constructores de clase
		private Venta vtn;

		public Venta Vtn
		{
			get { return vtn; }
			set { vtn = value; }
		}
		public VentaDAL()
		{

		}
		public VentaDAL(Venta vtn)
		{
			this.vtn = vtn;
		}
		private Item itm;

		public Item Art
		{
			get { return itm; }
			set { itm = value; }
		}
		#endregion
		#region metodos de la clase
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
		#endregion
	}
}