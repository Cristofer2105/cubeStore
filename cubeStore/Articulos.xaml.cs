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
		byte operacion = 0;
		ArticuloBRL brl;
		Articulo articulo;
		CategoriaBRL catBRL;
		ProvedorBRL provBRL;
		byte opcion=0;
		string pathImagen = string.Empty,pathFotoCarteroServer=string.Empty;
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
				dgdDatos.ItemsSource = brl.SelectBusquedaArticulos(txtBuscarArticulo.Text).DefaultView;
				dgdDatos.Columns[0].Visibility = Visibility.Hidden;
				dgdDatos.Columns[3].Visibility = Visibility.Hidden;

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

				MessageBox.Show("Ocurrio un error comuniquese con el administrador de sistemas");
			}

		}
		private void Habilitar(byte operacion)
		{
			btnGuardarAccion.IsEnabled = true;
			btnCancelar.IsEnabled = true;
			btnBuscarImagenArtivculo.IsEnabled = true;
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
			btnBuscarImagenArtivculo.IsEnabled = false;
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
					if (articulo!=null)
					{
						txtnombreArticulo.Text = articulo.NombreArticulo;
						cbxCategoria.SelectedValue = byte.Parse(articulo.IdCategoria.ToString());
						cbxProvedor.SelectedValue = int.Parse(articulo.IdProvedor.ToString());
						try
						{
							if ( int.Parse(dataRow.Row.ItemArray[3].ToString())== 1)
							{
								imgArticulo.Source = new BitmapImage(new Uri(Config.configpathImagenArticulo + id + ".jpg"));
								pathImagen = Config.configpathImagenArticulo + id + ".jpg";
								pathFotoCarteroServer = pathImagen;
							}
							else
							{
								imgArticulo.Source = new BitmapImage(new Uri(Config.configpathImagenArticulo + "0.jpg"));
								pathImagen = Config.configpathImagenArticulo + id + "0.jpg";
								pathFotoCarteroServer = pathImagen;

							}

						}
						catch (Exception)
						{
					
							pathImagen = string.Empty;
							MessageBox.Show("No se pudo cargar la imagen comuniquese con el administrador de sistemas");

						}
					}
					
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
			opcion = 1;
		}

		private void BtnAgregar_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Complete el formulario para agregar un nuevo articulo");
			dgdDatos.IsEnabled = false;
			Habilitar(1);
			LimpiarCampos();
			opcion = 0;
			txtBuscarArticulo.Text = "";
		}

		private void BtnEliminar_Click(object sender, RoutedEventArgs e)
		{
			brl = new ArticuloBRL();
			DataTable dt = brl.VerificarArticuloEliminar(articulo.IdArticulo);
			if (dt.Rows.Count == 0)
			{
				if (articulo != null && txtnombreArticulo.Text != "")
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

							MessageBox.Show("Ocurrio un error comuniquese con el administrador de sistemas");
						}
					}
				}
				else
				{
					MessageBox.Show("Debe seleccionar un registro de la lista");
				}
			}
			else
			{
				MessageBox.Show("No puede eliminar este Articulo");
			}
		}

		private void BtnGuardarAccion_Click(object sender, RoutedEventArgs e)
		{
			switch (operacion)
			{
				case 1:
					//Insertar
					
					if (txtnombreArticulo.Text == "" && txtnombreArticulo.Text.Length<3)
					{
						MessageBox.Show("Complete correctamente el formulario");
					}
					else
					{
						dgdDatos.IsEnabled = false;
						txtnombreArticulo.Text = txtnombreArticulo.Text.Trim();
						brl = new ArticuloBRL();
						DataTable dt = brl.VerificarArticulo(txtnombreArticulo.Text);
						if (dt.Rows.Count==0)
						{
							try
							{
								//Insertar
								//CAPTURAMOS EL NOMBRE DE LA IMAGEN A TRAVEZ DEL ID
								if (imgArticulo.Source != null)
								{
									DateTime fecha = DateTime.Now;
									articulo = new Articulo(txtnombreArticulo.Text, byte.Parse(cbxCategoria.SelectedValue.ToString()), int.Parse(cbxProvedor.SelectedValue.ToString()), fecha, 1);
									brl = new ArticuloBRL(articulo);
									brl.Insert();

									int id = MethodsBRL.GetMaxIDTable("idArticulo", "Articulo");

									File.Copy(pathImagen, Config.configpathImagenArticulo + id + ".jpg");


									MessageBox.Show("Registro Exitoso");
	
									LoadDataGrid();
									dgdDatos.IsEnabled = true;
									DesHabilitar();
								}
								else
								{
									MessageBox.Show("Elija una imagen por favor");
								}


							}
							catch (Exception ex)
							{

								MessageBox.Show("Error al agregar Articulo comuniquese con el administrador de sistemas ");
							}
						}
						else
						{
							MessageBox.Show("El Articulo ya existe");
						}	
						
						
					}
				break;
				case 2:
					//Modificar
					if (txtnombreArticulo.Text == ""&&imgArticulo.Source==null&&articulo==null)
					{
						MessageBox.Show("Seleccione un registro de la lista para modificarlo");
					}
					else
					{

						txtnombreArticulo.Text = txtnombreArticulo.Text.Trim();
						brl = new ArticuloBRL();
						DataTable dt = brl.VerificarArticulo(txtnombreArticulo.Text);
						if (dt.Rows.Count == 0)
						{
							try
							{
								//Modificar
								//categoria = new Categoria(txtnombreCategoria.Text);
								articulo.NombreArticulo = txtnombreArticulo.Text;
								dgdDatos.IsEnabled = true;
								brl = new ArticuloBRL(articulo);

								//Cambiamos imagen
								if (pathImagen != pathFotoCarteroServer)
								{
									brl.Update();
									MessageBox.Show("Registro Modificado Exitosamente");
									LoadDataGrid();
									DesHabilitar();
									LimpiarCampos();
									System.GC.Collect();
									System.GC.WaitForPendingFinalizers();
									File.Delete(pathFotoCarteroServer);
									File.Copy(pathImagen, Config.configpathImagenArticulo + articulo.IdArticulo + ".jpg");
								}
								else
								{
									MessageBox.Show("Error al modificar");
								}

								

							}
							catch (Exception ex)
							{

								MessageBox.Show("Ocurrio un error comuniquese con el administrador de sistemas");
							}
						}
						else
						{
							MessageBox.Show("El Articulo ya existe");
						}

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

		private void TxtBuscarArticulo_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (txtBuscarArticulo.Text == "")
			{
				LoadDataGrid();
			}
			else
			{
				LoadDataGrid();
			}
		}

		private void BtnBuscarImagenArtivculo_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog opd = new OpenFileDialog();
			opd.Filter = "Archivos de Imagenes|*.jpg";
			
			if (opd.ShowDialog()==true)
			{
				imgArticulo.Source = new BitmapImage(new Uri(opd.FileName));
				pathImagen = opd.FileName;
			}
		}
	}
}
