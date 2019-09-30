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
	/// Interaction logic for AdminProductos.xaml
	/// </summary>
	public partial class AdminProductos : Window
	{
		byte operacion = 0;
		ArticuloBRL brl;
		Articulo articulo;
		public AdminProductos()
		{
			InitializeComponent();
		}
		private void LoadDataGrid()
		{
			try
			{
				brl = new ArticuloBRL();
				dgdDatos.ItemsSource = brl.Select().DefaultView;
				dgdDatos.Columns[0].Visibility = Visibility.Hidden;
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}

		}
		private void Habilitar(byte operacion)
		{
			btnGuardar.IsEnabled = true;
			btnCancelar.IsEnabled = true;
			txtnombreArticulo.IsEnabled = true;

			btnInsertar.IsEnabled = false;
			btnModificar.IsEnabled = false;
			btnEliminar.IsEnabled = false;
			this.operacion = operacion;
		}

		private void DesHabilitar()
		{
			btnGuardar.IsEnabled = false;
			btnCancelar.IsEnabled = false;
			txtnombreArticulo.Text = string.Empty;
			txtnombreArticulo.IsEnabled = false;

			btnInsertar.IsEnabled = true;
			btnModificar.IsEnabled = true;
			btnEliminar.IsEnabled = true;
		}
		private void BtnGuardar_Click(object sender, RoutedEventArgs e)
		{
			switch (operacion)
			{
				case 1:
					//Insertar
					txtnombreArticulo.Text = txtnombreArticulo.Text.Trim();
					if (Validate.OnlyLettersAndSpaces(txtnombreArticulo.Text))
					{
						try
						{
							//Insertar
							articulo = new Articulo(txtnombreArticulo.Text,1);
							brl = new ArticuloBRL(articulo);
							brl.Insert();
							MessageBox.Show("Registro Exitoso");
							LoadDataGrid();
							DesHabilitar();
						}
						catch (Exception ex)
						{

							MessageBox.Show(ex.Message);
						}

					}
					else
					{
						MessageBox.Show("Ingrese Correctamente el nombre");
					}
					break;
				case 2:
					//Modificar
					txtnombreArticulo.Text = txtnombreArticulo.Text.Trim();
					if (Validate.OnlyLettersAndSpaces(txtnombreArticulo.Text))
					{
						try
						{
							//Modificar
							//categoria = new Categoria(txtnombreCategoria.Text);
							articulo.NombreArticulo = txtnombreArticulo.Text;

							brl = new ArticuloBRL(articulo);
							brl.Update();
							MessageBox.Show("Registro Modificado Exitosamente");
							LoadDataGrid();
							DesHabilitar();
						}
						catch (Exception ex)
						{

							MessageBox.Show(ex.Message);
						}

					}
					else
					{
						MessageBox.Show("Ingrese Correctamente el nombre");
					}
					break;
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			LoadDataGrid();
		}

		private void BtnCancelar_Click(object sender, RoutedEventArgs e)
		{
			DesHabilitar();
		}

		private void BtnInsertar_Click(object sender, RoutedEventArgs e)
		{
			Habilitar(1);
		}

		private void BtnModificar_Click(object sender, RoutedEventArgs e)
		{
			Habilitar(2);
		}

		private void DgdDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (dgdDatos.Items.Count > 0 && dgdDatos.SelectedItem != null)
			{
				//Realizamos Get
				try
				{
					DataRowView dataRow = (DataRowView)dgdDatos.SelectedItem;
					byte id = byte.Parse(dataRow.Row.ItemArray[0].ToString());
					brl = new ArticuloBRL();
					articulo = brl.Get(id);

					//Cargar Datos
					txtnombreArticulo.Text = articulo.NombreArticulo;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void BtnEliminar_Click(object sender, RoutedEventArgs e)
		{
			if (articulo != null)
			{
				if (MessageBox.Show("Esta Seguro de Eliminar el Registro?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					//Eliminacion Logica
					try
					{
						brl = new ArticuloBRL(articulo);
						brl.Delete();
						MessageBox.Show("Eliminado Exitosamente");
						LoadDataGrid();
					}
					catch (Exception ex)
					{

						MessageBox.Show(ex.Message);
					}
				}
			}
		}

		private void BtnSalir_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void BtnVolver_Click(object sender, RoutedEventArgs e)
		{
			menuCRUDproductos men = new menuCRUDproductos();
			this.Close();
			men.Show();
		}
	}
}
