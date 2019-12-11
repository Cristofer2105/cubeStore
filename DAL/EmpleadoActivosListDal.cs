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
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: ObtenerListaEmpleadosReporte", DateTime.Now));

				empleadoActivoTableAdapter.Fill(dataSetcubestore.Tables["EmpleadoActivo"] as DataSetcubestore.EmpleadoActivoDataTable);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, ex.Message));
			}
			return dataSetcubestore;
		}
	}
}
