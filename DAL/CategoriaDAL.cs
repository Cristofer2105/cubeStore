using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common;

namespace DAL
{
	public sealed class CategoriaDAL : AbstractDAL
	{
		#region Atributos Propiedades y Constructores de clase
		private Categoria cat;

		public Categoria Cat
		{
			get { return cat; }
			set { cat = value; }
		}
		public CategoriaDAL()
		{

		}
		public CategoriaDAL(Categoria cat)
		{
			this.cat = cat;
		}

		#endregion
		public override void Delete()
		{
			string query = "UPDATE Categoria SET estadoCategoria=0 , fechaHoraActualizacionCategoria=CURRENT_TIMESTAMP WHERE idCategoria = @idCategoria";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idCategoria", cat.IdCategoria);
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
			string query = "INSERT INTO Categoria(nombreCategoria) VALUES(@nombreCategoria)";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@nombreCategoria",cat.NombreCategoria);
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
			string query = "SELECT * FROM vwCategoriaSelect ORDER BY 2";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				res=Methods.ExecuteDataTableCommand(cmd);
			}
			catch (Exception ex)
			{

				throw ex;
			}
			return res;
		}

		public override void Update()
		{
			string query = "UPDATE Categoria SET nombreCategoria=@nombreCategoria,fechaHoraActualizacionCategoria=CURRENT_TIMESTAMP WHERE idCategoria = @idCategoria";
			try
			{
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idCategoria", cat.IdCategoria);
				cmd.Parameters.AddWithValue("@nombreCategoria", cat.NombreCategoria);
				Methods.ExecuteBasicCommand(cmd);
			}
			catch (Exception ex)
			{
				//Escribir Log
				throw ex;
			}
		}
		public Categoria Get(byte idCategoria)
		{
			Categoria res = null;
			SqlCommand cmd = null;
			SqlDataReader dr = null;
			string query = "SELECT idCategoria,nombreCategoria,estadoCategoria,fechaHoraActualizacionCategoria FROM Categoria WHERE idCategoria=@idCategoria";
			try
			{
				cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
				dr = Methods.ExecuteDataReaderCommand(cmd);

				while (dr.Read())
				{
					res = new Categoria(byte.Parse(dr[0].ToString()), dr[1].ToString(), byte.Parse(dr[2].ToString()), DateTime.Parse(dr[3].ToString()));
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