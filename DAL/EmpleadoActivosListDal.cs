using DAL.DataSetcubestoreTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	/// <summary>
	/// Empleado Activo DAL
	/// </summary>
	public class EmpleadoActivosListDal
	{
		/// <summary>
		/// Obtener Empleados
		/// </summary>
		/// <returns></returns>
		public static DataSetcubestore ObtenerListaEmpleadosActivosReporte()
		{
			DataSetcubestore dataSetcubestore = new DataSetcubestore();
			EmpleadoActivoTableAdapter empleadoActivoTableAdapter = new EmpleadoActivoTableAdapter();
			try
			{

				empleadoActivoTableAdapter.Fill(dataSetcubestore.Tables["EmpleadoActivo"] as DataSetcubestore.EmpleadoActivoDataTable);
			}
			catch (Exception ex)
			{
				Methods.GenerateLogsErrors(DateTime.Now, ex.Message);
			}
			return dataSetcubestore;
		}
	}
}
