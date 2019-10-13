using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Common;

namespace BRL
{
	public class UsuarioBRL : AbstractBRL
	{
		UsuarioDal dal;
		public UsuarioBRL()
		{

		}
		public override void Delete()
		{
			throw new NotImplementedException();
		}

		public override void Insert()
		{
			throw new NotImplementedException();
		}

		public override DataTable Select()
		{
			throw new NotImplementedException();
		}

		public override void Update()
		{
			throw new NotImplementedException();
		}
		public DataTable Login(string usuario, string contrasenia)
		{
			dal = new UsuarioDal();
			return dal.Login(usuario, contrasenia);
		}
	}
}
