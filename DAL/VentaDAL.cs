using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common;

namespace DAL
{
	public class VentaDAL : AbstractDAL
	{
		#region Atributos Propiedades y Constructores de clase
		private VentaAnulada ventAn;

		public VentaAnulada VentAn
		{
			get { return ventAn; }
			set { ventAn = value; }
		}

		private Venta vtn;

		public Venta Vtn
		{
			get { return vtn; }
			set { vtn = value; }
		}
		private List<VentaItem> vti;

		public List<VentaItem> Vti
		{
			get { return vti; }
			set { vti = value; }
		}
		private Garantia grt;

		public Garantia Grt
		{
			get { return grt; }
			set { grt = value; }
		}
		private Cliente cli;

		public Cliente Cli
		{
			get { return cli; }
			set { cli = value; }
		}
		private Item itm;

		public Item Art
		{
			get { return itm; }
			set { itm = value; }
		}
		public VentaDAL(Venta vtn,List<VentaItem> vti,Garantia grt)
		{
			this.vtn=vtn;
			this.vti = vti;
			this.grt = grt;
		}
		public VentaDAL()
		{

		}
		public VentaDAL(Venta vtn)
		{
			this.vtn = vtn;
		}
		
		#endregion
		#region metodos de la clase
		public override void Delete()
		{
			throw new NotImplementedException();
		}
		/// <summary>
		/// Metodo Insert Ventas con transacciones
		/// </summary>
		public void InsertVentas()
		{
			SqlConnection connection = Methods.GetConnection();
			connection.Open();

			SqlCommand command = connection.CreateCommand();
			//inicio transaccion
			SqlTransaction transaction;

			transaction = connection.BeginTransaction("Venta");
			command.Connection = connection;
			command.Transaction = transaction;
			try
			{
				int id = Methods.GetCurrentValueIDTable("Venta");
				//query 1 Venta
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Insert con Transacciones de una Venta", DateTime.Now));
				command.CommandText = "INSERT INTO Venta(idCliente,total,idEmpleado,fechaRegistro) VALUES(@idCliente,@total,@idEmpleado,@fechaRegistro)";
				command.Parameters.AddWithValue("@idCliente", vtn.IdCliente);
				command.Parameters.AddWithValue("@total", vtn.Total);
				command.Parameters.AddWithValue("@idEmpleado", vtn.IdEmpleado);
				command.Parameters.AddWithValue("@fechaRegistro", vtn.FechaRegistroVenta);
				command.ExecuteNonQuery();



				//query Venta Item
				command.CommandText = "INSERT INTO VentaItem(idVenta,idItem,precioUnitario) VALUES(@idVenta,@idItem,@precioUnitario)";
				foreach (var producto in this.vti)
				{
					command.Parameters.AddWithValue("@idVenta", id);
					command.Parameters.AddWithValue("@idItem", producto.IdItem);
					command.Parameters.AddWithValue("@precioUnitario", producto.PrecioUnitario);
					command.ExecuteNonQuery();
					command.Parameters.Clear();

				}

				//query Garantia
				command.CommandText = "INSERT INTO Garantia(idGarantia,fechaInicioGarantia,fechafinGarantia,fechaRegistroGarantia) VALUES(@idGarantia,@fechaInicioGarantia,@fechafinGarantia,@fechaRegistroGarantia)";
				command.Parameters.AddWithValue("@idGarantia", id);
				command.Parameters.AddWithValue("@fechaInicioGarantia", grt.FechaInicio);
				command.Parameters.AddWithValue("@fechafinGarantia", grt.FechaFin);
				command.Parameters.AddWithValue("@fechaRegistroGarantia", grt.FechaRegistro);
				command.ExecuteNonQuery();

				//qury estado
				command.CommandText = "UPDATE Item SET estadoItem=3 WHERE estadoItem=2";
				command.ExecuteNonQuery();

				// Attempt to commit the transaction.
				transaction.Commit();
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro con Transacciones Insertado, Usuario:{1}", DateTime.Now, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				transaction.Rollback();
				string query = "UPDATE Item SET estadoItem=1 WHERE estadoItem=2";
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				Methods.ExecuteBasicCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
		}
		public void AnularVenta()
		{
			SqlConnection connection = Methods.GetConnection();
			connection.Open();

			SqlCommand command = connection.CreateCommand();
			//inicio transaccion
			SqlTransaction transaction;

			transaction = connection.BeginTransaction("AnularVenta");
			command.Connection = connection;
			command.Transaction = transaction;

			try
			{
				//query 1 Venta
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo AnularVenta con Transacciones de una Venta", DateTime.Now));
				command.CommandText = "UPDATE Venta SET estadoVenta=0, total=0 WHERE idVenta=@idVenta";
				command.Parameters.AddWithValue("@idVenta", vtn.IdVenta);
				command.ExecuteNonQuery();
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Venta Anulado, Usuario:{1}", DateTime.Now, Sesion.usuarioSesion));



				//query Venta Item
				command.CommandText = "UPDATE Item SET estadoItem=1 WHERE idItem=@idItem";
				foreach (var producto in this.vti)
				{
					command.Parameters.AddWithValue("@idItem", producto.IdItem);
					command.ExecuteNonQuery();
					command.Parameters.Clear();

				}

				//query Garantia
				command.CommandText = "UPDATE Garantia SET estadoGarantia=0 WHERE idGarantia=@idGarantia";
				command.Parameters.AddWithValue("@idGarantia",grt.IdGarantia);
				command.ExecuteNonQuery();

				//query Venta Anulada
				command.CommandText = "INSERT INTO VentaAnulada(idVentaAnulada,idEmpleado,fechaHora,motivo) VALUES (@idVentaAnulada,@idEmpleado,@fechaHora,@motivo)";
				command.Parameters.AddWithValue("@idVentaAnulada", ventAn.IdVentaAnulada);
				command.Parameters.AddWithValue("@idEmpleado", Sesion.idSesion);
				command.Parameters.AddWithValue("@fechaHora", ventAn.FechaRegistro);
				command.Parameters.AddWithValue("@motivo", ventAn.Motivo);
				command.ExecuteNonQuery();


				// Attempt to commit the transaction.
				transaction.Commit();
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro con Transacciones Anulado, Usuario:{1}", DateTime.Now, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				transaction.Rollback();
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
		
		}
		public override DataTable Select()
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwSelectVentas";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo de Select de Ventas", DateTime.Now));
				SqlCommand cmd = Methods.CreateBasicCommand(query);
				res = Methods.ExecuteDataTableCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registros Seleccionados, Usuario:{1}", DateTime.Now, Sesion.usuarioSesion));
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return res;
		}
		
		public DataTable SelectBusquedaVenta(string texto)
		{
			DataTable res = new DataTable();
			string query = "SELECT * FROM vwSelectVentas ";
			query = query + " WHERE Cliente LIKE @texto ";
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del metodo Busqueda de Items", DateTime.Now));

				SqlCommand cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@texto", "%" + texto + "%");
				res = Methods.ExecuteDataTableCommand(cmd);
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Buscado, Usuario:{1}", DateTime.Now, Sesion.usuarioSesion));

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return res;
		}
		public Venta Get(int id)
		{
			Venta res = null;
			SqlCommand cmd = null;
			SqlDataReader dr = null;
			string query = "SELECT idVenta,idCliente,total,estadoVenta,fechaHoraActualizacionVenta,idEmpleado,fechaRegistro FROM Venta WHERE idVenta=@idVenta";
			try
			{
				cmd = Methods.CreateBasicCommand(query);
				cmd.Parameters.AddWithValue("@idVenta", id);
				dr = Methods.ExecuteDataReaderCommand(cmd);

				while (dr.Read())
				{
					res = new Venta(int.Parse(dr[0].ToString()), int.Parse(dr[1].ToString()), double.Parse(dr[2].ToString()), byte.Parse(dr[3].ToString()), DateTime.Parse(dr[4].ToString()), int.Parse(dr[5].ToString()), DateTime.Parse(dr[6].ToString()));
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
		public override void Update()
		{
			throw new NotImplementedException();
		}

		public override void Insert()
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}