using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public class Validate
	{
		public static bool OnlyLettersAndSpaces(string cad)
		{
			for (int i = 0; i < cad.Length; i++)
			{
				if (!Char.IsLetter(cad[i])&&cad[i]!=' ')
				{
				return false;
				}
			}
			return true;
		}
	}
}
