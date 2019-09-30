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
	/// Interaction logic for menuCRUDproductos.xaml
	/// </summary>
	public partial class menuCRUDproductos : Window
	{
		public menuCRUDproductos()
		{
			InitializeComponent();
		}

		private void BtnVolverMenu_Click(object sender, RoutedEventArgs e)
		{
			MainWindow volvMenu = new MainWindow();
			this.Close();
			volvMenu.Show();
		}

		private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UserControl usc = null;
			GridMain.Children.Clear();

			switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
			{
				case "ItemHome":
					usc = new UserControlAddProducts();
					GridMain.Children.Add(usc);
					break;
				case "ItemCreate":
					usc = new UserControlAddProducts();
					GridMain.Children.Add(usc);
					break;
				default:
					break;
			}
		}
	}
}
