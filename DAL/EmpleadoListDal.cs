using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DataSetcubestoreTableAdapters;

namespace DAL
{
	/// <summary>
	/// Clase EmpleadoListDAL
	/// </summary>
	public class EmpleadoListDal
	{
		public static DataSetcubestore ObtenerListaEmpleadosReporte()
		{
			DataSetcubestore dataSetcubestore = new DataSetcubestore();
			EmpleadoListReportTableAdapter empleadoTableAdapter = new EmpleadoListReportTableAdapter();
			try
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: ObtenerListaEmpleadosReporte", DateTime.Now));

				empleadoTableAdapter.Fill(dataSetcubestore.Tables["EmpleadoListReport"] as DataSetcubestore.EmpleadoListReportDataTable);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return dataSetcubestore;
		}
	}
}
