using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	/// <summary>
	/// Clase Articulo
	/// </summary>
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
		private int idProvedor;

		public int IdProvedor
		{
			get { return idProvedor; }
			set { idProvedor = value; }
		}
		private DateTime fechaHoraRegistro;

		public DateTime FechaHoraRegistro
		{
			get { return fechaHoraRegistro; }
			set { fechaHoraRegistro = value; }
		}
		private byte foto;

		public byte Foto
		{
			get { return foto; }
			set { foto = value; }
		}


		#endregion

		#region Constructores de la clase
		/// <summary>
		/// Constructor para seleccionar todo Articulo
		/// </summary>
		/// <param name="idArticulo"></param>
		/// <param name="nombreArticulo"></param>
		/// <param name="estadoArticulo"></param>
		/// <param name="fechaHoraActualizacionArticulo"></param>
		/// <param name="idCategoria"></param>
		/// <param name="idProvedor"></param>
		/// <param name="fechaHoraRegistro"></param>
		public Articulo(int idArticulo, string nombreArticulo, byte estadoArticulo, DateTime fechaHoraActualizacionArticulo, byte idCategoria, int idProvedor,DateTime fechaHoraRegistro,byte foto)
		{
			this.idArticulo = idArticulo;
			this.nombreArticulo = nombreArticulo;
			this.estadoArticulo = estadoArticulo;
			this.fechaHoraActualizacionArticulo = fechaHoraActualizacionArticulo;
			this.idCategoria = idCategoria;
			this.idProvedor = idProvedor;
			this.fechaHoraRegistro = fechaHoraRegistro;
			this.foto = foto;
		}
		/// <summary>
		/// Constructor para Insertar Articulo
		/// </summary>
		/// <param name="nombreArticulo"></param>
		/// <param name="idCategoria"></param>
		/// <param name="idProvedor"></param>
		/// <param name="fechaHoraRegistro"></param>
		public Articulo(string nombreArticulo, byte idCategoria,int idProvedor,DateTime fechaHoraRegistro,byte foto)
		{
			this.nombreArticulo = nombreArticulo;
			this.idCategoria = idCategoria;
			this.idProvedor = idProvedor;
			this.fechaHoraRegistro = fechaHoraRegistro;
			this.foto = foto;
		}
		/// <summary>
		/// Constructor por defecto Articulo
		/// </summary>
		public Articulo()
		{

		}
		#endregion
	}
}
