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
			Dal = new ProvedorDal();
		}
		public ProvedorBRL(Provedor prov)
		{
			this.prov = prov;
			dal = new ProvedorDal(prov);
		}

		public override void Delete()
		{
			dal.Delete();
		}

		public override void Insert()
		{
			dal.Insert();
		}

		public override DataTable Select()
		{
			dal = new ProvedorDal();
			return dal.Select();
		}

		public DataTable SelectTodo()
		{
			dal = new ProvedorDal();
			return dal.SelectTodo();
		}
		public DataTable SelectBusquedaProvedores(string texto)
		{
			dal = new ProvedorDal();
			return dal.SelectBusquedaProvedores(texto);
		}
		
		public override void Update()
		{
			dal.Update();
		}
		public Provedor Get(int idProvedor)
		{
			dal = new ProvedorDal();
			return dal.Get(idProvedor);
		}
		public DataTable SelectProvedores()
		{
			return Dal.SelectProvedores();
		}
	}
}