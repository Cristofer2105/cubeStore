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
    /// Interaction logic for UserControlOpcionesElim.xaml
    /// </summary>
    public partial class UserControlOpcionesElim : UserControl
    {
        public UserControlOpcionesElim()
        {
            InitializeComponent();
        }

		private void ListViewMenuVolv_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UserControl usc = null;
			GridMain.Children.Clear();

			switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
			{
				case "ItemHome":
					usc = new UserControlElimiMenu();
					GridMain.Children.Add(usc);
					break;
				
			}
		}

		private void BtnUbicacion_Click(object sender, RoutedEventArgs e)
		{
			EliminarProvedor eliminarProvedor = new EliminarProvedor();
			menuCRUDproductos crume = new menuCRUDproductos();
			crume.Close();
			eliminarProvedor.Show();
		}
	}
}
