using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public class Venta
	{
		#region atributos y propiedades de la clase
		private int idVenta;

		public int IdVenta
		{
			get { return idVenta; }
			set { idVenta = value; }
		}
		private int idCliente;

		public int IdCliente
		{
			get { return idCliente; }
			set { idCliente = value; }
		}
		private double total;

		public double Total
		{
			get { return total; }
			set { total = value; }
		}
		private byte estadoVenta;

		public byte EstadoVenta
		{
			get { return estadoVenta; }
			set { estadoVenta = value; }
		}
		private DateTime fechaActualizacionVenta;

		public DateTime FechaActualizacionVenta
		{
			get { return fechaActualizacionVenta; }
			set { fechaActualizacionVenta = value; }
		}
		private int idEmpleado;

		public int IdEmpleado
		{
			get { return idEmpleado; }
			set { idEmpleado = value; }
		}
		private DateTime fechaRegistroVenta;

		public DateTime FechaRegistroVenta
		{
			get { return fechaRegistroVenta; }
			set { fechaRegistroVenta = value; }
		}

		#endregion
		#region constructores de la clase
		public Venta()
		{

		}
		public Venta(int idVenta, int idCliente, double total, byte estadoVenta, DateTime fechaActualizacionVenta, int idEmpleado, DateTime fechaRegistroVenta)
		{
			this.idVenta=idVenta;
			this.idCliente=idCliente;
			this.total=total;
			this.estadoVenta=estadoVenta;
			this.fechaActualizacionVenta=fechaActualizacionVenta;
			this.idEmpleado=idEmpleado;
			this.fechaRegistroVenta=fechaRegistroVenta;
		}
		public Venta(int idCliente, double total, int idEmpleado, DateTime fechaRegistroVenta)
		{
			this.idCliente = idCliente;
			this.total = total;
			this.idEmpleado = idEmpleado;
			this.fechaRegistroVenta = fechaRegistroVenta;
		}
		#endregion
	}
}
