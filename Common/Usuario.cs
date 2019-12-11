using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	/// <summary>
	/// Clase Usuario
	/// </summary>
	public class Usuario
	{
		private int idUsuario;

		public int IdUsuario
		{
			get { return idUsuario; }
			set { idUsuario = value; }
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
		private byte sexo;

		public byte Sexo
		{
			get { return sexo; }
			set { sexo = value; }
		}
		private byte estadoUsuario;

		public byte EstadoUsuario
		{
			get { return estadoUsuario; }
			set { estadoUsuario = value; }
		}
		private DateTime fechaHoraActualizacion;

		public DateTime FechaHoraActualizacion
		{
			get { return fechaHoraActualizacion; }
			set { fechaHoraActualizacion = value; }
		}
		private string nombreUsuario;

		public string NombreUsuario
		{
			get { return nombreUsuario; }
			set { nombreUsuario = value; }
		}
		private string contrasenia;

		public string Contrasenia
		{
			get { return contrasenia; }
			set { contrasenia = value; }
		}
		private string rol;

		public string Rol
		{
			get { return rol; }
			set { rol = value; }
		}
		private byte contraseniaInicaial;

		public byte ContraseniaInicaial
		{
			get { return contraseniaInicaial; }
			set { contraseniaInicaial = value; }
		}
		private string correo;

		public string Correo
		{
			get { return correo; }
			set { correo = value; }
		}
		private DateTime fechaRegistro;

		public DateTime FechaRegistro
		{
			get { return fechaRegistro; }
			set { fechaRegistro = value; }
		}
		/// <summary>
		/// Constructor por defecto
		/// </summary>
		public Usuario()
		{

		}
		/// <summary>
		/// Constructor que inicializa todo Usuario
		/// </summary>
		/// <param name="idUsuario"></param>
		/// <param name="nombres"></param>
		/// <param name="primerApellido"></param>
		/// <param name="segundoApellido"></param>
		/// <param name="sexo"></param>
		/// <param name="estadoUsuario"></param>
		/// <param name="fechaHoraActualizacion"></param>
		/// <param name="nombreUsuario"></param>
		/// <param name="contrasenia"></param>
		/// <param name="rol"></param>
		/// <param name="contraseniaInicaial"></param>
		/// <param name="correo"></param>
		/// <param name="fechaRegistro"></param>
		public Usuario(int idUsuario, string nombres, string primerApellido, string segundoApellido, byte sexo, byte estadoUsuario, DateTime fechaHoraActualizacion, string nombreUsuario, string contrasenia, string rol, byte contraseniaInicaial, string correo,DateTime fechaRegistro)
		{
			this.idUsuario = idUsuario;
			this.nombres = nombres;
			this.primerApellido = primerApellido;
			this.segundoApellido = segundoApellido;
			this.sexo = sexo;
			this.estadoUsuario = estadoUsuario;
			this.fechaHoraActualizacion = fechaHoraActualizacion;
			this.nombreUsuario = nombreUsuario;
			this.contrasenia = contrasenia;
			this.rol = rol;
			this.contraseniaInicaial = contraseniaInicaial;
			this.correo = correo;
			this.fechaRegistro = fechaRegistro;
		}
		/// <summary>
		/// Constructor para Insertar Usuario
		/// </summary>
		/// <param name="nombres"></param>
		/// <param name="primerApellido"></param>
		/// <param name="segundoApellido"></param>
		/// <param name="sexo"></param>
		/// <param name="nombreUsuario"></param>
		/// <param name="contrasenia"></param>
		/// <param name="rol"></param>
		/// <param name="correo"></param>
		/// <param name="fechaRegistro"></param>
		public Usuario(string nombres, string primerApellido, string segundoApellido, byte sexo, string nombreUsuario, string contrasenia, string rol, string correo,DateTime fechaRegistro)
		{
		
			this.nombres = nombres;
			this.primerApellido = primerApellido;
			this.segundoApellido = segundoApellido;
			this.sexo = sexo;		
			this.nombreUsuario = nombreUsuario;
			this.contrasenia = contrasenia;
			this.rol = rol;		
			this.correo = correo;
			this.fechaRegistro = fechaRegistro;
		}

		public Usuario(int idUsuario, string nombres, string primerApellido, string segundoApellido, string correo)
		{
			this.idUsuario = idUsuario;
			this.nombres = nombres;
			this.primerApellido = primerApellido;
			this.segundoApellido = segundoApellido;
			this.correo = correo;
		}
		public Usuario(string contrasenia,string nombreUsuario,byte contraseniaInicaial)
		{
			this.contrasenia = contrasenia;	
			this.nombreUsuario = nombreUsuario;
			this.contraseniaInicaial = contraseniaInicaial;
		}










	}
}
