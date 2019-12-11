using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL
{
	/// <summary>
	/// Clase EmpleadoListBRL
	/// </summary>
	public class EmpleadoListBRL
	{
		public static DataSetcubestore ObtenerListaEmpleadosReporte()
		{
			DataSetcubestore dataSetcubestore = null;
			try
			{
				dataSetcubestore=EmpleadoListDal.ObtenerListaEmpleadosReporte();
			}
			catch (Exception)
			{

				throw;
			}
			
			
			return dataSetcubestore;
		}
	}
}
