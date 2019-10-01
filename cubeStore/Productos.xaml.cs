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
	/// Interaction logic for Productos.xaml
	/// </summary>
	public partial class Productos : Window
	{
		byte operacion = 0;
		CategoriaBRL brl;
		Categoria categoria;
		public Productos()
		{
			InitializeComponent();
		}
		private void LoadDataGrid()
		{
			try
			{
				brl = new CategoriaBRL();
				dgdDatos.ItemsSource = brl.Select().DefaultView;
				dgdDatos.Columns[0].Visibility=Visibility.Hidden;
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		
		}
		private void Habilitar( byte operacion)
		{
			btnGuardar.IsEnabled = true;
			btnCancelar.IsEnabled = true;
			txtnombreCategoria.IsEnabled = true;

			btnInsertar.IsEnabled = false;
			btnModificar.IsEnabled = false;
			btnEliminar.IsEnabled = false;
			this.operacion = operacion;
		}

		private void DesHabilitar()
		{
			btnGuardar.IsEnabled = false;
			btnCancelar.IsEnabled = false;
			txtnombreCategoria.Text = string.Empty;
			txtnombreCategoria.IsEnabled = false;

			btnInsertar.IsEnabled = true;
			btnModificar.IsEnabled = true;
			btnEliminar.IsEnabled = true;
		}
		private void BtnSalir_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
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

		private void BtnGuardar_Click(object sender, RoutedEventArgs e)
		{
			switch (operacion)
			{
				case 1:
					//Insertar
					txtnombreCategoria.Text = txtnombreCategoria.Text.Trim();
					if (Validate.OnlyLettersAndSpaces(txtnombreCategoria.Text))
					{
						try
						{
							//Insertar
							categoria = new Categoria(txtnombreCategoria.Text);
							brl = new CategoriaBRL(categoria);
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
					txtnombreCategoria.Text = txtnombreCategoria.Text.Trim();
					if (Validate.OnlyLettersAndSpaces(txtnombreCategoria.Text))
					{
						try
						{
							//Modificar
							//categoria = new Categoria(txtnombreCategoria.Text);
							categoria.NombreCategoria = txtnombreCategoria.Text;
							
							brl = new CategoriaBRL(categoria);
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

		private void DgdDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (dgdDatos.Items.Count>0 && dgdDatos.SelectedItem != null)
			{
				//Realizamos Get
				try
				{
					DataRowView dataRow=(DataRowView)dgdDatos.SelectedItem;
					byte id=byte.Parse(dataRow.Row.ItemArray[0].ToString());
					brl = new CategoriaBRL();
					categoria = brl.Get(id);

					//Cargar Datos
					txtnombreCategoria.Text = categoria.NombreCategoria;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void BtnEliminar_Click(object sender, RoutedEventArgs e)
		{
			if (categoria!=null)
			{
				if (MessageBox.Show("Esta Seguro de Eliminar el Registro?","Eliminar",MessageBoxButton.YesNo,MessageBoxImage.Question)==MessageBoxResult.Yes)
				{
					//Eliminacion Logica
					try
					{
						brl = new CategoriaBRL(categoria);
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

		private void BtnProducto_Click(object sender, RoutedEventArgs e)
		{
			AdminProductos adPr = new AdminProductos();
			Close();
			adPr.Show();
		}

		private void BtnVolver_Click(object sender, RoutedEventArgs e)
		{
			menuCRUDproductos men = new menuCRUDproductos();
			this.Close();
			men.Show();
		}
	}
}
