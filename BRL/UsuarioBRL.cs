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
		
		private Usuario user;

		public Usuario User
		{
			get { return user; }
			set { user = value; }
		}
		private UsuarioDal dal;

		public UsuarioDal Dal
		{
			get { return dal; }
			set { dal = value; }
		}
		public UsuarioBRL()
		{

		}
		public UsuarioBRL(Usuario user)
		{
			this.user = user;
			dal = new UsuarioDal(user);
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
		public DataTable Login(string usuario, string contrasenia)
		{
			dal = new UsuarioDal();
			return dal.Login(usuario, contrasenia);
		}
	}
}
