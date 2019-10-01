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
    /// Interaction logic for EliminarProvedor.xaml
    /// </summary>
    public partial class EliminarProvedor : Window
    {
		Provedor provedor;
		ProvedorBRL brl;
		
		public EliminarProvedor()
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
		private void BtnEliminar_Click(object sender, RoutedEventArgs e)
		{

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
					int id = int.Parse(dataRow.Row.ItemArray[0].ToString());
					double aux = double.Parse(dataRow.Row.ItemArray[3].ToString());
					double aux2 = double.Parse(dataRow.Row.ItemArray[4].ToString());
					//longitud = double.Parse(dataRow.Row.ItemArray[3].ToString());
					brl = new ProvedorBRL();
					provedor = brl.Get(id);
					//MessageBox.Show(  " " + aux);
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

		private void BtnEliminar_Click_1(object sender, RoutedEventArgs e)
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
				}
				catch (Exception ex)
				{

					MessageBox.Show(ex.Message);
				}
			}
		}

		private void BtnVolver_Click(object sender, RoutedEventArgs e)
		{
			menuCRUDproductos menu = new menuCRUDproductos();
			this.Close();
			menu.Show();
		}

		private void BtnSalir_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
