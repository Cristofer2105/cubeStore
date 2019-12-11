using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	/// <summary>
	/// Clase Garantia
	/// </summary>
	public class Garantia
	{
		#region Atributos y Propiedades de la clase
		private int idGarantia;

		public int IdGarantia
		{
			get { return idGarantia; }
			set { idGarantia = value; }
		}
		private DateTime fechaInicio;

		public DateTime FechaInicio
		{
			get { return fechaInicio; }
			set { fechaInicio = value; }
		}
		private DateTime fechaFin;

		public DateTime FechaFin
		{
			get { return fechaFin; }
			set { fechaFin = value; }
		}
		private byte estado;

		public byte Estado
		{
			get { return estado; }
			set { estado = value; }
		}
		private DateTime fechaActualizacion;

		public DateTime FechaActualizacion
		{
			get { return fechaActualizacion; }
			set { fechaActualizacion = value; }
		}
		private DateTime fechaRegistro;

		public DateTime FechaRegistro
		{
			get { return fechaRegistro; }
			set { fechaRegistro = value; }
		}
		#endregion
		#region Constructores de la Clase
		/// <summary>
		/// Clase Garantia
		/// </summary>
		public Garantia()
		{

		}
		/// <summary>
		/// Constructor para seleccionar todo Garantia
		/// </summary>
		/// <param name="idGarantia"></param>
		/// <param name="fechaInicio"></param>
		/// <param name="fechaFin"></param>
		/// <param name="estado"></param>
		/// <param name="fechaActualizacion"></param>
		/// <param name="fechaRegistro"></param>
		public Garantia(int idGarantia, DateTime fechaInicio, DateTime fechaFin, byte estado, DateTime fechaActualizacion, DateTime fechaRegistro)
		{
			this.idGarantia = idGarantia;
			this.fechaInicio = fechaInicio;
			this.fechaFin = fechaFin;
			this.estado = estado;
			this.fechaActualizacion = fechaActualizacion;
			this.fechaRegistro = fechaRegistro;
		}
		/// <summary>
		/// Constructor para insertar Garantia
		/// </summary>
		/// <param name="fechaInicio"></param>
		/// <param name="fechaFin"></param>
		/// <param name="fechaRegistro"></param>
		public Garantia(DateTime fechaInicio, DateTime fechaFin, DateTime fechaRegistro)
		{
			this.fechaInicio = fechaInicio;
			this.fechaFin = fechaFin;
			this.fechaRegistro = fechaRegistro;
		}
		#endregion
	}
}
