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

namespace cubeStore.User_Controls
{
    /// <summary>
    /// Interaction logic for UserControlElim.xaml
    /// </summary>
    public partial class UserControlElim : UserControl
    {
        public UserControlElim()
        {
            InitializeComponent();
        }

		private void ListViewMenu2_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UserControl usc = null;
			GridMain2.Children.Clear();

			switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
			{
				case "ItemHome":
					usc = new UserControlAddProducts();
					GridMain2.Children.Add(usc);
					break;
				case "ItemCreate":
					usc = new UserControlAddProducts();
					GridMain2.Children.Add(usc);
					break;
				default:
					break;
			}
		}

		private void ListViewMenuElimMen_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UserControl usc = null;
			GridMain2.Children.Clear();

			switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
			{
				case "ItemHome2":
					usc = new UserControlOpcionesElim();
					GridMain2.Children.Add(usc);
					break;
				case "ItemCreate":
					usc = new UserControlOpcionesElim();
					GridMain2.Children.Add(usc);
					break;
				default:
					break;
			}
		}
	}
}
