using Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BRL
{
	public class ProvedorBRL : AbstractBRL
	{
		private Provedor prov;

		public Provedor Prov
		{
			get { return prov; }
			set { prov = value; }
		}

		private ProvedorDal dal;

		public ProvedorDal Dal
		{
			get { return dal; }
			set { dal = value; }
		}
		public ProvedorBRL()
		{

		}
		public ProvedorBRL(Provedor prov)
		{
			this.prov = prov;
			dal = new ProvedorDal(prov);
		}
		public override void Delete()
		{
			throw new NotImplementedException();
		}

		public override void Insert()
		{
			dal.Insert();
		}

		public override DataTable Select()
		{
			throw new NotImplementedException();
		}

		public override void Update()
		{
			throw new NotImplementedException();
		}
	}
}