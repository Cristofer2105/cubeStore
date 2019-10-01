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
			string query = "UPDATE Provedor SET estadoProvedor=0 , fechaHoraActualizacionProvedor=CURRENT_TIMESTAMP WHERE idProvedor = @idProvedor";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idProvedor", prov.IdProvedor);
				Methods.ExecuteBasicCommand(cmd);
			}
			catch (Exception ex)
			{
				//Escribir Log
				throw ex;
			}
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

			DataTable res = new DataTable();
			string query = "SELECT * FROM vwProvedorSelect";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				res = Methods.ExecuteDataTableCommand(cmd);
			}
			catch (Exception ex)
			{

				throw ex;
			}
			return res;
		}
		
		public  DataTable SelectTodo()
		{

			DataTable res = new DataTable();
			string query = "SELECT * FROM vwProvedorSelectTodo";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				res = Methods.ExecuteDataTableCommand(cmd);
			}
			catch (Exception ex)
			{

				throw ex;
			}
			return res;
		}
		public override void Update()
		{

			string query = "UPDATE Provedor SET nit=@nit,razonSocialProvedor=@razonSocialProvedor,latitud=@latitud,longitud=@longitud,fechaHoraActualizacionProvedor=CURRENT_TIMESTAMP WHERE idProvedor = @idProvedor";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idProvedor", prov.IdProvedor);
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
		public Provedor Get(int idProvedor)
		{
			Provedor res = null;
			SqlCommand cmd = null;
			SqlDataReader dr = null;
			string query = "SELECT idProvedor,nit,razonSocialProvedor,estadoProvedor,latitud,longitud,fechaHoraActualizacionProvedor FROM Provedor WHERE idProvedor=@idProvedor";
			try
			{
				cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idProvedor", idProvedor);
				dr = Methods.ExecuteDataReaderCommand(cmd);

				while (dr.Read())
				{
					res = new Provedor( int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(),byte.Parse(dr[3].ToString()), Convert.ToDateTime(dr[6].ToString()),double.Parse(dr[4].ToString()), double.Parse(dr[5].ToString()));
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				cmd.Connection.Close();
				dr.Close();
			}
			return res;
		}
	}


}