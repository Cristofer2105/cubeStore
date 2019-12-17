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
using System.Diagnostics;
using DAL;

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
		byte intentos=3;
        public Login()
        {
            InitializeComponent();
			txtUusario.Focus();
		}

		private void BtnSalir_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show("Esta Seguro de Salir?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				Application.Current.Shutdown();
			}
			
		}

		private void BtnIngresar_Click(object sender, RoutedEventArgs e)
		{
			string usuario= txtUusario.Text.Trim();
			string contrasenia = txtContrasenia.Password;
			if (usuario!=""&&contrasenia!="")
			{
				try
				{
					brl = new UsuarioBRL();
					DataTable dt = brl.Login(usuario,contrasenia);
					if (dt.Rows.Count > 0)
					{
						//Iniciamos variables de sesion
						Sesion.idSesion = int.Parse(dt.Rows[0][0].ToString());
						Sesion.usuarioSesion = dt.Rows[0][1].ToString();
						Sesion.rolSesion = dt.Rows[0][2].ToString();
						Sesion.nombre = dt.Rows[0][4].ToString();
						Sesion.primerapellido = dt.Rows[0][5].ToString();
						Sesion.segundoapellido = dt.Rows[0][6].ToString();
						Sesion.contrasenia = txtContrasenia.Password;
						Sesion.email= dt.Rows[0][7].ToString();

						//Iniciamos variables de configuracion
						ConfigBRL configBRL = new ConfigBRL();
						DataTable dtConfig = configBRL.Select();
						Config.configpathImagenArticulo = dtConfig.Rows[0][0].ToString();
						if (byte.Parse(dt.Rows[0][3].ToString()) == 1)
						{
							CambiarContrasenia cambia = new CambiarContrasenia();
							this.Close();							
							cambia.Show();
						}
						else
						{										
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
						txtUusario.Focus();
						txtUusario.Text = string.Empty;
						txtContrasenia.Password = string.Empty;
						txbAlertasLogin.Text="Usuario y/o contraseña incorrectos!";
						txbalertasIntentos.Text = "Intentos: "+ (intentos - 1);
						intentos--;
						if (intentos==0)
						{
							Application.Current.Shutdown();
						}
					}
				}
				catch (Exception)
				{
					txtUusario.Focus();
					txtUusario.Text = string.Empty;
					txtContrasenia.Password = string.Empty;
					MessageBox.Show("Hubo un error al iniciar sesion verifique su usuario y/o contraseña");				
				}
			}
			else
			{
				txtUusario.Text = string.Empty;
				txtContrasenia.Password = string.Empty;
				MessageBox.Show("Por favor ingrese su usuario y contraseña");
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
				string usuario = txtUusario.Text.Trim();
				string contrasenia = txtContrasenia.Password;
				if (usuario != "" && contrasenia != "")
				{
					try
					{
						brl = new UsuarioBRL();
						DataTable dt = brl.Login(usuario, contrasenia);
						if (dt.Rows.Count > 0)
						{
							//Iniciamos variables de sesion
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
							if (byte.Parse(dt.Rows[0][3].ToString()) == 1)
							{
								CambiarContrasenia cambia = new CambiarContrasenia();
								this.Close();
								cambia.txtusuarioCambiarContrasenia.Text = txtUusario.Text;
								cambia.Show();
							}
							else
							{
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
							txtUusario.Focus();
							txtUusario.Text = string.Empty;
							txtContrasenia.Password = string.Empty;
							txbAlertasLogin.Text = "Usuario y/o contraseña incorrectos!";
							txbalertasIntentos.Text = "Intentos: " + (intentos - 1);
							intentos--;
							if (intentos == 0)
							{
								Application.Current.Shutdown();
							}
						}
					}
					catch (Exception)
					{
						txtUusario.Focus();
						txtUusario.Text = string.Empty;
						txtContrasenia.Password = string.Empty;
						MessageBox.Show("Hubo un error al iniciar sesion verifique su usuario y/o contraseña");
					}
				}
				else
				{
					txtUusario.Text = string.Empty;
					txtContrasenia.Password = string.Empty;
					MessageBox.Show("Por favor ingrese su usuario y contraseña");
				}
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			txtUusario.Focus();

			//TextWriterTraceListener myListener1 = new TextWriterTraceListener("Log1.log", "myListener1");
			//myListener1.WriteLine("mensaje de log 1");
			Methods.GenerateLogsActivities(DateTime.Now,"Insert Tabka","admin");
			Methods.GenerateLogsErrors(DateTime.Now,"Error Tabka","admin");




		}
	}
}
