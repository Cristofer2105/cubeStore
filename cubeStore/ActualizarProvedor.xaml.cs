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
    /// Interaction logic for ActualizarProvedor.xaml
    /// </summary>
    public partial class ActualizarProvedor : Window
    {
		Location pinUbicacion;
		Provedor provedor;
		ProvedorBRL brl;
		public ActualizarProvedor()
        {
            InitializeComponent();
        }
		private void LoadDataGrid()
		{
			try
			{
				brl = new ProvedorBRL();
				dgdDatos.ItemsSource = brl.Select().DefaultView;
				dgdDatos.Columns[0].Visibility = Visibility.Hidden;
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}

		}
		private void LimpiarCampos()
		{
			txtNit.Clear();
			txtRazonSocial.Clear();
		}
		private void BtnVolverM_Click(object sender, RoutedEventArgs e)
		{
			menuCRUDproductos men = new menuCRUDproductos();
			this.Close();
			men.Show();
		}

		private void BtnActualizar_Click(object sender, RoutedEventArgs e)
		{
			txtNit.Text = txtNit.Text.Trim();
			txtRazonSocial.Text = txtRazonSocial.Text.Trim();
			
				try
				{
					//Modificar
					//categoria = new Categoria(txtnombreCategoria.Text);
					provedor.Nit = txtNit.Text.Trim();
					provedor.RazonSocial = txtRazonSocial.Text.Trim();
					provedor.Latitud = (float)pinUbicacion.Latitude;
					provedor.Longitud = (float)pinUbicacion.Longitude;

					brl = new ProvedorBRL(provedor);
					brl.Update();
					MessageBox.Show("Registro Modificado Exitosamente");
					mapaProv.Children.Clear();
					LoadDataGrid();
					LimpiarCampos();
				}
				catch (Exception ex)
				{

					MessageBox.Show(ex.Message);
				}
									
		}

		

		private void DgdDatos_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
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
					txtNit.Text = provedor.Nit;
					txtRazonSocial.Text = provedor.RazonSocial;



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

		private void MapaProv_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			e.Handled = true;
			var mousePostion = e.GetPosition((UIElement)sender);

			pinUbicacion = mapaProv.ViewportPointToLocation(mousePostion);

			Pushpin marcador = new Pushpin();
			marcador.Location = pinUbicacion;

			mapaProv.Children.Clear();

			mapaProv.Children.Add(marcador);

			MessageBox.Show("Ubicacion Capturada");
		}
		private void BtmAcercar_Click(object sender, RoutedEventArgs e)
		{
			mapaProv.Focus();
			mapaProv.ZoomLevel++;
		}

		private void BtnAlejar_Click(object sender, RoutedEventArgs e)
		{
			mapaProv.Focus();
			mapaProv.ZoomLevel--;
		}

		private void BtnCalles_Click(object sender, RoutedEventArgs e)
		{
			mapaProv.Focus();
			mapaProv.Mode = new RoadMode();
		}

		private void BtnSatelite_Click(object sender, RoutedEventArgs e)
		{
			mapaProv.Focus();
			mapaProv.Mode = new AerialMode(true);
		}

		private void BtnSalir_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
