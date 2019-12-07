using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAL;

namespace BRL
{
	public class SessionBRL
	{
		#region atributos, propiedades, constructores
		private SesionDAL dal;

		public SesionDAL Dal
		{
			get { return dal; }
			set { dal = value; }
		}
		private Session ses;

		public Session Ses
		{
			get { return ses; }
			set { ses = value; }
		}
		public SessionBRL()
		{

		}
		public SessionBRL(Session ses)
		{
			this.ses = ses;
			dal = new SesionDAL(ses);
		}

		#endregion
		#region metodos de la clase
		/// <summary>
		/// Metodo insert sesion BRL
		/// </summary>
		public void Insert()
		{
			dal.Insert();
		}
		#endregion
	}
}
