using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BRL
{
	public class MethodsBRL
	{
		public static int GetMaxIDTable(string id, string tabla)
		{
			return Methods.GetMaxIDTable(id, tabla);
		}
	}
}
