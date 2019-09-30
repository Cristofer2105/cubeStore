using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public class Articulo
	{
		#region Atributos y Propiedades

		private int idArticulo;
		public int IdArticulo
		{
			get { return idArticulo; }
			set { idArticulo = value; }
		}

		private string nombreArticulo;
		public string NombreArticulo
		{
			get { return nombreArticulo; }
			set { nombreArticulo = value; }
		}

		private byte estadoArticulo;
		public byte EstadoArticulo
		{
			get { return estadoArticulo; }
			set { estadoArticulo = value; }
		}

		private DateTime fechaHoraActualizacionArticulo;
		public DateTime FechaHoraActualizacionArticulo
		{
			get { return fechaHoraActualizacionArticulo; }
			set { fechaHoraActualizacionArticulo = value; }
		}
		private byte idCategoria;
		public byte IdCategoria
		{
			get { return idCategoria; }
			set { idCategoria = value; }
		}

		#endregion

		#region Constructores de la clase
		public Articulo(int idArticulo, string nombreArticulo, byte estadoArticulo, DateTime fechaHoraActualizacionArticulo, byte idCategoria)
		{
			this.idArticulo = idArticulo;
			this.nombreArticulo = nombreArticulo;
			this.estadoArticulo = estadoArticulo;
			this.fechaHoraActualizacionArticulo = fechaHoraActualizacionArticulo;
			this.idCategoria = idCategoria;

		}
		/// <summary>
		/// Constructor para el metodo Insert
		/// </summary>
		/// <param name="nombreArticulo"></param>
		public Articulo(string nombreArticulo, byte idCategoria)
		{
			this.nombreArticulo = nombreArticulo;
			this.idCategoria = idCategoria;
		}
		#endregion
	}
}
