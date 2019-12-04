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
    /// Interaction logic for PerfilAdministrador.xaml
    /// </summary>
    public partial class PerfilAdministrador : Window
    {
        public PerfilAdministrador()
        {
            InitializeComponent();
			txbnombreRolUs.Text = Sesion.VerInfo();		
		}

		private void BtnVolverUsAdministrador_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = new MainWindow();
			this.Close();
			mainWindow.Show();
		}

		private void BtnSalir1UsAdministrador_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show("Esta Seguro de Salir?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				Login login = new Login();
				this.Close();
				login.Show();
			}
			
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
