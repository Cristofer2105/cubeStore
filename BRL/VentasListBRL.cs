﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL
{
	/// <summary>
	/// Clase VentasListBRL
	/// </summary>
	public class VentasListBRL
	{
		/// <summary>
		/// Metodo ObtenerListaVentasReporte VentasListBRL
		/// </summary>
		/// <returns>DataSetcubestore</returns>
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
