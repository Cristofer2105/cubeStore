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
			dal.Delete();
		}

		public override void Insert()
		{
			dal.Insert();
		}

		public override DataTable Select()
		{
			dal = new UsuarioDal();
			return dal.Select();
		}

		public override void Update()
		{
			dal.Update();
		}
		public DataTable Login(string usuario, string contrasenia)
		{
			dal = new UsuarioDal();
			return dal.Login(usuario, contrasenia);
		}
		public Usuario Get(int idUsuario)
		{
			dal = new UsuarioDal();
			return dal.Get(idUsuario);
		}
	}
}
