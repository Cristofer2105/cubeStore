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
using BRL;
using DAL;

namespace cubeStore
{
	/// <summary>
	/// Interaction logic for VerReporteEmpleados.xaml
	/// </summary>
	public partial class VerReporteEmpleados : Window
	{
		public VerReporteEmpleados()
		{
			InitializeComponent();
		}

		private void CrystalViewerEmpleados_Loaded(object sender, RoutedEventArgs e)
		{
			ReporteVentasEmpleados reporte = new ReporteVentasEmpleados();
			DataSetcubestore dataset = EmpleadoListBRL.ObtenerListaEmpleadosReporte();


			reporte.Load("../../ReporteVentasEmpleados.rpt");
			reporte.SetDataSource(dataset);
			crystalViewerEmpleados.ViewerCore.ReportSource = reporte;
		}
	}
}
