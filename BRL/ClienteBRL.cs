using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;
using DAL;

namespace BRL
{
	/// <summary>
	/// Clase ClienteBRL
	/// </summary>
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
		/// <summary>
		/// Metodo Delete ClienteBRL
		/// </summary>
		public override void Delete()
		{
			dal.Delete();
		}
		/// <summary>
		/// Metodo Insert ClienteBRL
		/// </summary>
		public override void Insert()
		{
			dal.Insert();
		}
		/// <summary>
		/// Metodo Select ClienteBRL
		/// </summary>
		/// <returns></returns>
		public override DataTable Select()
		{
			dal = new ClienteDAL();
			return dal.Select();
		}
		/// <summary>
		/// Metodo Update ClienteBRL
		/// </summary>
		public override void Update()
		{
			dal.Update();
		}
		/// <summary>
		/// Metodo Get ClienteBRL
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Cliente</returns>
		public Cliente Get(int id)
		{
			dal = new ClienteDAL();
			return dal.Get(id);
		}
		/// <summary>
		/// Metodo SelectClientesBusqueda ClienteBRL
		/// </summary>
		/// <param name="texto"></param>
		/// <returns>DataTable</returns>
		public DataTable SelectClientesBusqueda(string texto)
		{
			dal = new ClienteDAL();
			return dal.SelectClientesBusqueda(texto);
		}
		#endregion
	}
}