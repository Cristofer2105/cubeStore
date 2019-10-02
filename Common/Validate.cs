using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
		public static bool SoloTexto(string value)
		{
			string regular_expression = "^[a-zA-Z_áéíóúÁÉÍÓÚ  ]*$";
			Regex regex = new Regex(regular_expression);
			if (regex.IsMatch(value))
			{
				return true;
			}
			return true;
		}
		public static bool TextoNumeros(string value)
		{
			string regular_expression = "^[0-9_a-zA-Z_áéíóúÁÉÍÓÚ  ]*$";
			Regex regex = new Regex(regular_expression);
			if (regex.IsMatch(value))
			{
				return true;
			}
			return true;
		}
		public static bool NitText(string value)
		{
			string regular_expression = "^[0-9_ ]*$";
			Regex regex = new Regex(regular_expression);
			if (regex.IsMatch(value)&&value.Length<14)
			{
				return true;
			}
			return true;
		}
	}
}
