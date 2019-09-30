using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common;

namespace DAL
{

	public class ProvedorDal : AbstractDAL
	{
		private Provedor prov;

		public Provedor Prov
		{
			get { return prov; }
			set { prov = value; }
		}
		public ProvedorDal()
		{

		}
		public ProvedorDal(Provedor prov)
		{
			this.prov = prov;
		}
		public override void Delete()
		{
			throw new NotImplementedException();
		}

		public override void Insert()
		{
			string query = "INSERT INTO Provedor(nit,razonSocialProvedor,latitud,longitud) VALUES(@nit,@razonSocialProvedor,@latitud,@longitud)";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@nit", prov.Nit);
				cmd.Parameters.AddWithValue("@razonSocialProvedor", prov.RazonSocial);
				cmd.Parameters.AddWithValue("@latitud", prov.Latitud);
				cmd.Parameters.AddWithValue("@longitud", prov.Longitud);
				Methods.ExecuteBasicCommand(cmd);
			}
			catch (Exception ex)
			{
				//Escribir Log
				throw ex;
			}
		}

		public override DataTable Select()
		{
			throw new NotImplementedException();
		}

		public override void Update()
		{
			throw new NotImplementedException();
		}
	}


}