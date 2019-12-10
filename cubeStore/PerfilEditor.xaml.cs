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
    /// Interaction logic for PerfilEditor.xaml
    /// </summary>
    public partial class PerfilEditor : Window
    {
		UsuarioBRL usbrl;
		public PerfilEditor()
        {
            InitializeComponent();
			txbnombreRolUs.Text = Sesion.VerInfo();
			txtNombre.Text = Sesion.nombre;
			txtprimerApellido.Text = Sesion.primerapellido;
			txtsegundoApellido.Text = Sesion.segundoapellido;
			txtContrasenia.Text = Sesion.contrasenia;
		}
		private void Habilitar()
		{
			btnGuardarCambios.IsEnabled = true;
			btnCancelarCambios.IsEnabled = true;
			txtNombre.IsEnabled = true;
			txtprimerApellido.IsEnabled = true;
			txtsegundoApellido.IsEnabled = true;
			txtContrasenia.Visibility = Visibility.Visible;

			EditarPerfil.IsEnabled = false;
		}

		private void DesHabilitar()
		{
			btnGuardarCambios.IsEnabled = false;
			btnCancelarCambios.IsEnabled = false;
			txtNombre.IsEnabled = false;
			txtprimerApellido.IsEnabled = false;
			txtsegundoApellido.IsEnabled = false;
			txtContrasenia.Visibility = Visibility.Hidden;
			EditarPerfil.IsEnabled = true;

		}
		private void BtnVolverUsEditor_Click(object sender, RoutedEventArgs e)
		{
			MenuEditor menuEditor = new MenuEditor();
			this.Close();
			menuEditor.Show();
		}	

		private void BtnSalir1UsEditor_Click(object sender, RoutedEventArgs e)
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
			if (MessageBox.Show("Esta Seguro de restablecer tu contraseña?", "Restablecer", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
					RestablecerContraseña restablecerContraseña = new RestablecerContraseña();
					this.Close();
					restablecerContraseña.Show();
			}
			
		}

		private void EditarPerfil_Click(object sender, RoutedEventArgs e)
		{
			Habilitar();
		}

		private void BtnGuardarCambios_Click(object sender, RoutedEventArgs e)
		{
			if (txtNombre.Text != "" && txtContrasenia.Text != "" && txtprimerApellido.Text != "")
			{
				if (MessageBox.Show("Esta seguro de Editar su Perfil?", "Editar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					try
					{
						Usuario usuario = new Usuario();
						usuario.Nombres = txtNombre.Text.Trim();
						usuario.PrimerApellido = txtprimerApellido.Text.Trim();
						usuario.SegundoApellido = txtsegundoApellido.Text.Trim();
						usuario.Contrasenia = txtContrasenia.Text.Trim();
						usuario.IdUsuario = Sesion.idSesion;
						usbrl = new UsuarioBRL(usuario);
						usbrl.UpdateDatosPerfil();
						MessageBox.Show("Perfil editado exitosamente");
						DesHabilitar();
					}
					catch (Exception)
					{

						MessageBox.Show("No se pudo editar el perfil comuniquese con el administrador de sistemas");
					}

				}
			}
			else
			{
				MessageBox.Show("Complete los campos porfavor");
			}
		}

		private void BtnCancelarCambios_Click(object sender, RoutedEventArgs e)
		{
			DesHabilitar();
			txtContrasenia.Text = Sesion.contrasenia;
			txtNombre.Text = Sesion.nombre;
			txtprimerApellido.Text = Sesion.primerapellido;
			txtsegundoApellido.Text = Sesion.segundoapellido;
		}
	}
}
