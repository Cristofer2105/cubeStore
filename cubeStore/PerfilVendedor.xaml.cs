using Common;
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
    /// Interaction logic for PerfilVendedor.xaml
    /// </summary>
    public partial class PerfilVendedor : Window
    {
        public PerfilVendedor()
        {
            InitializeComponent();
			txbnombreRolUs.Text = Sesion.VerInfo();
		}

		private void BtnVolverUsVendedor_Click(object sender, RoutedEventArgs e)
		{
			MenuVendedor menuVendedor = new MenuVendedor();
			this.Close();
			menuVendedor.Show();
		}

		private void BtnSalir1UsAVendedor_Click(object sender, RoutedEventArgs e)
		{
			Login login = new Login();
			this.Close();
			login.Show();
		}

		private void BtnRestablecerContrasenia_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show("Esta Seguro de restablecer tu contraseña?", "Restablecer", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				RestablecerContraseña restablecerContraseña = new RestablecerContraseña();
				this.Close();
				restablecerContraseña.Show();
			}
		}
	}
}
