using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;
using DAL;

namespace BRL
{
	public class ItemBRL : AbstractBRL
	{
		#region Atributos propiedades y constructores
		private Item itm;

		public Item Itm
		{
			get { return itm; }
			set { itm = value; }
		}

		private ItemDAL dal;

		public ItemDAL Dal
		{
			get { return dal; }
			set { dal = value; }
		}
		public ItemBRL()
		{

		}
		public ItemBRL(Item itm)
		{
			this.itm = itm;
			dal = new ItemDAL(itm);
		}
		#endregion
		#region Metodos de la clase
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
			dal = new ItemDAL();
			return dal.Select();
		}

		public override void Update()
		{
			dal.Update();
		}
		public Item Get(int id)
		{
			dal = new ItemDAL();
			return dal.Get(id);
		}
		public DataTable SelectArticulos(string texto)
		{
			dal = new ItemDAL();
			return dal.SelectArticulos(texto);
		}
		public DataTable SelectItems(string texto)
		{
			dal = new ItemDAL();
			return dal.SelectItems(texto);
		}
		#endregion
	}
}