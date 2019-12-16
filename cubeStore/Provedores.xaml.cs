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
		/// <summary>
		/// Metodo que habilita controles para el usuario
		/// </summary>
		/// <param name="operacion"></param>
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
		/// <summary>
		/// Metodo que deshabilita controles para el usuario
		/// </summary>
		private void DesHabilitar()
		{
			btnGuardar.IsEnabled = false;
			btncancelarAcion.IsEnabled = false;
			txtnombreprovedor.IsEnabled = false;
			btnAgregar.IsEnabled = true;
			btnModificar.IsEnabled = true;
			btnEliminar.IsEnabled = true;
			
		}
		/// <summary>
		/// Metodo que carga el datagrid de provedores
		/// </summary>
		private void LoadDataGrid()
		{
			try
			{
				brl = new ProvedorBRL();
				dgdDatos.ItemsSource = brl.Select().DefaultView;
				dgdDatos.ItemsSource = brl.SelectBusquedaProvedores(txtbuscarProvedor.Text).DefaultView;
				dgdDatos.Columns[0].Visibility = Visibility.Hidden;
				dgdDatos.Columns[3].Visibility = Visibility.Hidden;
				dgdDatos.Columns[4].Visibility = Visibility.Hidden;
			}
			catch (Exception ex)
			{

				MessageBox.Show("Ocurrio un error al cargar los Provedores intente nuevamente si el error persiste comuniquese con el administrador de sistemas");
			}

		}
		/// <summary>
		/// Metodo para limpiar campos de texto
		/// </summary>
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
			Habilitar(2);
		}		
		/// <summary>
		/// Evento click para eliminar un provedor
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnEliminar_Click(object sender, RoutedEventArgs e)
		{
			brl = new ProvedorBRL();
			DataTable dt = brl.VerificarProvedorEliminar(provedor.IdProvedor);
			if (dt.Rows.Count == 0)
			{
				if (provedor != null && txtnombreprovedor.Text != "")
				{
					if (MessageBox.Show("Esta Seguro de Eliminar el Provedor?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
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
						catch (Exception)
						{

							MessageBox.Show("Ocurrio un error al eliminar el Provedor intente nuevamente si el error persiste comuniquese con el administrador de sistemas");
						}
					}
				}
				else
				{
					MessageBox.Show("Tiene que seleccionar un registro de la lista para eliminarlo");
				}
			}
			else
			{
				MessageBox.Show("No puedes Eliminar este Provedor por que existen articulos asociados al mismo");
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
			dgdDatos.IsEnabled = true;
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
			Habilitar(1);
			LimpiarCampos();
			mapaProv.Children.Clear();
			dgdDatos.IsEnabled = false;
		}
		/// <summary>
		/// Evento click que permite insertar o modificar un Provedor
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnGuardar_Click(object sender, RoutedEventArgs e)
		{
			switch (operacion)
			{
				case 1:
					//Insertar
					if (txtnombreprovedor.Text == "")
					{
						MessageBox.Show("Debe ingresar el nombre del Provedor");
					}
					else
					{					
						txtnombreprovedor.Text = txtnombreprovedor.Text.Trim();
						brl = new ProvedorBRL();
						DataTable dt = brl.VerificarProvedor(txtnombreprovedor.Text);
						if (dt.Rows.Count == 0)
						{
							if (Validate.OnlyLettersAndSpaces(txtnombreprovedor.Text))
							{
								try
								{
									//Insertar
									DateTime fecha = DateTime.Now;
									provedor = new Provedor(txtnombreprovedor.Text.Trim(), (float)pinUbicacion.Latitude, (float)pinUbicacion.Longitude, fecha);
									brl = new ProvedorBRL(provedor);
									brl.Insert();
									MessageBox.Show("Registro de Provedor exitoso");

									mapaProv.Children.Clear();
									LoadDataGrid();
									LimpiarCampos();
									DesHabilitar();
									dgdDatos.IsEnabled = true;

								}
								catch (Exception)
								{

									MessageBox.Show("Debe elegir la ubicacion del provedor en el mapa");
								}
							}
							else
							{
								MessageBox.Show("Solo se permiten letras para el nombre del Provedor");
							}
						}
						else
						{
							MessageBox.Show("El Provedor ya esta registrado");
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
						brl = new ProvedorBRL();
						DataTable dt = brl.VerificarProvedor(txtnombreprovedor.Text);
						if (dt.Rows.Count == 0)
						{
							try
							{
								//Modificar
								//categoria = new Categoria(txtnombreCategoria.Text);						
								provedor.RazonSocial = txtnombreprovedor.Text.Trim();
								provedor.Latitud = (float)pinUbicacion.Latitude;
								provedor.Longitud = (float)pinUbicacion.Longitude;								
								brl = new ProvedorBRL(provedor);
								brl.Update();
								MessageBox.Show("Provedor modificado exitosamente");
								mapaProv.Children.Clear();
								LoadDataGrid();
								LimpiarCampos();
								DesHabilitar();
								dgdDatos.IsEnabled = true;
							}

							catch (Exception)
							{
								MessageBox.Show("Por favor elija una nueva ubicacion para el Provedor");
							}
						}
						else
						{
							string prov=provedor.RazonSocial;
							var lat = provedor.Latitud;
							var lon = provedor.Longitud;
							provedor.RazonSocial = prov;
							provedor.Latitud = (float)pinUbicacion.Latitude;
							provedor.Longitud = (float)pinUbicacion.Longitude;
							brl = new ProvedorBRL(provedor);
							brl.Update();
							MessageBox.Show("El provedor ya esta registrado solo se modifico la ubicacion");
							mapaProv.Children.Clear();
							LoadDataGrid();
							LimpiarCampos();
							DesHabilitar();
							dgdDatos.IsEnabled = true;
						}
					}
					break;
			}
		}
		/// <summary>
		/// Evento MouseDoubleClick permite marcar una ubicacion en el mapa
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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
		/// Evento Loaded Carga los datos de provedor al Datagrid al cargar la ventana
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			LoadDataGrid();
		}
		/// <summary>
		/// Evento SelectionChanged Permite seleccionar registros del DataGrid 
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
					provedor.Latitud = aux;
					provedor.Longitud = aux2;

				}
				catch (Exception)
				{
					MessageBox.Show("Ocurrio un error al seleccionar el Provedor intente nuevamente si el error persiste comuniquese con el administrador de sistemas");
				}
			}
			
		}
		/// <summary>
		/// Evento TextChanged que permite buscar un Provedor en el datagrid
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TxtbuscarProvedor_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (txtbuscarProvedor.Text == "")
			{
				LoadDataGrid();
			}
			else
			{
				LoadDataGrid();
			}
		}
	}
}
