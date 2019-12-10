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

namespace cubeStore
{
	/// <summary>
	/// Interaction logic for AdministrarVentas.xaml
	/// </summary>
	public partial class AdministrarVentas : Window
	{
		VentaBRL brl;
		Venta venta;
		Item item;
		Item brlit;
		int idVen;
		public AdministrarVentas()
		{
			InitializeComponent();
		}
		private void LoadDataGrid()
		{
			try
			{
				brl = new VentaBRL();
				dgdListaVentas.ItemsSource = brl.Select().DefaultView;
				dgdListaVentas.ItemsSource = brl.SelectBusquedaVenta(txtventabuscar.Text).DefaultView; 
				dgdListaVentas.Columns[2].Visibility = Visibility.Hidden;
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}
		private void LoadDataGridIdItems()
		{
			try
			{
				brl = new VentaBRL();
				dgdIdItems.ItemsSource = brl.SelectIdItemsAnular(idVen).DefaultView;
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			LoadDataGrid();
		}

		private void Btnsalir_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void Txtventabuscar_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (txtventabuscar.Text == "")
			{
				LoadDataGrid();
			}
			else
			{
				LoadDataGrid();
			}
		}

		private void BtnVerDetalleVenta_Click(object sender, RoutedEventArgs e)
		{
			if (dgdListaVentas.Items.Count > 0 && dgdListaVentas.SelectedItem != null)
			{
				//Realizamos Get
				try
				{
					DataRowView dataRow = (DataRowView)dgdListaVentas.SelectedItem;
					int idVen = int.Parse(dataRow.Row.ItemArray[0].ToString());
					brl = new VentaBRL();
					venta = brl.Get(idVen);

					//Cargar Datos
					MessageBox.Show("Ver mas Detalles" + idVen + " " + venta.Total);

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void BtnAnularVenta_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show("Esta Seguro de Anular esta venta?", "Anular Venta", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				if (dgdListaVentas.Items.Count > 0 && dgdListaVentas.SelectedItem != null)
				{
					//Realizamos Get
					try
					{
						DataRowView dataRow = (DataRowView)dgdListaVentas.SelectedItem;
						idVen = int.Parse(dataRow.Row.ItemArray[0].ToString());
						brl = new VentaBRL();
						venta = brl.Get(idVen);
						LoadDataGridIdItems();
						MotivoAnulacionVenta motivoAnulacionVenta = new MotivoAnulacionVenta();
						motivoAnulacionVenta.ShowDialog();
						txtmotivodeAnulacion.Text=motivoAnulacionVenta.txtmotivoAnulacion.Text;
						//Anular Venta
						DateTime fecha = DateTime.Now;
						brl = new VentaBRL();
						DataTable dt = brl.SelectIdItemsAnular(idVen);
						List<Item> items = new List<Item>();
						for (int i = 0; i < dt.Rows.Count; i++)
						{
							items.Add(new Item() { IdItem = int.Parse(dt.Rows[i][0].ToString()) });
						}
						Venta ventaa = new Venta() { IdVenta = idVen };
						Garantia garantia = new Garantia() { IdGarantia = idVen };
						VentaAnulada ventaNull = new VentaAnulada() { IdVentaAnulada = idVen, IdEmpleado = Sesion.idSesion, FechaRegistro = fecha, Motivo = txtmotivodeAnulacion.Text };
						brl.AnularVentas(ventaa, garantia, items, ventaNull);
						LoadDataGrid();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
			}
		}
	}
}
