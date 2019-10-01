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
    /// Interaction logic for ProvedoresVista.xaml
    /// </summary>
    public partial class ProvedoresVista : Window
    {
		Provedor provedor;
		ProvedorBRL brl;
		Location pinUbicacion;
		public ProvedoresVista()
        {
            InitializeComponent();
        }
		private void LoadDataGridTodo()
		{
			try
			{
				brl = new ProvedorBRL();
				dgdDatos.ItemsSource = brl.SelectTodo().DefaultView;
				dgdDatos.Columns[0].Visibility = Visibility.Hidden;
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}

		}
		
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			LoadDataGridTodo();
		}

		private void BtnRegistrarProvedor_Click(object sender, RoutedEventArgs e)
		{
			menuCRUDproductos menu = new menuCRUDproductos();
			this.Close();
			menu.Show();
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
			


				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}
	}
}
