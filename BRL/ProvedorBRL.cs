using Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BRL
{
	/// <summary>
	/// Clase ProvedorBRL
	/// </summary>
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
		/// <summary>
		/// Metodo Delete ProvedorBRL
		/// </summary>
		public override void Delete()
		{
			dal.Delete();
		}
		/// <summary>
		/// Metodo Insert ProvedorBRL
		/// </summary>
		public override void Insert()
		{
			dal.Insert();
		}
		/// <summary>
		/// Metodo Select ProvedorBRL
		/// </summary>
		/// <returns>DataTable</returns>
		public override DataTable Select()
		{
			dal = new ProvedorDal();
			return dal.Select();
		}
		/// <summary>
		/// Metodo SelectTodo ProvedorBRL
		/// </summary>
		/// <returns></returns>
		public DataTable SelectTodo()
		{
			dal = new ProvedorDal();
			return dal.SelectTodo();
		}
		/// <summary>
		/// Metodo SelectBusquedaProvedores ProvedorBRL
		/// </summary>
		/// <param name="texto"></param>
		/// <returns>DataTable</returns>
		public DataTable SelectBusquedaProvedores(string texto)
		{
			dal = new ProvedorDal();
			return dal.SelectBusquedaProvedores(texto);
		}
		/// <summary>
		/// Metodo Update ProvedorDAL
		/// </summary>
		public override void Update()
		{
			dal.Update();
		}
		/// <summary>
		/// Metodo Get ProvedorBRL
		/// </summary>
		/// <param name="idProvedor"></param>
		/// <returns>Provedor</returns>
		public Provedor Get(int idProvedor)
		{
			dal = new ProvedorDal();
			return dal.Get(idProvedor);
		}
		/// <summary>
		/// Metodo SelectProvedores ProvedorBRL
		/// </summary>
		/// <returns></returns>
		public DataTable SelectProvedores()
		{
			return Dal.SelectProvedores();
		}
		/// <summary>
		/// Metodo VerificarProvedor ProvedorBRL
		/// </summary>
		/// <param name="provedor"></param>
		/// <returns>DataTable</returns>
		public DataTable VerificarProvedor(string provedor)
		{
			return Dal.VerificarProvedor(provedor);
		}
		/// <summary>
		/// VerificarProvedorEliminar
		/// </summary>
		/// <param name="id"></param>
		/// <returns>DataTable</returns>
		public DataTable VerificarProvedorEliminar(int id)
		{
			dal = new ProvedorDal();
			return dal.VerificarProvedorEliminar(id);
		}
	}
}