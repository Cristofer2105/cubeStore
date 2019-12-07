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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Common;

namespace cubeStore
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();						
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			AcercaDe acerc = new AcercaDe();
			acerc.ShowDialog();
		}

		private void BtnSalir_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show("Esta Seguro de Salir?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				Login login = new Login();
				this.Close();
				login.Show();
			}
		}
		private void BtnProductos_Click(object sender, RoutedEventArgs e)
		{
			menuCRUDproductos menuPr = new menuCRUDproductos();
			this.Close();
			menuPr.Show();
		}

		private void BtnUsuarios_Click(object sender, RoutedEventArgs e)
		{
			Usuarios usuarios = new Usuarios();
			this.Close();
			usuarios.Show();
		}

		private void BtnPerfilAdministrador_Click(object sender, RoutedEventArgs e)
		{
			PerfilAdministrador perfilAdministrador = new PerfilAdministrador();
			this.Close();
			perfilAdministrador.Show();
		}

		private void BtnVentas_Click(object sender, RoutedEventArgs e)
		{
			MenuVentas menuVentas = new MenuVentas();
			menuVentas.ShowDialog();
		}
	}
}
