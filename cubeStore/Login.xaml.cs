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
using Common;
using BRL;
using System.Data;
using System.Threading;
using System.Timers;

namespace cubeStore
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
		SessionBRL sesBRL;
		UsuarioBRL brl;
		Session ses;
        public Login()
        {
            InitializeComponent();
			txtUusario.Focus();
		}

		private void BtnSalir_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show("Esta Seguro de Salir?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				this.Close();

			}
			
		}

		private void BtnIngresar_Click(object sender, RoutedEventArgs e)
		{

			txtUusario.Text = txtUusario.Text.Trim();
			if (txtUusario.Text != "" && txtContrasenia.Password != "")
			{
				try
				{
					brl = new UsuarioBRL();
					DataTable dt = brl.Login(txtUusario.Text, txtContrasenia.Password);
					if (dt.Rows.Count > 0)
					{
						if (byte.Parse(dt.Rows[0][3].ToString()) == 1)
						{
							CambiarContrasenia cambia = new CambiarContrasenia();
							this.Close();
							cambia.Show();
						}
						else
						{
							//Iniciamos variable de sesion
							Sesion.idSesion = int.Parse(dt.Rows[0][0].ToString());
							Sesion.usuarioSesion = dt.Rows[0][1].ToString();
							Sesion.rolSesion = dt.Rows[0][2].ToString();
							Sesion.nombre = dt.Rows[0][4].ToString();
							Sesion.primerapellido = dt.Rows[0][5].ToString();
							Sesion.segundoapellido = dt.Rows[0][6].ToString();
							Sesion.contrasenia = txtContrasenia.Password;

							//Iniciamos variables de configuracion
							ConfigBRL configBRL = new ConfigBRL();
							DataTable dtConfig = configBRL.Select();
							Config.configpathImagenArticulo = dtConfig.Rows[0][0].ToString();
							if (dt.Rows[0][2].ToString() == "Administrador")
							{
								//Insertar session
								DateTime fechahora = DateTime.Now;
								ses = new Session(fechahora, int.Parse(dt.Rows[0][0].ToString()));
								sesBRL = new SessionBRL(ses);
								sesBRL.Insert();
								MainWindow menu = new MainWindow();
								this.Visibility = Visibility.Hidden;
								menu.Show();
							}
							else if (dt.Rows[0][2].ToString() == "Editor")
							{
								//Insertar session
								DateTime fechahora = DateTime.Now;
								ses = new Session(fechahora, int.Parse(dt.Rows[0][0].ToString()));
								sesBRL = new SessionBRL(ses);
								sesBRL.Insert();
								MenuEditor menuedit = new MenuEditor();
								this.Visibility = Visibility.Hidden;
								menuedit.Show();
							}
							else if (dt.Rows[0][2].ToString() == "Vendedor")
							{
								//Insertar session
								DateTime fechahora = DateTime.Now;
								ses = new Session(fechahora, int.Parse(dt.Rows[0][0].ToString()));
								sesBRL = new SessionBRL(ses);
								sesBRL.Insert();
								MenuVendedor menVend = new MenuVendedor();
								this.Visibility = Visibility.Hidden;
								menVend.Show();
							}
						}


					}
					else
					{
						MessageBox.Show("Usuario o contrasenia Incorrectos");
						txtUusario.Text = "";
						txtContrasenia.Password = "";
					}
				}
				catch (Exception ex)
				{

					MessageBox.Show("Error" + ex.Message);
				}
			}
			else
			{
				MessageBox.Show("Tiene que llenar los campos para ingresar");
			}
		}

		private void BtnRestablecerContraseña_Click(object sender, RoutedEventArgs e)
		{
			RestablecerContraseña restablecerContraseña = new RestablecerContraseña();
			this.Close();
			restablecerContraseña.Show();
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				txtUusario.Text = txtUusario.Text.Trim();
				if (txtUusario.Text != "" && txtContrasenia.Password != "")
				{
					try
					{
						brl = new UsuarioBRL();
						DataTable dt = brl.Login(txtUusario.Text, txtContrasenia.Password);
						if (dt.Rows.Count > 0)
						{
							if (byte.Parse(dt.Rows[0][3].ToString()) == 1)
							{
								CambiarContrasenia cambia = new CambiarContrasenia();
								this.Close();
								cambia.Show();
							}
							else
							{
								//Iniciamos variable de sesion
								Sesion.idSesion = int.Parse(dt.Rows[0][0].ToString());
								Sesion.usuarioSesion = dt.Rows[0][1].ToString();
								Sesion.rolSesion = dt.Rows[0][2].ToString();
								Sesion.nombre = dt.Rows[0][4].ToString();
								Sesion.primerapellido = dt.Rows[0][5].ToString();
								Sesion.segundoapellido = dt.Rows[0][6].ToString();
								Sesion.contrasenia = txtContrasenia.Password;
								//Iniciamos variables de configuracion

								if (dt.Rows[0][2].ToString() == "Administrador")
								{
									//Insertar session
									DateTime fechahora = DateTime.Now;
									ses = new Session(fechahora, int.Parse(dt.Rows[0][0].ToString()));
									sesBRL = new SessionBRL(ses);
									sesBRL.Insert();
									MainWindow menu = new MainWindow();
									this.Visibility = Visibility.Hidden;
									menu.Show();
								}
								else if (dt.Rows[0][2].ToString() == "Editor")
								{
									//Insertar session
									DateTime fechahora = DateTime.Now;
									ses = new Session(fechahora, int.Parse(dt.Rows[0][0].ToString()));
									sesBRL = new SessionBRL(ses);
									sesBRL.Insert();
									MenuEditor menuedit = new MenuEditor();
									this.Visibility = Visibility.Hidden;
									menuedit.Show();
								}
								else if (dt.Rows[0][2].ToString() == "Vendedor")
								{
									//Insertar session
									DateTime fechahora = DateTime.Now;
									ses = new Session(fechahora, int.Parse(dt.Rows[0][0].ToString()));
									sesBRL = new SessionBRL(ses);
									sesBRL.Insert();
									MenuVendedor menVend = new MenuVendedor();
									this.Visibility = Visibility.Hidden;
									menVend.Show();
								}
							}


						}
						else
						{
							MessageBox.Show("Usuario o contrasenia Incorrectos");
							txtUusario.Text = "";
							txtContrasenia.Password = "";
						}
					}
					catch (Exception ex)
					{

						MessageBox.Show("Error" + ex.Message);
					}
				}
				else
				{
					MessageBox.Show("Tiene que llenar los campos para ingresar");
				}
			}
		}
	}
}
