using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;
using DAL;

namespace BRL
{
	public class ClienteBRL : AbstractBRL
	{
		#region Atributos propiedades y constructores
		private Cliente cli;

		public Cliente Cli
		{
			get { return cli; }
			set { cli = value; }
		}

		private ClienteDAL dal;

		public ClienteDAL Dal
		{
			get { return dal; }
			set { dal = value; }
		}

		public ClienteBRL()
		{
			Dal = new ClienteDAL();
		}
		public ClienteBRL(Cliente cli)
		{
			this.cli = cli;
			dal = new ClienteDAL(cli);
		}
		#endregion
		#region metodos de la clase
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
			dal = new ClienteDAL();
			return dal.Select();
		}

		public override void Update()
		{
			dal.Update();
		}
		public Cliente Get(int id)
		{
			dal = new ClienteDAL();
			return dal.Get(id);
		}
		public DataTable SelectClientesBusqueda(string texto)
		{
			dal = new ClienteDAL();
			return dal.SelectClientesBusqueda(texto);
		}
		#endregion
	}
}