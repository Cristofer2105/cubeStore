using BRL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace cubeStore
{
	/// <summary>
	/// Interaction logic for EmpleaosActivos.xaml
	/// </summary>
	public partial class EmpleaosActivos : Window
	{
		/// <summary>
		/// 
		/// </summary>
		public EmpleaosActivos()
		{
			InitializeComponent();
		}

		private void ViewerActivos_Loaded(object sender, RoutedEventArgs e)
		{
			VerReporteEmpleadosActivos reporte = new VerReporteEmpleadosActivos();
			DataSetcubestore dataset = EmpleadoActivoListBRL.ObtenerListaEmpleadosActivosReporte();


			reporte.Load("../../VerReporteEmpleadosActivos.rpt");
			reporte.SetDataSource(dataset);
			viewerActivos.ViewerCore.ReportSource = reporte;
		}
	}
}
