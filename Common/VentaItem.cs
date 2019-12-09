using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public class VentaItem
	{
		#region Atributos y Propiedades de la Clase
		private int idVenta;

		public int IdVenta
		{
			get { return idVenta; }
			set { idVenta = value; }
		}
		private int idItem;

		public int IdItem
		{
			get { return idItem; }
			set { idItem = value; }
		}
		private double precioUnitario;

		public double PrecioUnitario
		{
			get { return precioUnitario; }
			set { precioUnitario = value; }
		}
		#endregion
		#region Constructores de la clase
		public VentaItem()
		{

		}
		public VentaItem(int idItem,double precioUnitario)
		{
			this.idItem = idItem;			
			this.precioUnitario=precioUnitario;
		}

		#endregion

	}
}
