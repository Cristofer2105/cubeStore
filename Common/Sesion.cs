using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public static class Sesion
	{
		public static int idSesion;
		public static string usuarioSesion;
		public static string rolSesion;
		public static string VerInfo()
		{
			return "Usuario:  " + usuarioSesion +"\n"+ "\n" + "Rol:  " + rolSesion;
		}		
	}
}
