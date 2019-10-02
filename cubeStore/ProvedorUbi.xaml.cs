using BRL;
using Common;
using Microsoft.Maps.MapControl.WPF;
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

namespace cubeStore
{
	/// <summary>
	/// Interaction logic for ProvedorUbi.xaml
	/// </summary>
	public partial class ProvedorUbi : Window
	{
		Provedor provedor;
		ProvedorBRL brl;
		Location pinUbicacion;

		public ProvedorUbi()
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

		private void BtnSatelite_Click(object sender, RoutedEventArgs e)
		{
			mapaProv.Focus();
			mapaProv.Mode = new AerialMode(true);
		}

		private void BtnCalles_Click(object sender, RoutedEventArgs e)
		{
			mapaProv.Focus();
			mapaProv.Mode = new RoadMode();
		}

		private void BtnAlejar_Click(object sender, RoutedEventArgs e)
		{
			mapaProv.Focus();
			mapaProv.ZoomLevel--;
		}

		private void BtmAcercar_Click(object sender, RoutedEventArgs e)
		{
			mapaProv.Focus();
			mapaProv.ZoomLevel++;
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

		private void BtnRegistrarProvedor_Click(object sender, RoutedEventArgs e)
		{
			txtNit.Text = txtNit.Text.Trim();
			txtRazonSocial.Text = txtRazonSocial.Text.Trim();
			if (Validate.OnlyLettersAndSpaces(txtRazonSocial.Text) && Validate.NitText(txtNit.Text)&&txtNit.Text!=" "&&txtRazonSocial.Text!=" ")
			{
				try
				{												
				//Insertar
				provedor = new Provedor(txtNit.Text.Trim(),txtRazonSocial.Text.Trim(),(float)pinUbicacion.Latitude,(float)pinUbicacion.Longitude);
				brl = new ProvedorBRL(provedor);
				brl.Insert();
				MessageBox.Show("Registro Exitoso");
					mapaProv.Children.Clear();
					LoadDataGrid();
				LimpiarCampos();


				}
				catch (Exception ex)
				{

					MessageBox.Show(ex.Message);
				}
			}
			else
			{
				MessageBox.Show("Ingrese Correctamente los campos");
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{

			LoadDataGrid();
		}

		private void BtnVolverMenPro_Click(object sender, RoutedEventArgs e)
		{
			menuCRUDproductos menCrud = new menuCRUDproductos();
			this.Close();
			menCrud.Show();
		}

		private void BtnSalir_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
