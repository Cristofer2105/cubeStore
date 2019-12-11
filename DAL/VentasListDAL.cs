using DAL.DataSetcubestoreTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class VentasListDAL
	{
		public static DataSetcubestore ObtenerListaVentasReporte()
		{
			DataSetcubestore dataSetcubestore = new DataSetcubestore();
			VentasListReportTableAdapter ventaTableAdapter = new VentasListReportTableAdapter();
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: ObtenerListaVentasReporte", DateTime.Now));

				ventaTableAdapter.Fill(dataSetcubestore.Tables["VentasListReport"] as DataSetcubestore.VentasListReportDataTable);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return dataSetcubestore;
		}
	}
}
