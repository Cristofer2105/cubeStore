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
	/// Interaction logic for Reportes.xaml
	/// </summary>
	public partial class Reportes : Window
	{
		/// <summary>
		/// 
		/// </summary>
		public Reportes()
		{
			InitializeComponent();
		}

		private void BtnReporte3_Click(object sender, RoutedEventArgs e)
		{
			EmpleaosActivos empleaosActivos = new EmpleaosActivos();
			empleaosActivos.Show();
		}

		private void BtnReporteDos_Click(object sender, RoutedEventArgs e)
		{
			VerReporteVentas verReporte = new VerReporteVentas();
			verReporte.Show();
		}

		private void BtnReporteUno_Click(object sender, RoutedEventArgs e)
		{
			VerReporteEmpleados verReporte = new VerReporteEmpleados();
			verReporte.Show();
		}

		private void BtnPerfil_Click(object sender, RoutedEventArgs e)
		{
			PerfilAdministrador perfilAdministrador = new PerfilAdministrador();
			this.Close();
			perfilAdministrador.Show();
		}

		private void BtnSalirAplicacion_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show("Esta Seguro de Salir?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				Login login = new Login();
				this.Close();
				login.Show();
			}
		}

		private void BtnVolver_Click(object sender, RoutedEventArgs e)
		{
			MainWindow menu = new MainWindow();
			this.Close();
			menu.Show();
		}
	}
}
