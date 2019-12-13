using BRL;
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
    /// Interaction logic for CambiarContrasenia.xaml
    /// </summary>
    public partial class CambiarContrasenia : Window
    {
		Usuario usuario;
		UsuarioBRL brl;
		public CambiarContrasenia()
        {
            InitializeComponent();
        }

		private void BtnCambiarContrasenia_Click(object sender, RoutedEventArgs e)
		{
			if (txtusuarioCambiarContrasenia.Text==""&&txtContrasenia.Password=="")
			{
				MessageBox.Show("Debe ingresar los campos!");
			}
			else
			{
				try
				{
					usuario = new Usuario();
					usuario.NombreUsuario = txtusuarioCambiarContrasenia.Text;
					usuario.Contrasenia = txtContrasenia.Password.Trim();
					brl = new UsuarioBRL(usuario);
					brl.UpdateContrasenia();
					MessageBox.Show("Contraseña actualizada correctamente");
					Login login = new Login();
					this.Close();
					login.Show();
					
				}
				catch (Exception ex)
				{
					MessageBox.Show("Verifique que los datos sean correctos");
					txtContrasenia.Clear();
					txtusuarioCambiarContrasenia.Clear();
				}
			}
		}
	}
}
