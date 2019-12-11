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
	/// Clase CategoriaBRL
	/// </summary>
	public class CategoriaBRL : AbstractBRL
	{
		#region Atributos propiedades y constructores
		private Categoria cat;

		public Categoria Cat
		{
			get { return cat; }
			set { cat = value; }
		}

		private CategoriaDAL dal;

		public CategoriaDAL Dal
		{
			get { return dal; }
			set { dal = value; }
		}

		public CategoriaBRL()
		{
			Dal = new CategoriaDAL();
		}
		public CategoriaBRL(Categoria cat)
		{
			this.cat = cat;
			dal = new CategoriaDAL(cat);
		}
		#endregion
		#region Metodos de la Clase
		/// <summary>
		/// Metodo Delete CategoriaBRL
		/// </summary>
		public override void Delete()
		{
			dal.Delete();
		}
		/// <summary>
		/// Metodo Insert CategoriaBRL
		/// </summary>
		public override void Insert()
		{
			dal.Insert();
		}
		/// <summary>
		/// Metodo Select CategoriaBRL
		/// </summary>
		/// <returns>DataTable</returns>
		public override DataTable Select()
		{
			dal = new CategoriaDAL();
			return dal.Select();
		}
		/// <summary>
		/// Metodo SelectBusquedaCategorias CategoriaBRL
		/// </summary>
		/// <param name="texto"></param>
		/// <returns>DataTable</returns>
		public DataTable SelectBusquedaCategorias(string texto)
		{
			dal = new CategoriaDAL();
			return dal.SelectBusquedaCategorias(texto);
		}
		/// <summary>
		/// Metodo Update CategoriaBRL
		/// </summary>
		public override void Update()
		{
			dal.Update();
		}
		/// <summary>
		/// Metodo Get CategoriaBRL
		/// </summary>
		/// <param name="idCategoria"></param>
		/// <returns>Categoria</returns>
		public Categoria Get(byte idCategoria)
		{
			dal = new CategoriaDAL();
			return dal.Get(idCategoria);
		}
		/// <summary>
		/// Metodo SelectCategorias CategoriaBRL
		/// </summary>
		/// <returns>DataTable</returns>
		public DataTable SelectCategorias()
		{
			return Dal.SelectCategorias();
		}
		/// <summary>
		/// Metodo VerificarCategoria CategoriaBRL
		/// </summary>
		/// <param name="categoria"></param>
		/// <returns>DataTable</returns>
		public DataTable VerificarCategoria(string categoria)
		{
			return Dal.VerificarCategoria(categoria);
		}
		/// <summary>
		/// Metodo VerificarCategoriaEliminar CategoriaBRL
		/// </summary>
		/// <param name="id"></param>
		/// <returns>DataTable</returns>
		public DataTable VerificarCategoriaEliminar(int id)
		{
			dal = new CategoriaDAL();
			return dal.VerificarCategoriaEliminar(id);
		}
		#endregion
	}
}