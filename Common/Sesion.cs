using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	/// <summary>
	/// Clase Sesion
	/// </summary>
	public static class Sesion
	{
		public static int idSesion;
		public static string usuarioSesion;
		public static string rolSesion;
		public static string nombre;
		public static string primerapellido;
		public static string segundoapellido;
		public static string contrasenia;
		public static string VerInfo()
		{
			return "Usuario:  " + usuarioSesion +"\n"+ "\n" + "Rol:  " + rolSesion;
		}		
	}
}
