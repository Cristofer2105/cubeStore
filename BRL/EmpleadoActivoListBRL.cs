using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL
{
	public class EmpleadoActivoListBRL
	{
		public static DataSetcubestore ObtenerListaEmpleadosActivosReporte()
		{
			
				DataSetcubestore dataSetcubestore = null;
				try
				{
				dataSetcubestore = EmpleadoActivosListDal.ObtenerListaEmpleadosActivosReporte();
				}
				catch (Exception)
				{

					throw;
				}


				return dataSetcubestore;
			
		}
	}
}
