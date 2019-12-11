using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL
{
	public class VentasListBRL
	{
		public static DataSetcubestore ObtenerListaVentasReporte()
		{
			DataSetcubestore dataSetcubestore = null;
			try
			{
				dataSetcubestore = VentasListDAL.ObtenerListaVentasReporte();
			}
			catch (Exception)
			{

				throw;
			}


			return dataSetcubestore;
		}
	}
}
