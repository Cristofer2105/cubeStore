using BRL;
using Common;
using System;
using System.Collections.Generic;
using System.Data;
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
	/// Interaction logic for Vender.xaml
	/// </summary>
	public partial class Vender : Window
	{
		ItemBRL brl;
		ArticuloBRL brlart;
		Articulo articulo;
		Item item;
		ClienteBRL brlcli;
		Cliente cliente;
		public Vender()
		{
			InitializeComponent();
		}
		private void LoadDataGrid()
		{
			try
			{
				brl = new ItemBRL();
				dgdbusquedaProducto.ItemsSource = brl.SelectItems(txtnombreitemBuscado.Text).DefaultView;
				dgdbusquedaProducto.Columns[0].Visibility = Visibility.Hidden;
				dgdbusquedaProducto.Columns[2].Visibility = Visibility.Hidden;
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}
		private void LoadDataGridClientes()
		{
			try
			{
				brlcli = new ClienteBRL();
				dgdBusquedaCliente.ItemsSource = brlcli.SelectClientesBusqueda(txtbuscarcliente.Text).DefaultView;
				dgdBusquedaCliente.Columns[0].Visibility = Visibility.Hidden;
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}
		private void BtnSalirVender_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void BtnAgregarCliente_Click(object sender, RoutedEventArgs e)
		{
			Clientes clientes = new Clientes();
			clientes.ShowDialog();
		}

		private void TxtnombreitemBuscado_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (txtnombreitemBuscado.Text == "")
			{
				dgdbusquedaProducto.ItemsSource = null;
				dgdbusquedaProducto.Visibility = Visibility.Hidden;

			}
			else
			{
				dgdbusquedaProducto.Visibility = Visibility.Visible;
				LoadDataGrid();
			}
		}

		private void Txtbuscarcliente_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (txtbuscarcliente.Text == "")
			{
				dgdBusquedaCliente.ItemsSource = null;
				dgdBusquedaCliente.Visibility = Visibility.Hidden;

			}
			else
			{
				dgdBusquedaCliente.Visibility = Visibility.Visible;
				LoadDataGridClientes();
			}
		}
	}
}
