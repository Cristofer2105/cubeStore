using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	/// <summary>
	/// Clase VentaAnulada
	/// </summary>
	public class VentaAnulada
	{
		#region Atributos y Popiedades
		private int idVentaAnulada;

		public int IdVentaAnulada
		{
			get { return idVentaAnulada; }
			set { idVentaAnulada = value; }
		}
		private int idEmpleado;

		public int IdEmpleado
		{
			get { return idEmpleado; }
			set { idEmpleado = value; }
		}
		private DateTime fechaRegistro;

		public DateTime FechaRegistro
		{
			get { return fechaRegistro; }
			set { fechaRegistro = value; }
		}
		private string motivo;

		public string Motivo
		{
			get { return motivo; }
			set { motivo = value; }
		}
		#endregion
		#region Constructores
		/// <summary>
		/// Constructor por defecto VentaAnulada
		/// </summary>
		public VentaAnulada()
		{

		}

		/// <summary>
		/// Constructor para insertar VentaAnulada
		/// </summary>
		/// <param name="idVentaAnulada"></param>
		/// <param name="idEmpleado"></param>
		/// <param name="fechaRegistro"></param>
		/// <param name="motivo"></param>
		public VentaAnulada(int idVentaAnulada, int idEmpleado, DateTime fechaRegistro, string motivo)
		{
			this.idVentaAnulada = idVentaAnulada;
			this.idEmpleado = idEmpleado;
			this.fechaRegistro = fechaRegistro;
			this.motivo = motivo;
		}
		#endregion

	}
}
