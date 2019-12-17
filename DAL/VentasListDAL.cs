using DAL.DataSetcubestoreTableAdapters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	/// <summary>
	/// Clase VentasListDAL
	/// </summary>
	public class VentasListDAL
	{
		public static DataSetcubestore ObtenerListaVentasReporte()
		{
			DataSetcubestore dataSetcubestore = new DataSetcubestore();
			VentasListReportTableAdapter ventaTableAdapter = new VentasListReportTableAdapter();
			try
			{

				ventaTableAdapter.Fill(dataSetcubestore.Tables["VentasListReport"] as DataSetcubestore.VentasListReportDataTable);
			}			
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			return dataSetcubestore;
		}
	}
}
