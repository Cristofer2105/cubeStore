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
	/// Interaction logic for Clientes.xaml
	/// </summary>
	public partial class Clientes : Window
	{
		byte operacion = 0;
		ClienteBRL brl;
		Cliente cliente;
		public Clientes()
		{
			InitializeComponent();
		}
		private void LoadDataGrid()
		{
			try
			{
				brl = new ClienteBRL();
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
			txtnombre.IsEnabled = true;
			txtprimerapellido.IsEnabled = true;
			txtsegundoapellido.IsEnabled = true;

			btnGuardarAccion.IsEnabled = true;
			btnCancelar.IsEnabled = true;
			btnAgregar.IsEnabled = false;
			btnModificar.IsEnabled = false;
			btnEliminar.IsEnabled = false;
			this.operacion = operacion;
		}

		private void DesHabilitar()
		{
			txtnombre.IsEnabled = false;
			txtprimerapellido.IsEnabled = false;
			txtsegundoapellido.IsEnabled = false;
			btnGuardarAccion.IsEnabled = false;
			btnCancelar.IsEnabled = false;
			btnAgregar.IsEnabled = true;
			btnModificar.IsEnabled = true;
			btnEliminar.IsEnabled = true;
		}
		void LimpiarCampos()
		{
			txtnombre.Text = "";
			txtprimerapellido.Text = "";
			txtsegundoapellido.Text = "";
		}

		private void BtnCerrarClientes_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			LoadDataGrid();
		}

		private void BtnModificar_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Seleccione un registro de la lista para modificarlo");
			Habilitar(2);
		}

		private void BtnAgregar_Click(object sender, RoutedEventArgs e)
		{
			Habilitar(1);
			LimpiarCampos();
			dgdDatos.IsEnabled = false;
		}

		private void BtnEliminar_Click(object sender, RoutedEventArgs e)
		{
			if (cliente != null)
			{
				if (MessageBox.Show("Esta Seguro de Eliminar el Registro?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					//Eliminacion Logica
					try
					{
						brl = new ClienteBRL(cliente);
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
					if (txtnombre.Text == "")
					{
						MessageBox.Show("Debe Llenar el nombre");
					}
					else
					{
						txtnombre.Text = txtnombre.Text.Trim();
						txtprimerapellido.Text = txtprimerapellido.Text.Trim();
						txtsegundoapellido.Text = txtsegundoapellido.Text.Trim();
						if (Validate.OnlyLettersAndSpaces(txtnombre.Text)&& Validate.OnlyLettersAndSpaces(txtprimerapellido.Text) && Validate.OnlyLettersAndSpaces(txtsegundoapellido.Text))
						{
							try
							{
								//Insertar
								DateTime fechahora = DateTime.Now;
								cliente = new Cliente(txtnombre.Text,txtprimerapellido.Text,txtsegundoapellido.Text, fechahora);
								brl = new ClienteBRL(cliente);
								brl.Insert();
								MessageBox.Show("Registro Exitoso");
								LoadDataGrid();
								DesHabilitar();
								dgdDatos.IsEnabled = true;
								LimpiarCampos();
							}
							catch (Exception ex)
							{

								MessageBox.Show(ex.Message);
							}

						}
						else
						{
							MessageBox.Show("Ingrese Correctamente los datos");
							LimpiarCampos();
						}
					}
					break;
				case 2:
					//Modificar
					if (txtnombre.Text == "" && txtprimerapellido.Text == "" && txtsegundoapellido.Text == "")
					{
						MessageBox.Show("Tiene que seleccionar un registro de la lista para modificarlo");
					}
					else
					{
						txtnombre.Text = txtnombre.Text.Trim();
						txtprimerapellido.Text = txtprimerapellido.Text.Trim();
						txtsegundoapellido.Text = txtsegundoapellido.Text.Trim();
						if (Validate.OnlyLettersAndSpaces(txtnombre.Text) && Validate.OnlyLettersAndSpaces(txtprimerapellido.Text) && Validate.OnlyLettersAndSpaces(txtsegundoapellido.Text))
						{
							try
							{
								//Modificar
								cliente.Nombres = txtnombre.Text;
								cliente.PrimerApellido = txtprimerapellido.Text;
								cliente.SegundoApellido = txtsegundoapellido.Text;

								brl = new ClienteBRL(cliente);
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
							MessageBox.Show("Ingrese Correctamente los datos");
						}
					}
					break;
			}
		}

		private void BtnCancelar_Click(object sender, RoutedEventArgs e)
		{
			DesHabilitar();
			LimpiarCampos();
			dgdDatos.IsEnabled = true;
		}

		private void DgdDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (dgdDatos.Items.Count > 0 && dgdDatos.SelectedItem != null)
			{
				//Realizamos Get
				try
				{
					DataRowView dataRow = (DataRowView)dgdDatos.SelectedItem;
					int id = int.Parse(dataRow.Row.ItemArray[0].ToString());
					brl = new ClienteBRL();
					cliente = brl.Get(id);

					//Cargar Datos
					txtnombre.Text = cliente.Nombres;
					txtprimerapellido.Text = cliente.PrimerApellido;
					txtsegundoapellido.Text = cliente.SegundoApellido;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}
	}
}
