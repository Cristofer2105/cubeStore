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
	/// Interaction logic for Categorias.xaml
	/// </summary>
	public partial class Categorias : Window
	{
		byte operacion = 0;
		CategoriaBRL brl;
		Categoria categoria;
		public Categorias()
		{
			InitializeComponent();
		}
		private void LoadDataGrid()
		{
			try
			{
				brl = new CategoriaBRL();
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
			txtnombreCategoria.IsEnabled = true;

			btnGuardarAccion.IsEnabled = true;
			btnCancelar.IsEnabled = true;							
			btnAgregarUsuario.IsEnabled = false;
			btnModificar.IsEnabled = false;
			btnEliminar.IsEnabled = false;
			this.operacion = operacion;
		}

		private void DesHabilitar()
		{
			txtnombreCategoria.IsEnabled = false;
			btnGuardarAccion.IsEnabled = false;
			btnCancelar.IsEnabled = false;				
			btnAgregarUsuario.IsEnabled = true;
			btnModificar.IsEnabled = true;
			btnEliminar.IsEnabled = true;
		}
		void LimpiarCampos()
		{
			txtnombreCategoria.Text = "";			
		}

		private void BtnCerrarArticulos_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void BtnModificar_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Seleccione un registro de la lista para modificarlo");
			Habilitar(2);
		}

		private void BtnAgregarUsuario_Click(object sender, RoutedEventArgs e)
		{			
			Habilitar(1);
			LimpiarCampos();
		}

		private void BtnEliminar_Click(object sender, RoutedEventArgs e)
		{
			if (categoria != null&&txtnombreCategoria.Text!="")
			{
				if (MessageBox.Show("Esta Seguro de Eliminar el Registro?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					//Eliminacion Logica
					try
					{
						brl = new CategoriaBRL(categoria);
						brl.Delete();
						MessageBox.Show("Eliminado Exitosamente");
						LoadDataGrid();
						LimpiarCampos();
					}
					catch (Exception ex)
					{

						MessageBox.Show(ex.Message);
					}
				}
			}
			else
			{
				MessageBox.Show("Tiene que seleccionar un registro de la lista para eliminarlo");
			}
		}

		private void BtnGuardarAccion_Click(object sender, RoutedEventArgs e)
		{
			switch (operacion)
			{
				case 1:
					//Insertar
					if (txtnombreCategoria.Text == "")
					{
						MessageBox.Show("Debe Llenar los campos para poder agregar un registro");
					}
					else
					{
						txtnombreCategoria.Text = txtnombreCategoria.Text.Trim();
						if (Validate.OnlyLettersAndSpaces(txtnombreCategoria.Text))
						{
							try
							{
								//Insertar
								DateTime fechahora = DateTime.Now;
								categoria = new Categoria(txtnombreCategoria.Text, fechahora);
								brl = new CategoriaBRL(categoria);
								brl.Insert();
								MessageBox.Show("Registro Exitoso");
								LoadDataGrid();
								DesHabilitar();
								LimpiarCampos();
							}
							catch (Exception ex)
							{

								MessageBox.Show(ex.Message);
							}

						}
						else
						{
							MessageBox.Show("Ingrese Correctamente el nombre");
							LimpiarCampos();
						}
					}
					break;
				case 2:
					//Modificar
					if (txtnombreCategoria.Text=="")
					{
						MessageBox.Show("Tiene que seleccionar un registro de la lista para modificarlo");
					}
					else
					{				
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
								LimpiarCampos();
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
					}
					break;
			}
		}

		private void BtnCancelar_Click(object sender, RoutedEventArgs e)
		{
			DesHabilitar();
			LimpiarCampos();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			LoadDataGrid();
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
	}
}
