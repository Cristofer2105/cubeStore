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
	/// Interaction logic for MenuVentasVendedor.xaml
	/// </summary>
	public partial class MenuVentasVendedor : Window
	{
		public MenuVentasVendedor()
		{
			InitializeComponent();
		}

		private void BtnSalir_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void BtnClientes_Click(object sender, RoutedEventArgs e)
		{
			Clientes clientes = new Clientes();
			clientes.ShowDialog();
		}

		private void BtnSalirVentas_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void BtnVender_Click(object sender, RoutedEventArgs e)
		{
			Vender vender = new Vender();
			this.Close();
			vender.ShowDialog();
			
		}
	}
}
