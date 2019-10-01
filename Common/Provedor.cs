using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public class Provedor
	{
		private int idProvedor;

		public int IdProvedor
		{
			get { return idProvedor; }
			set { idProvedor = value; }
		}

		private string nit;

		public string Nit
		{
			get { return nit; }
			set { nit = value; }
		}

		private string razonSocial;

		public string RazonSocial
		{
			get { return razonSocial; }
			set { razonSocial = value; }
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
		private double latitud;

		public double Latitud
		{
			get { return latitud; }
			set { latitud = value; }
		}

		private double longitud;

		public double Longitud
		{
			get { return longitud; }
			set { longitud = value; }
		}


		public Provedor()
		{

		}

		public Provedor(int idProvedor, string nit,string razonSocial, byte estado, DateTime fechaHoraActualizacion, double latitud, double longitud)
		{
			this.idProvedor=idProvedor;
			this.nit=nit;
			this.razonSocial=razonSocial;
			this.estado=estado;
			this.fechaHoraActualizacion=fechaHoraActualizacion;
			this.latitud = latitud;
			this.longitud = longitud;
		}
		public Provedor(string nit, string razonSocial, double latitud, double longitud)
		{		
			this.nit = nit;
			this.razonSocial = razonSocial;
			this.latitud = latitud;
			this.longitud = longitud;
		}





	}
}
