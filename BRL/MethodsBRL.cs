using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BRL
{
	/// <summary>
	/// Clase MethodsBRL
	/// </summary>
	public class MethodsBRL
	{
		/// <summary>
		/// Metodo GetMaxIDTable MethodsBRL
		/// </summary>
		/// <param name="id"></param>
		/// <param name="tabla"></param>
		/// <returns></returns>
		public static int GetMaxIDTable(string id, string tabla)
		{
			return Methods.GetMaxIDTable(id, tabla);
		}
	}
}
