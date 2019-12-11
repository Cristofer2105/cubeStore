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
	/// <summary>
	/// Clase ArticuloBRL
	/// </summary>
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
		/// <summary>
		/// Metodo Delete ArticuloBRL
		/// </summary>
		public override void Delete()
		{
			dal.Delete();
		}
		/// <summary>
		/// Metodo Insert ArticuloBRL
		/// </summary>
		public override void Insert()
		{
			dal.Insert();
		}
		/// <summary>
		/// Metodo Select ArticuloBRL
		/// </summary>
		/// <returns>DataTable</returns>
		public override DataTable Select()
		{
			dal = new ArticuloDAL();
			return dal.Select();
		}
		/// <summary>
		/// Metodo SelectBusquedaArticulo ArticuloBRL
		/// </summary>
		/// <param name="texto"></param>
		/// <returns>DataTable</returns>
		public DataTable SelectBusquedaArticulos(string texto)
		{
			dal = new ArticuloDAL();
			return dal.SelectBusquedaArticulos(texto);
		}
		/// <summary>
		/// Metodo Update ArticuloBRL
		/// </summary>
		public override void Update()
		{
			dal.Update();
		}
		/// <summary>
		/// Metodo Get ArticuloBRL
		/// </summary>
		/// <param name="idArticulo"></param>
		/// <returns>Articulo</returns>
		public Articulo Get(int idArticulo)
		{
			dal = new ArticuloDAL();
			return dal.Get(idArticulo);
		}
		/// <summary>
		/// Metodo VerificarArticulo ArticuloBRL
		/// </summary>
		/// <param name="articulo"></param>
		/// <returns>DataTable</returns>
		public DataTable VerificarArticulo(string articulo)
		{
			dal = new ArticuloDAL();
			return dal.VerificarArticulo(articulo);
		}
		/// <summary>
		/// Metodo VerificarArticuloEliminar ArticuloBRL
		/// </summary>
		/// <param name="id"></param>
		/// <returns>DataTable</returns>
		public DataTable VerificarArticuloEliminar(int id)
		{
			dal = new ArticuloDAL();
			return dal.VerificarArticuloEliminar(id);
		}
	}
}
