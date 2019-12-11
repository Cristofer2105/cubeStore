using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
	/// <summary>
	/// Clase Abstracta DAL
	/// </summary>
	public abstract class AbstractDAL
	{
		/// <summary>
		/// Abstract Insert
		/// </summary>
		public abstract void Insert();
		/// <summary>
		/// Abstract Update
		/// </summary>
		public abstract void Update();
		/// <summary>
		/// Abstract Delete
		/// </summary>
		public abstract void Delete();
		/// <summary>
		/// Abstract Select
		/// </summary>
		/// <returns>DataTable</returns>
		public abstract DataTable Select();

	}
}