using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public class Item
	{
		#region Atributos y Propiedades
		private int idItem;

		public int IdItem
		{
			get { return idItem; }
			set { idItem = value; }
		}
		private string codigoItem;

		public string CodigoItem
		{
			get { return codigoItem; }
			set { codigoItem = value; }
		}
		private int idArticulo;

		public int IdArticulo
		{
			get { return idArticulo; }
			set { idArticulo = value; }
		}
		private byte estadoItem;

		public byte EstadoItem
		{
			get { return estadoItem; }
			set { estadoItem = value; }
		}
		private DateTime fechaHoraActualizacionItem;

		public DateTime FechaHoraActualizacionItem
		{
			get { return fechaHoraActualizacionItem; }
			set { fechaHoraActualizacionItem = value; }
		}
		private double precioBaseItem;

		public double PrecioBaseItem
		{
			get { return precioBaseItem; }
			set { precioBaseItem = value; }
		}
		private DateTime fehaRegistroItem;

		public DateTime FehaRegistroItem
		{
			get { return fehaRegistroItem; }
			set { fehaRegistroItem = value; }
		}
		#endregion
		#region Constructores de la clase
		public Item()
		{

		}
		/// <summary>
		/// Constructor para seleccionar todo
		/// </summary>
		/// <param name="idItem"></param>
		/// <param name="codigoItem"></param>
		/// <param name="idArticulo"></param>
		/// <param name="estadoItem"></param>
		/// <param name="fechaHoraActualizacionItem"></param>
		/// <param name="precioBaseItem"></param>
		/// <param name="fehaRegistroItem"></param>
		public Item(int idItem, string codigoItem, int idArticulo, byte estadoItem, DateTime fechaHoraActualizacionItem, double precioBaseItem, DateTime fehaRegistroItem)
		{
			this.idItem = idItem;
			this.codigoItem = codigoItem;
			this.idArticulo = idArticulo;
			this.estadoItem = estadoItem;
			this.fechaHoraActualizacionItem = fechaHoraActualizacionItem;
			this.precioBaseItem = precioBaseItem;
			this.fehaRegistroItem = fehaRegistroItem;
		}
		/// <summary>
		/// Constructor para insertar
		/// </summary>
		/// <param name="codigoItem"></param>
		/// <param name="idArticulo"></param>
		/// <param name="precioBaseItem"></param>
		/// <param name="fehaRegistroItem"></param>
		public Item(string codigoItem, int idArticulo, double precioBaseItem, DateTime fehaRegistroItem)
		{
			this.codigoItem = codigoItem;
			this.idArticulo = idArticulo;
			this.precioBaseItem = precioBaseItem;
			this.fehaRegistroItem = fehaRegistroItem;
		}
		#endregion
	}
}
