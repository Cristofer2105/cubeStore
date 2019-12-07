using BRL;
using Common;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
	/// Interaction logic for Articulos.xaml
	/// </summary>
	public partial class Articulos : Window
	{
		string pathImagen = string.Empty;
		byte operacion = 0;
		ArticuloBRL brl;
		Articulo articulo;
		CategoriaBRL catBRL;
		ProvedorBRL provBRL;
		public Articulos()
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

				catBRL = new CategoriaBRL();
				cbxCategoria.DisplayMemberPath = "nombreCategoria";
				cbxCategoria.SelectedValuePath = "idCategoria";
				cbxCategoria.ItemsSource = catBRL.SelectCategorias().DefaultView;
				cbxCategoria.SelectedIndex = 0;

				provBRL = new ProvedorBRL();
				cbxProvedor.DisplayMemberPath = "razonSocialProvedor";
				cbxProvedor.SelectedValuePath = "idProvedor";
				cbxProvedor.ItemsSource = provBRL.SelectProvedores().DefaultView;
				cbxProvedor.SelectedIndex = 0;
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}

		}
		private void Habilitar(byte operacion)
		{
			btnGuardarAccion.IsEnabled = true;
			btnCancelar.IsEnabled = true;
			txtnombreArticulo.IsEnabled = true;
			cbxCategoria.IsEnabled = true;
			cbxProvedor.IsEnabled = true;
			btnAgregar.IsEnabled = false;
			btnModificar.IsEnabled = false;
			btnEliminar.IsEnabled = false;
			this.operacion = operacion;
		}

		private void DesHabilitar()
		{
			btnGuardarAccion.IsEnabled = false;
			btnCancelar.IsEnabled = false;
			txtnombreArticulo.Text = string.Empty;
			txtnombreArticulo.IsEnabled = false;
			cbxCategoria.IsEnabled = false;
			cbxProvedor.IsEnabled = false;
			btnAgregar.IsEnabled = true;
			btnModificar.IsEnabled = true;
			btnEliminar.IsEnabled = true;
		}
		private void LimpiarCampos()
		{
			txtnombreArticulo.Text = "";
		}
		private void BtnCerrarArticulos_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
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
					cbxCategoria.SelectedValue = byte.Parse(articulo.IdCategoria.ToString());
					cbxProvedor.SelectedValue = int.Parse(articulo.IdProvedor.ToString());
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
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
			MessageBox.Show("Complete el formulario para agregar un nuevo articulo");
			dgdDatos.IsEnabled = false;
			Habilitar(1);
			LimpiarCampos();
		}

		private void BtnEliminar_Click(object sender, RoutedEventArgs e)
		{
			if (articulo != null&&txtnombreArticulo.Text!="")
			{
				if (MessageBox.Show("Esta Seguro de Eliminar el Registro?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					//Eliminacion Logica
					try
					{
						dgdDatos.IsEnabled = true;
						brl = new ArticuloBRL(articulo);
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
				MessageBox.Show("Debe seleccionar un registro de la lista");
			}
		}

		private void BtnGuardarAccion_Click(object sender, RoutedEventArgs e)
		{
			switch (operacion)
			{
				case 1:
					//Insertar
					if (txtnombreArticulo.Text == "")
					{
						MessageBox.Show("Debe completar todos los campos del formulario");
					}
					else
					{
						dgdDatos.IsEnabled = false;
						txtnombreArticulo.Text = txtnombreArticulo.Text.Trim();
						
							try
							{
								//Insertar
								DateTime fecha = DateTime.Now;
								articulo = new Articulo(txtnombreArticulo.Text, byte.Parse(cbxCategoria.SelectedValue.ToString()), int.Parse(cbxProvedor.SelectedValue.ToString()), fecha);
								brl = new ArticuloBRL(articulo);
								brl.Insert();

								

								MessageBox.Show("Registro Exitoso");
								LoadDataGrid();
								dgdDatos.IsEnabled = true;
								DesHabilitar();
							}
							catch (Exception ex)
							{

								MessageBox.Show(ex.Message);
							}

					
						
					}
				break;
				case 2:
					//Modificar
					if (txtnombreArticulo.Text == "")
					{
						MessageBox.Show("Seleccione un registro de la lista para modificarlo");
					}
					txtnombreArticulo.Text = txtnombreArticulo.Text.Trim();
				
						try
						{
							//Modificar
							//categoria = new Categoria(txtnombreCategoria.Text);
							articulo.NombreArticulo = txtnombreArticulo.Text;
							dgdDatos.IsEnabled = true;
							brl = new ArticuloBRL(articulo);
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
					break;
			}
		}
		private void BtnCancelar_Click(object sender, RoutedEventArgs e)
		{
			dgdDatos.IsEnabled = true;
			DesHabilitar();
			LimpiarCampos();
		}
	}
}
