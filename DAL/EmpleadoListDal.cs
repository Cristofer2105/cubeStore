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

				empleadoTableAdapter.Fill(dataSetcubestore.Tables["EmpleadoListReport"] as DataSetcubestore.EmpleadoListReportDataTable);
			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			return dataSetcubestore;
		}
	}
}
