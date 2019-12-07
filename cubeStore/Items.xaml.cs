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
using Common;
using BRL;

namespace cubeStore
{
	/// <summary>
	/// Interaction logic for Items.xaml
	/// </summary>
	public partial class Items : Window
	{
		ItemBRL brl;
		public Items()
		{
			InitializeComponent();
		}
		private void LoadDataGrid()
		{
			try
			{
				brl = new ItemBRL();
				dgdbusqueda.ItemsSource = brl.SelectArticulos(txtnombreproductobuscado.Text).DefaultView;
				dgdbusqueda.Columns[0].Visibility = Visibility.Hidden;
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}
		private void BtnCerrar_Click(object sender, RoutedEventArgs e)
		{
			this.Close();	
		}

		private void BtnAgregarItem_Click(object sender, RoutedEventArgs e)
		{
			AgregarItem agregarItem = new AgregarItem();
			agregarItem.txtnombreproductoinsert.Text = txtnombreproductobuscado.Text;
			agregarItem.txtIdProductoInsertar.Text = txtidProductoBuscado.Text;
			agregarItem.ShowDialog();
		}

		private void Dgdbusqueda_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void Txtnombreproductobuscado_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (txtnombreproductobuscado.Text=="")
			{
				dgdbusqueda.ItemsSource = null;
				dgdbusqueda.Visibility = Visibility.Hidden;

			}
			else
			{
				dgdbusqueda.Visibility = Visibility.Visible;
				LoadDataGrid();
			}
			
		}
	}
}
