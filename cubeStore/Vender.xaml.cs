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
		Venta venta;
		VentaItem ventaitem;
		Garantia garantia;
		DataTable dtItemsComprar;
		public Vender()
		{
			InitializeComponent();
		}
		private void LoadTotalVenta()
		{
			try
			{
				brl = new ItemBRL();
				DataTable dt = brl.TotalVenta();
				txttotalVenta.Text = dt.Rows[0][0].ToString();			
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}
		private void LoadCantidadVenta()
		{
			try
			{
				brl = new ItemBRL();
				DataTable dt = brl.CantidadVenta();
				txtCantidadArticulos.Text = dt.Rows[0][0].ToString();
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
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
		private void LoadDataGridItemsComprar()
		{
			try
			{
				brl = new ItemBRL();
				dgdItemsComprar.ItemsSource = brl.SelectItemsComprar().DefaultView;
				//dgdItemsComprar.Columns[1].Visibility = Visibility.Hidden;
				dtItemsComprar = brl.SelectItemsComprar();
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}
		private void BtnSalirVender_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
			item = new Item();
			brl = new ItemBRL(item);
			brl.UpdateEstadoNormalItem();
			LoadDataGridItemsComprar();
			txtnombre.Text = "";
			txtCantidadArticulos.Text = "";
			txttotalVenta.Text = "";
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

		private void DgdbusquedaProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (dgdbusquedaProducto.Items.Count > 0 && dgdbusquedaProducto.SelectedItem != null)
			{
				//Realizamos Get
				try
				{
					DataRowView dataRow = (DataRowView)dgdbusquedaProducto.SelectedItem;
					int id = int.Parse(dataRow.Row.ItemArray[2].ToString());
					int idpro = int.Parse(dataRow.Row.ItemArray[0].ToString());
					brlart = new ArticuloBRL();
					brl = new ItemBRL();
					item = brl.Get(id);
					articulo = brlart.Get(idpro);

					//Cargar Datos

					txtidItem.Text = Convert.ToInt32(id).ToString();
					txtnombreitemBuscado.Text = articulo.NombreArticulo;
					item = new Item();					
					item.IdItem = int.Parse(txtidItem.Text.ToString());
					brl = new ItemBRL(item);
					brl.UpdateEstadoParaComprar();
					LoadDataGridItemsComprar();
					txtnombreitemBuscado.Text = "";
					LoadCantidadVenta();
					LoadTotalVenta();

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void DgdBusquedaCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (dgdBusquedaCliente.Items.Count > 0 && dgdBusquedaCliente.SelectedItem != null)
			{
				//Realizamos Get
				try
				{
					DataRowView dataRow = (DataRowView)dgdBusquedaCliente.SelectedItem;
					int idper = int.Parse(dataRow.Row.ItemArray[0].ToString());
					brlcli = new ClienteBRL();
					cliente = brlcli.Get(idper);

					//Cargar Datos
					txtbuscarcliente.Text = cliente.Nombres + " " + cliente.PrimerApellido + " " + cliente.SegundoApellido;
					txtidCliente.Text = Convert.ToInt32(idper).ToString();
					txtnombre.Text = cliente.Nombres + " " + cliente.PrimerApellido + " " + cliente.SegundoApellido;
					txtbuscarcliente.Text = "";

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			LoadDataGridItemsComprar();
			LoadCantidadVenta();
			LoadTotalVenta();
		}

		private void BtnCambiarEstadoItemsComprar_Click(object sender, RoutedEventArgs e)
		{
			if (dgdItemsComprar.Items.Count > 0 && dgdItemsComprar.SelectedItem != null)
			{
				try
				{
					DataRowView dataRow = (DataRowView)dgdItemsComprar.SelectedItem;
					int id = int.Parse(dataRow.Row.ItemArray[0].ToString());
					brl = new ItemBRL();
					item = brl.Get(id);
					item = new Item();
					item.IdItem = int.Parse(id.ToString());
					brl = new ItemBRL(item);
					brl.UpdateEstadoQuitarCompra();
					LoadDataGridItemsComprar();
					LoadCantidadVenta();
					LoadTotalVenta();
				}
				catch (Exception)
				{

					MessageBox.Show("No se pudo cambiar estado comuniquese con el administrador de sistemas");
				}
					
				
				
			}
		}

		private void BtnRealizarVenta_Click(object sender, RoutedEventArgs e)
		{
			if (txtnombre.Text!=" " &&txttotalVenta.Text!=" "&&txtCantidadArticulos.Text!="")
				{
					try
					{

						DateTime fecha = DateTime.Now;
						brl = new ItemBRL();
						DataTable dt = brl.SelectItemsComprar();
						int cont = int.Parse(txtCantidadArticulos.Text.ToString());
						List<VentaItem> productos = new List<VentaItem>();

						for (int i = 0; i < int.Parse(txtCantidadArticulos.Text.ToString()); i++)
						{
							productos.Add(new VentaItem(int.Parse(dt.Rows[i][0].ToString()), double.Parse(dt.Rows[i][3].ToString())));
							cont--;
						}

						this.venta = new Venta(int.Parse(txtidCliente.Text.ToString()), double.Parse(txttotalVenta.Text.ToString()), Sesion.idSesion, fecha);

						this.garantia = new Garantia(fecha, fecha.AddMonths(3), fecha);
						VentaBRL brlventa = new VentaBRL(venta, productos, garantia);
						if (MessageBox.Show("Esta Seguro de realizar la venta?", "Vender", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
						{
							brlventa.InsertVentas();
							LoadDataGridItemsComprar();
							MessageBox.Show("Venta realizada con exito");
							txttotalVenta.Text = "";
							txtCantidadArticulos.Text = "";
							txtnombre.Text = "";
						}

					}
					catch (Exception ex)
					{
						MessageBox.Show("Complete el formulario");
						LoadDataGridItemsComprar();
					}

			}
			else
			{
				MessageBox.Show("Debe Completar el formulario por favor");					
			}		
		}
	}
}
