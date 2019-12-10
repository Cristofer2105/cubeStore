using Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL
{
	public class ArticuloBRL : AbstractBRL
	{
		#region Atributos propiedades y constructores
		private Articulo art;

		public Articulo Art
		{
			get { return art; }
			set { art = value; }
		}

		private ArticuloDAL dal;

		public ArticuloDAL Dal
		{
			get { return dal; }
			set { dal = value; }
		}
		public ArticuloBRL()
		{

		}
		public ArticuloBRL(Articulo art)
		{
			this.art = art;
			dal = new ArticuloDAL(art);
		}
		#endregion
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
			dal = new ArticuloDAL();
			return dal.Select();
		}
		public DataTable SelectBusquedaArticulos(string texto)
		{
			dal = new ArticuloDAL();
			return dal.SelectBusquedaArticulos(texto);
		}
		
		public override void Update()
		{
			dal.Update();
		}
		public Articulo Get(int idArticulo)
		{
			dal = new ArticuloDAL();
			return dal.Get(idArticulo);
		}
		public DataTable VerificarArticulo(string articulo)
		{
			dal = new ArticuloDAL();
			return dal.VerificarArticulo(articulo);
		}
		public DataTable VerificarArticuloEliminar(int id)
		{
			dal = new ArticuloDAL();
			return dal.VerificarArticuloEliminar(id);
		}
	}
}
