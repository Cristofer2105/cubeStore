using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	/// <summary>
	/// Clase Cliente
	/// </summary>
	public class Cliente
	{
		#region atributos y propiedades
		private int idCliente;

		public int IdCliente
		{
			get { return idCliente; }
			set { idCliente = value; }
		}
		private string nombres;

		public string Nombres
		{
			get { return nombres; }
			set { nombres = value; }
		}
		private string primerApellido;

		public string PrimerApellido
		{
			get { return primerApellido; }
			set { primerApellido = value; }
		}
		private string segundoApellido;

		public string SegundoApellido
		{
			get { return segundoApellido; }
			set { segundoApellido = value; }
		}
		private byte estado;

		public byte Estado
		{
			get { return estado; }
			set { estado = value; }
		}
		private DateTime fechaHoraActualizacion;

		public DateTime FechaHoraActualizacion
		{
			get { return fechaHoraActualizacion; }
			set { fechaHoraActualizacion = value; }
		}
		private DateTime fechaHoraRegistro;

		public DateTime FechaHoraRegistro
		{
			get { return fechaHoraRegistro; }
			set { fechaHoraRegistro = value; }
		}
		#endregion
		#region constructores
		/// <summary>
		/// Constructor por defecto Cliente
		/// </summary>
		public Cliente()
		{

		}
		/// <summary>
		/// Constructor para seleccionar todo Cliente
		/// </summary>
		/// <param name="idCliente"></param>
		/// <param name="nombres"></param>
		/// <param name="primerApellido"></param>
		/// <param name="segundoApellido"></param>
		/// <param name="estado"></param>
		/// <param name="fechaHoraActualizacion"></param>
		/// <param name="fechaHoraRegistro"></param>
		public Cliente(int idCliente, string nombres,string primerApellido, string segundoApellido, byte estado, DateTime fechaHoraActualizacion, DateTime fechaHoraRegistro)
		{
			this.idCliente=idCliente;
			this.nombres=nombres;
			this.primerApellido = primerApellido;
			this.segundoApellido=segundoApellido;
			this.estado=estado;
			this.fechaHoraActualizacion=fechaHoraActualizacion;
			this.fechaHoraRegistro=fechaHoraRegistro;
		}
		/// <summary>
		/// Constructor para insertar Cliente
		/// </summary>
		/// <param name="nombres"></param>
		/// <param name="primerApellido"></param>
		/// <param name="segundoApellido"></param>
		/// <param name="fechaHoraRegistro"></param>
		public Cliente(string nombres, string primerApellido, string segundoApellido, DateTime fechaHoraRegistro)
		{
			this.nombres = nombres;
			this.primerApellido = primerApellido;
			this.segundoApellido = segundoApellido;
			this.fechaHoraRegistro = fechaHoraRegistro;
		}
		#endregion
	}
}
