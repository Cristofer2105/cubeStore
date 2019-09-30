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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cubeStore
{
	/// <summary>
	/// Interaction logic for UserControlAddProducts.xaml
	/// </summary>
	public partial class UserControlAddProducts : UserControl
	{
		public UserControlAddProducts()
		{
			InitializeComponent();
		}

		private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UserControl usc = null;
			GridMain.Children.Clear();

			switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
			{
				case "ItemHome":
					usc = new UserControl1();
					GridMain.Children.Add(usc);
					break;
				case "ItemCreate":
					usc = new UserControl1();
					GridMain.Children.Add(usc);
					break;
				default:
					break;
			}
		}

		private void BtnArticulo_Click(object sender, RoutedEventArgs e)
		{
			AdminProductos adm = new AdminProductos();
			menuCRUDproductos men = new menuCRUDproductos();
			men.Close();
			adm.Show();
			
		}

		private void BtnCategoria_Click(object sender, RoutedEventArgs e)
		{
			Productos pr = new Productos();
			menuCRUDproductos men = new menuCRUDproductos();
			men.Close();
			pr.Show();
		}

		private void BtnUbicacion_Click(object sender, RoutedEventArgs e)
		{
			ProvedorUbi provedorUbi = new ProvedorUbi();
			menuCRUDproductos menuCRUDproductos = new menuCRUDproductos();
			menuCRUDproductos.Close();
			provedorUbi.Show();
		}
	}
}
