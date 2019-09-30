using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL
{
	public abstract class AbstractBRL
	{
		public abstract void Insert();
		public abstract void Update();
		public abstract void Delete();
		public abstract DataTable Select();
	}
}
