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
    /// Interaction logic for UserControlActualizarOptions.xaml
    /// </summary>
    public partial class UserControlActualizarOptions : UserControl
    {
        public UserControlActualizarOptions()
        {
            InitializeComponent();
        }

		private void BtnProvedorActua_Click(object sender, RoutedEventArgs e)
		{
			ActualizarProvedor actu = new ActualizarProvedor();
			menuCRUDproductos menut = new menuCRUDproductos();
			menut.Close();
			actu.Show();
		}
	}
}
