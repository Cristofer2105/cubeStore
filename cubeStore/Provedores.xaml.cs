using BRL;
using Common;
using Microsoft.Maps.MapControl.WPF;
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
	/// Interaction logic for Provedores.xaml
	/// </summary>
	public partial class Provedores : Window
	{
		byte operacion = 0;
		Provedor provedor;
		ProvedorBRL brl;
		Location pinUbicacion;
		public Provedores()
		{
			InitializeComponent();
		}
		private void Habilitar(byte operacion)
		{
			btnGuardar.IsEnabled = true;
			btncancelarAcion.IsEnabled = true;
			txtnombreprovedor.IsEnabled = true;
			dgdDatos.IsEnabled = true;

			btnAgregar.IsEnabled = false;
			btnModificar.IsEnabled = false;
			btnEliminar.IsEnabled = false;
			this.operacion = operacion;
		}

		private void DesHabilitar()
		{
			btnGuardar.IsEnabled = false;
			btncancelarAcion.IsEnabled = false;
			txtnombreprovedor.IsEnabled = false;
			btnAgregar.IsEnabled = true;
			btnModificar.IsEnabled = true;
			btnEliminar.IsEnabled = true;
			
		}
		private void LoadDataGrid()
		{
			try
			{
				brl = new ProvedorBRL();
				dgdDatos.ItemsSource = brl.Select().DefaultView;
				dgdDatos.Columns[0].Visibility = Visibility.Hidden;
				dgdDatos.Columns[3].Visibility = Visibility.Hidden;
				dgdDatos.Columns[4].Visibility = Visibility.Hidden;
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}

		}
		private void LimpiarCampos()
		{
			txtnombreprovedor.Text="";
		}
		private void BtnCerrarProvedores_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
		/// <summary>
		/// Evento Click para modificar un provedor
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnModificar_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Seleccione un registro de la lista para modificarlo");
			Habilitar(2);
		}		
		/// <summary>
		/// Evento click para eliminar un provedor
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnEliminar_Click(object sender, RoutedEventArgs e)
		{
			if (provedor != null && txtnombreprovedor.Text != "")
			{
				if (MessageBox.Show("Esta Seguro de Eliminar el Registro?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					//Eliminacion Logica
					try
					{
						brl = new ProvedorBRL(provedor);
						brl.Delete();
						MessageBox.Show("Eliminado Exitosamente");
						LoadDataGrid();
						LimpiarCampos();
						mapaProv.Children.Clear();
						

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
		/// <summary>
		/// Cancela cualquier accion Insertar Modificar Eliminar
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtncancelarAcion_Click(object sender, RoutedEventArgs e)
		{
			DesHabilitar();
			LimpiarCampos();
			mapaProv.Children.Clear();
		}
		/// <summary>
		/// Evento Click Acercar Mapa
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Btnacercar_Click(object sender, RoutedEventArgs e)
		{
			mapaProv.Focus();
			mapaProv.ZoomLevel++;
		}
		/// <summary>
		/// Evento Click Alejar Mapa
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Btnalejar_Click(object sender, RoutedEventArgs e)
		{
			mapaProv.Focus();
			mapaProv.ZoomLevel--;
		}
		/// <summary>
		/// Evento Click Vista de Calles
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Btnvistacalles_Click(object sender, RoutedEventArgs e)
		{
			mapaProv.Focus();
			mapaProv.Mode = new RoadMode();
		}
		/// <summary>
		///  Evento Click Vista de Satelite
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Btnvistasatelite_Click(object sender, RoutedEventArgs e)
		{
			mapaProv.Focus();
			mapaProv.Mode = new AerialMode(true);
		}
		/// <summary>
		/// Evento click para agregar un nuevo provedor
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnAgregar_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Complete el formulario para agregar un nuevo provedor");
			Habilitar(1);
			LimpiarCampos();
			mapaProv.Children.Clear();
			dgdDatos.IsEnabled = false;
		}

		private void BtnGuardar_Click(object sender, RoutedEventArgs e)
		{
			switch (operacion)
			{
				case 1:
					//Insertar
					if (txtnombreprovedor.Text == "")
					{
						MessageBox.Show("Debe Llenar los campos para poder agregar un registro");
					}
					else
					{					
						txtnombreprovedor.Text = txtnombreprovedor.Text.Trim();
						if (Validate.OnlyLettersAndSpaces(txtnombreprovedor.Text))
						{
							try
							{
								//Insertar
								DateTime fecha = DateTime.Now;
								provedor = new Provedor(txtnombreprovedor.Text.Trim(), (float)pinUbicacion.Latitude, (float)pinUbicacion.Longitude, fecha);
								brl = new ProvedorBRL(provedor);
								brl.Insert();
								MessageBox.Show("Registro Exitoso");
								dgdDatos.IsEnabled = true;
								mapaProv.Children.Clear();
								LoadDataGrid();
								LimpiarCampos();
								DesHabilitar();


							}
							catch (Exception ex)
							{

								MessageBox.Show("Debe Elegir Una Ubicacion");
							}
						}
						else
						{
							MessageBox.Show("Ingrese Correctamente los campos");
						}
					}
				break;
				case 2:
					//Modificar	
					if (txtnombreprovedor.Text == "")
					{
						MessageBox.Show("Tiene que seleccionar un registro de la lista para modificarlo");
					}
					else
					{
						txtnombreprovedor.Text = txtnombreprovedor.Text.Trim();
						try
						{
							//Modificar
							//categoria = new Categoria(txtnombreCategoria.Text);						
							provedor.RazonSocial = txtnombreprovedor.Text.Trim();
							provedor.Latitud = (float)pinUbicacion.Latitude;
							provedor.Longitud = (float)pinUbicacion.Longitude;

							brl = new ProvedorBRL(provedor);
							brl.Update();
							MessageBox.Show("Registro Modificado Exitosamente");
							mapaProv.Children.Clear();
							LoadDataGrid();
							LimpiarCampos();
							DesHabilitar();
						}
						catch (Exception ex)
						{
							MessageBox.Show("Debe Elegir Una Ubicacion");
						}
					}
					break;
			}
		}

		private void MapaProv_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			e.Handled = true;
			var mousePostion = e.GetPosition((UIElement)sender);

			pinUbicacion = mapaProv.ViewportPointToLocation(mousePostion);

			Pushpin marcador = new Pushpin();
			marcador.Location = pinUbicacion;

			mapaProv.Children.Clear();

			mapaProv.Children.Add(marcador);
		}
		/// <summary>
		/// Carga los datos de provedor al Datagrid al cargar la ventana
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			LoadDataGrid();
		}
		/// <summary>
		/// Permite seleccionar registros del DataGrid 
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
					double aux = double.Parse(dataRow.Row.ItemArray[3].ToString());
					double aux2 = double.Parse(dataRow.Row.ItemArray[4].ToString());
					brl = new ProvedorBRL();
					provedor = brl.Get(id);

					//Cargar Datos
					Location location = new Location();
					location.Latitude = aux;
					location.Longitude = aux2;
					Pushpin pushpin = new Pushpin();

					pushpin.Location = location;
					mapaProv.Children.Clear();
					mapaProv.Children.Add(pushpin);
					mapaProv.Center = location;				
					txtnombreprovedor.Text = provedor.RazonSocial;

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			
		}
	}
}
