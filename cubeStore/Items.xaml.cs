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
using System.Data;
using System.Timers;

namespace cubeStore
{
	/// <summary>
	/// Interaction logic for Items.xaml
	/// </summary>
	public partial class Items : Window
	{
		ItemBRL brl;
		ArticuloBRL brlart;
		Articulo articulo;
		Item item;
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
				dgdDatos.Columns[0].Visibility = Visibility.Hidden;
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}
		public void LoadDataGridItems()
		{
			try
			{
				brl = new ItemBRL();
				dgdDatos.ItemsSource = brl.Select().DefaultView;
				dgdDatos.Columns[0].Visibility = Visibility.Hidden;
				dgdDatos.Columns[4].Visibility = Visibility.Hidden;
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
			if (txtnombreproductobuscado.Text==""&& txtidProductoBuscado.Text=="")
			{
				MessageBox.Show("Busque un producto para agregar item");
			}
			else
			{
				agregarItem.txtnombreproductoinsert.Text = txtnombreproductobuscado.Text;
				agregarItem.txtIdProductoInsertar.Text = txtidProductoBuscado.Text;
				agregarItem.Show();
				txtnombreproductobuscado.Text = "";
				this.Close();
			}
		}
		/// <summary>
		/// Evento selection changed para busqueda de articulos
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Dgdbusqueda_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (dgdbusqueda.Items.Count > 0 && dgdbusqueda.SelectedItem != null)
			{
				//Realizamos Get
				try
				{
					DataRowView dataRow = (DataRowView)dgdbusqueda.SelectedItem;
					int id = int.Parse(dataRow.Row.ItemArray[0].ToString());
					brlart = new ArticuloBRL();
					articulo = brlart.Get(id);

					//Cargar Datos

					txtidProductoBuscado.Text = Convert.ToInt32(id).ToString();
					txtnombreproductobuscado.Text = articulo.NombreArticulo;
					AgregarItem agregarItem = new AgregarItem();
					if (txtnombreproductobuscado.Text == "" && txtidProductoBuscado.Text == "")
					{
						MessageBox.Show("Busque un producto para agregar item");
					}
					else
					{
						agregarItem.txtnombreproductoinsert.Text = txtnombreproductobuscado.Text;
						agregarItem.txtIdProductoInsertar.Text = txtidProductoBuscado.Text;
						agregarItem.ShowDialog();
						txtnombreproductobuscado.Text = "";
						this.Close();
					}

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
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

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			LoadDataGridItems();
		}
		/// <summary>
		/// Evento selection changed para administrar items del datagrid
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DgdDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (dgdDatos.Items.Count > 0 && dgdDatos.SelectedItem != null)
			{
				//Realizamos Get
				try
				{
					DataRowView dataRow = (DataRowView)dgdDatos.SelectedItem;
					int id = int.Parse(dataRow.Row.ItemArray[0].ToString());
					brl = new ItemBRL();
					item = brl.Get(id);

					//Cargar Datos
					if (MessageBox.Show("Desea administrar este item?", "Administrar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
					{
						AdministrarItem administrarItem = new AdministrarItem();
						administrarItem.txtcodigo.Text = item.CodigoItem;
						administrarItem.txtidItem.Text = Convert.ToInt32(id).ToString(); ;
						administrarItem.txtpreciobase.Text = Convert.ToDouble(item.PrecioBaseItem).ToString();
						administrarItem.Show();
						this.Close();
					}
					
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}
	}
}
