using BRL;
using Common;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for RestablecerContraseña.xaml
    /// </summary>
    public partial class RestablecerContraseña : Window
    {
		UsuarioBRL brl;
		Usuario usuario;
		byte intentos = 3;
		public RestablecerContraseña()
        {
            InitializeComponent();
			txtUusario.Focus();
        }

		private void BtnRestablecerContrasenia_Click(object sender, RoutedEventArgs e)
		{
			string nombreUsuario = txtUusario.Text.Trim();
			string correoUsuario = Sesion.email;
			if (nombreUsuario != "")
			{
				try
				{
					brl = new UsuarioBRL();
					DataTable dt = brl.VerificarUser(nombreUsuario);
					if (dt.Rows.Count > 0)
					{						
						try
						{
						correoUsuario= dt.Rows[0][7].ToString();
						nombreUsuario = dt.Rows[0][1].ToString();
						//Inicio Generando la contraseña nueva
						Random rdn = new Random();
						string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
						int longitud = caracteres.Length;
						char letra;
						int longitudContrasenia = 6;
						string contraseniaAleatoria = string.Empty;
						for (int i = 0; i < longitudContrasenia; i++)
						{
							letra = caracteres[rdn.Next(longitud)];
							contraseniaAleatoria += letra.ToString();
						}
						string contrasenia = contraseniaAleatoria;
						//Fin Generando la contraseña nueva
						//Inicio Enviando email
						#region enviar correo
						System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
						msg.To.Add(correoUsuario);
						msg.Subject = "Informacion Confidencial Sistema cubestore";
						msg.SubjectEncoding = System.Text.Encoding.UTF8;

						msg.Body = "Importante! No compartas esta informacion a cualquier persona. Se restablecio su contraseña, las credenciales para usar el sistema cubestore son: " +"Usuario: "+ nombreUsuario + ",    Su contraseña es:   "+ contrasenia;
						msg.BodyEncoding = System.Text.Encoding.UTF8;
						msg.IsBodyHtml = true;
						msg.From = new System.Net.Mail.MailAddress("cristoferhilaquita7@gmail.com");

						System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
						client.Credentials = new System.Net.NetworkCredential("cristoferhilaquita7@gmail.com", "Cristofer246");
						client.Port = 587;
						client.EnableSsl = true;
						client.Host = "smtp.gmail.com";
						#endregion
						//Fin Enviando email
						//Inicio Actualizando estado de contrasenia inicial
						usuario = new Usuario();
						usuario.NombreUsuario = txtUusario.Text;
						usuario.Contrasenia = contrasenia;
						brl = new UsuarioBRL(usuario);
						brl.UpdateContraseniaRestablecida();
						client.Send(msg);
						MessageBox.Show("Contraseña restablecida correctamente revise su correo por favor");
						Login login = new Login();
						this.Close();
						login.Show();
						//Fin Actualizando estado de contrasenia inicial
						}
						catch (Exception )
						{

						MessageBox.Show("Ocurrio un error al enviar el correo por favor verifique su conexion a internet");
						}
								
					}														
					else
					{
						txtUusario.Focus();
						txtUusario.Text = string.Empty;
						txbAlertasRestablecerContrasenia.Text = "El usuario es incorrecto, Quedan "+ (intentos - 1) + " Intentos";
						intentos--;
						if (intentos==0)
						{
							Login login = new Login();
							this.Close();
							login.Show();
						}	
					}
				}
				catch (Exception )
				{
				MessageBox.Show("Ocurrio un error al restablecer la contraseña intente de nuevo, si el error persiste comuniquese con el administrador de sistemas");
				}
			}
			else
			{
				MessageBox.Show("Por favor ingrese su usario para el restablecimiento de contraseña");
			}
		}

		private void BtnSalirRestablecer_Click(object sender, RoutedEventArgs e)
		{
			Login login = new Login();
			this.Close();
			login.ShowDialog();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			txtUusario.Focus();
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				string nombreUsuario = txtUusario.Text.Trim();
				string correoUsuario = Sesion.email;
				if (nombreUsuario != "")
				{
					try
					{
						brl = new UsuarioBRL();
						DataTable dt = brl.VerificarUser(nombreUsuario);
						if (dt.Rows.Count > 0)
						{
							try
							{
								correoUsuario = dt.Rows[0][7].ToString();
								nombreUsuario = dt.Rows[0][1].ToString();
								//Inicio Generando la contraseña nueva
								Random rdn = new Random();
								string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
								int longitud = caracteres.Length;
								char letra;
								int longitudContrasenia = 6;
								string contraseniaAleatoria = string.Empty;
								for (int i = 0; i < longitudContrasenia; i++)
								{
									letra = caracteres[rdn.Next(longitud)];
									contraseniaAleatoria += letra.ToString();
								}
								string contrasenia = contraseniaAleatoria;
								//Fin Generando la contraseña nueva
								//Inicio Enviando email
								#region enviar correo
								System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
								msg.To.Add(correoUsuario);
								msg.Subject = "Informacion Confidencial Sistema cubestore";
								msg.SubjectEncoding = System.Text.Encoding.UTF8;

								msg.Body = "Importante! No compartas esta informacion a cualquier persona. Se restablecio su contraseña, las credenciales para usar el sistema cubestore son: " + "Usuario: " + nombreUsuario + ",    Su contraseña es:   " + contrasenia;
								msg.BodyEncoding = System.Text.Encoding.UTF8;
								msg.IsBodyHtml = true;
								msg.From = new System.Net.Mail.MailAddress("cristoferhilaquita7@gmail.com");

								System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
								client.Credentials = new System.Net.NetworkCredential("cristoferhilaquita7@gmail.com", "Cristofer246");
								client.Port = 587;
								client.EnableSsl = true;
								client.Host = "smtp.gmail.com";
								#endregion
								//Fin Enviando email
								//Inicio Actualizando estado de contrasenia inicial
								usuario = new Usuario();
								usuario.NombreUsuario = txtUusario.Text;
								usuario.Contrasenia = contrasenia;
								brl = new UsuarioBRL(usuario);
								brl.UpdateContraseniaRestablecida();
								client.Send(msg);
								MessageBox.Show("Contraseña restablecida correctamente revise su correo por favor");
								Login login = new Login();
								this.Close();
								login.Show();
								//Fin Actualizando estado de contrasenia inicial
							}
							catch (Exception)
							{

								MessageBox.Show("Ocurrio un error al enviar el correo por favor verifique su conexion a internet");
							}

						}
						else
						{
							txtUusario.Focus();
							txtUusario.Text = string.Empty;
							txbAlertasRestablecerContrasenia.Text = "El usuario es incorrecto, Quedan " + (intentos - 1) + " Intentos";
							intentos--;
							if (intentos == 0)
							{
								Login login = new Login();
								this.Close();
								login.Show();
							}
						}
					}
					catch (Exception)
					{
						MessageBox.Show("Ocurrio un error al restablecer la contraseña intente de nuevo, si el error persiste comuniquese con el administrador de sistemas");
					}
				}
				else
				{
					MessageBox.Show("Por favor ingrese su usario para el restablecimiento de contraseña");
				}
			}
		}
	}
}
