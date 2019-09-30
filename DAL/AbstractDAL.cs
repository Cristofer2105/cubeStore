using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
	public abstract class AbstractDAL
	{
		public abstract void Insert();
		public abstract void Update();
		public abstract void Delete();
		public abstract DataTable Select();

	}
}