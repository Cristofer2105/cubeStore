using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common;

namespace DAL
{
	/// <summary>
	/// Clase ProvedorDAL
	/// </summary>
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
		/// <summary>
		/// Metodo Delete ProvedorDAL
		/// </summary>
		public override void Delete()
		{
			string query = "UPDATE Provedor SET estadoProvedor=0 , fechaHoraActualizacionProvedor=CURRENT_TIMESTAMP WHERE idProvedor = @idProvedor";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Delete Provedor", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idProvedor", prov.IdProvedor);
				Methods.ExecuteBasicCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Fin del metodo Delete Provedor", DateTime.Now));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
		}
		/// <summary>
		/// Metodo Insert ProvedorDAL
		/// </summary>
		public override void Insert()
		{
			string query = "INSERT INTO Provedor(razonSocialProvedor,latitud,longitud,fechaRegistro) VALUES(@razonSocialProvedor,@latitud,@longitud,@fechaRegistro)";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Insert Provedor", DateTime.Now));
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@razonSocialProvedor", prov.RazonSocial);
				cmd.Parameters.AddWithValue("@latitud", prov.Latitud);
				cmd.Parameters.AddWithValue("@longitud", prov.Longitud);
				cmd.Parameters.AddWithValue("@fechaRegistro", prov.FechaHoraRegistro);
				Methods.ExecuteBasicCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Fin del metodo Insert Provedor", DateTime.Now));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
		}
		/// <summary>
		/// Metodo Select ProvedorDAL
		/// </summary>
		/// <returns>DataTable</returns>
		public override DataTable Select()
		{
			System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Select Provedor", DateTime.Now));
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwProvedorSelect";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				res = Methods.ExecuteDataTableCommand(cmd);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return res;
		}
		/// <summary>
		/// Metodo SelectTodo ProvedorDAL
		/// </summary>
		/// <returns>DataTable</returns>
		public  DataTable SelectTodo()
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwProvedorSelectTodo";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo SelectTodo Provedor", DateTime.Now));
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				res = Methods.ExecuteDataTableCommand(cmd);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return res;
		}
		/// <summary>
		/// Metodo Update ProvedorDAL
		/// </summary>
		public override void Update()
		{
			string query = "UPDATE Provedor SET razonSocialProvedor=@razonSocialProvedor,latitud=@latitud,longitud=@longitud,fechaHoraActualizacionProvedor=CURRENT_TIMESTAMP WHERE idProvedor = @idProvedor";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Update Provedor", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idProvedor", prov.IdProvedor);		
				cmd.Parameters.AddWithValue("@razonSocialProvedor", prov.RazonSocial);
				cmd.Parameters.AddWithValue("@latitud", prov.Latitud);
				cmd.Parameters.AddWithValue("@longitud", prov.Longitud);
				Methods.ExecuteBasicCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Fin del metodo Update Provedor", DateTime.Now));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
		}
		/// <summary>
		/// Metodo Get ProvedorDAL
		/// </summary>
		/// <param name="idProvedor"></param>
		/// <returns>Provedor</returns>
		public Provedor Get(int idProvedor)
		{
			Provedor res = null;
			SqlCommand cmd = null;
			SqlDataReader dr = null;
			string query = "SELECT idProvedor,razonSocialProvedor,estadoProvedor,fechaHoraActualizacionProvedor,latitud,longitud,fechaRegistro FROM Provedor WHERE idProvedor=@idProvedor";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Get Provedor", DateTime.Now));
				cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idProvedor", idProvedor);
				dr = Methods.ExecuteDataReaderCommand(cmd);

				while (dr.Read())
				{
					res = new Provedor( int.Parse(dr[0].ToString()), dr[1].ToString(),byte.Parse(dr[2].ToString()), Convert.ToDateTime(dr[3].ToString()),double.Parse(dr[4].ToString()), double.Parse(dr[5].ToString()), Convert.ToDateTime(dr[6].ToString()));
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			finally
			{
				cmd.Connection.Close();
				dr.Close();
			}
			return res;
		}
		/// <summary>
		/// Metodo SelectProvedores ProvedorDAL
		/// </summary>
		/// <returns>DataTable</returns>
		public DataTable SelectProvedores()
		{
			DataTable res = new DataTable();
			string query = "SELECT idProvedor,razonSocialProvedor FROM Provedor WHERE estadoProvedor=1";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo SelectProvedores", DateTime.Now));
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				res = Methods.ExecuteDataTableCommand(cmd);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return res;
		}
		/// <summary>
		/// Metodo SelectBusquedaProvedores ProvedorDAL
		/// </summary>
		/// <param name="texto"></param>
		/// <returns>DataTable</returns>
		public DataTable SelectBusquedaProvedores(string texto)
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwProvedorSelect ";
			query = query + " WHERE  [Razon Social] LIKE @texto ";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Busqueda de Provedor", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@texto", "%" + texto + "%");
				res = Methods.ExecuteDataTableCommand(cmd);

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return res;
		}
		/// <summary>
		/// Metodo VerificarProvedor ProvedorDAL
		/// </summary>
		/// <param name="provedor"></param>
		/// <returns>DataTable</returns>
		public DataTable VerificarProvedor(string provedor)
		{
			DataTable dt = new DataTable();
			string query = "SELECT * FROM Provedor WHERE razonSocialProvedor=@razonSocialProvedor";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo verificar Provedor", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@razonSocialProvedor", provedor);
				dt = Methods.ExecuteDataTableCommand(cmd);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return dt;
		}
		/// <summary>
		/// Metodo VerificarProvedorEliminar
		/// </summary>
		/// <param name="id"></param>
		/// <returns>DataTable</returns>
		public DataTable VerificarProvedorEliminar(int id)
		{
			DataTable dt = new DataTable();
			string query = "SELECT * FROM Categoria C INNER JOIN Articulo A ON A.idCategoria=C.idCategoria WHERE C.idCategoria=@id AND A.estadoArticulo=1";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo verificar Provedor", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@id", id);
				dt = Methods.ExecuteDataTableCommand(cmd);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return dt;
		}
	}
}