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
	/// Interaction logic for VerReporteVentas.xaml
	/// </summary>
	public partial class VerReporteVentas : Window
	{
		/// <summary>
		/// 
		/// </summary>
		public VerReporteVentas()
		{
			InitializeComponent();
		}

		private void ViewerVerReportesVentas_Loaded(object sender, RoutedEventArgs e)
		{
			ReporteVentas reporte = new ReporteVentas();
			DataSetcubestore dataset = VentasListBRL.ObtenerListaVentasReporte();


			reporte.Load("../../ReporteVentas.rpt");
			reporte.SetDataSource(dataset);
			viewerVerReportesVentas.ViewerCore.ReportSource = reporte;
		}
	}
}
