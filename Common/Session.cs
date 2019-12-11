using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	/// <summary>
	/// Clase Session 
	/// </summary>
	public class Session
	{
		#region atributos y propiedades
		private int idSession;

		public int IdSession
		{
			get { return idSession; }
			set { idSession = value; }
		}
		private DateTime inicioSesion;

		public DateTime InicioSesion
		{
			get { return inicioSesion; }
			set { inicioSesion = value; }
		}
		private int idEmpleado;

		public int IdEmpleado
		{
			get { return idEmpleado; }
			set { idEmpleado = value; }
		}
		#endregion

		#region constructores
		/// <summary>
		/// Constructor por defecto
		/// </summary>
		public Session()
		{

		}
		/// <summary>
		/// Constructor para insertar Session
		/// </summary>
		/// <param name="inicioSesion"></param>
		/// <param name="idEmpleado"></param>
		public Session(DateTime inicioSesion, int idEmpleado)
		{
			this.inicioSesion = inicioSesion;
			this.idEmpleado = idEmpleado;
		}
		#endregion

	}
}
