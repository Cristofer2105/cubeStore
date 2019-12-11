using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	/// <summary>
	/// Clase Categoria
	/// </summary>
    public class Categoria
    {
		#region Atributos y Propiedades

		private byte idCategoria;
		public byte IdCategoria
		{
			get { return idCategoria; }
			set { idCategoria = value; }
		}

		private string nombreCategoria;
		public string NombreCategoria
		{
			get { return nombreCategoria; }
			set { nombreCategoria = value; }
		}

		private byte estadoCategoria;
		public byte EstadoCategoria
		{
			get { return estadoCategoria; }
			set { estadoCategoria = value; }
		}

		private DateTime fechaHoraActualizacionCategoria;
		public DateTime FechaHoraActualizacionCategoria
		{
			get { return fechaHoraActualizacionCategoria; }
			set { fechaHoraActualizacionCategoria = value; }
		}
		private DateTime fechaHoraRegistroCat;

		public DateTime FechaHoraRegistroCat
		{
			get { return fechaHoraRegistroCat; }
			set { fechaHoraRegistroCat = value; }
		}


		#endregion

		#region Constructores de la clase
		/// <summary>
		/// Constructor que inicializa todo Categoria
		/// </summary>
		/// <param name="idCategoria"></param>
		/// <param name="nombreCategoria"></param>
		/// <param name="estadoCategoria"></param>
		/// <param name="fechaHoraActualizacionCategoria"></param>
		public Categoria(byte idCategoria, string nombreCategoria, byte estadoCategoria, DateTime fechaHoraActualizacionCategoria)
		{
			this.idCategoria = idCategoria;
			this.nombreCategoria = nombreCategoria;
			this.estadoCategoria = estadoCategoria;
			this.fechaHoraActualizacionCategoria = fechaHoraActualizacionCategoria;
		}
		/// <summary>
		/// Constructor para el metodo Insert Categoria
		/// </summary>
		/// <param name="nombreCategoria"></param>
		public Categoria(string nombreCategoria,DateTime fechaHoraRegistroCat)
		{			
			this.nombreCategoria = nombreCategoria;			
			this.fechaHoraRegistroCat = fechaHoraRegistroCat;
		}
		public Categoria(byte idCategoria, string nombreCategoria)
		{
			this.idCategoria = idCategoria;
			this.nombreCategoria = nombreCategoria;
		}
		#endregion
	}
}
