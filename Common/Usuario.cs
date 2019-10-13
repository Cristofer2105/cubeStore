using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
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
		private string telefonos;

		public string Telefonos
		{
			get { return telefonos; }
			set { telefonos = value; }
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
		public Usuario()
		{

		}
		public Usuario(int idUsuario, string nombres, string primerApellido, string segundoApellido, byte sexo, byte estadoUsuario, DateTime fechaHoraActualizacion, string telefonos, string nombreUsuario, string contrasenia, string rol, byte contraseniaInicaial, string correo)
		{
			this.idUsuario = idUsuario;
			this.nombres = nombres;
			this.primerApellido = primerApellido;
			this.segundoApellido = segundoApellido;
			this.sexo = sexo;
			this.estadoUsuario = estadoUsuario;
			this.fechaHoraActualizacion = fechaHoraActualizacion;
			this.telefonos = telefonos;
			this.nombreUsuario = nombreUsuario;
			this.contrasenia = contrasenia;
			this.rol = rol;
			this.contraseniaInicaial = contraseniaInicaial;
			this.correo = correo;
		}
		public Usuario(string nombres, string primerApellido, string segundoApellido, byte sexo, string telefonos, string nombreUsuario, string contrasenia, string rol, string correo)
		{
		
			this.nombres = nombres;
			this.primerApellido = primerApellido;
			this.segundoApellido = segundoApellido;
			this.sexo = sexo;		
			this.telefonos = telefonos;
			this.nombreUsuario = nombreUsuario;
			this.contrasenia = contrasenia;
			this.rol = rol;		
			this.correo = correo;
		}










	}
}
