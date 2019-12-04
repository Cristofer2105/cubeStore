using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
	public class ArticuloDAL : AbstractDAL
	{
		#region Atributos Propiedades y Constructores de clase
		private Articulo art;

		public Articulo  Art
		{
			get { return art; }
			set { art = value; }
		}
		public ArticuloDAL()
		{

		}
		public ArticuloDAL(Articulo art)
		{
			this.art = art;
		}

		#endregion
		public override void Delete()
		{
			string query = "UPDATE Articulo SET estadoArticulo=0 , fechaHoraActualizacionArticulo=CURRENT_TIMESTAMP WHERE idArticulo = @idArticulo";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idArticulo", art.IdArticulo);
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
			string query = "INSERT INTO Articulo(nombreArticulo,idCategoria,idProvedor,fechaHoraRegistro) VALUES(@nombreCategoria,@idCategoria,@idProvedor,@fechaHoraRegistro)";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@nombreCategoria", art.NombreArticulo);
				cmd.Parameters.AddWithValue("@idCategoria", art.IdCategoria);
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
			string query = "SELECT * FROM vwArticuloSelect ORDER BY 2";
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
			string query = "";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@nombreArticulo", art.NombreArticulo);
				cmd.Parameters.AddWithValue("@idCategoria", art.IdCategoria);
				cmd.Parameters.AddWithValue("@idArticulo", art.IdArticulo);
				Methods.ExecuteBasicCommand(cmd);
			}
			catch (Exception ex)
			{
				//Escribir Log
				throw ex;
			}
		}
		public Articulo Get(int idArticulo)
		{
			Articulo res = null;
			SqlCommand cmd = null;
			SqlDataReader dr = null;
			string query = "SELECT idArticulo,nombreArticulo,estadoArticulo,fechaHoraActualizacionArticulo,idCategoria,idProvedor,fechaHoraRegistro FROM Articulo WHERE idArticulo=@idArticulo";
			try
			{
				cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idArticulo", idArticulo);
				dr = Methods.ExecuteDataReaderCommand(cmd);

				while (dr.Read())
				{
					res = new Articulo(int.Parse(dr[0].ToString()), dr[1].ToString(), byte.Parse(dr[2].ToString()), DateTime.Parse(dr[3].ToString()), byte.Parse(dr[4].ToString()), int.Parse(dr[5].ToString()), DateTime.Parse(dr[6].ToString()));
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