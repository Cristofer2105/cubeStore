using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BRL
{
	public sealed class ConfigBRL
	{
		private ConfigDAL dal;

		public ConfigDAL Dal
		{
			get { return dal; }
			set { dal = value; }
		}

		public DataTable Select()
		{
			dal = new ConfigDAL();
			return dal.Select();
		}
	}
}