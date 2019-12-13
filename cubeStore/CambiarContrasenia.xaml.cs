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
			txtusuarioCambiarContrasenia.Text = Sesion.usuarioSesion;
			txtContrasenia.Focus();
        }

		private void BtnCambiarContrasenia_Click(object sender, RoutedEventArgs e)
		{
			string nuevaContrasenia = txtContrasenia.Password;
			string repetircontrasenia = txtContraseniarepetir.Password;
			string email = Sesion.email;
			string Nombreusuario = Sesion.usuarioSesion;
			if (nuevaContrasenia!=""&&repetircontrasenia!="")
			{
				if (nuevaContrasenia==repetircontrasenia)
				{
					try
					{
						usuario = new Usuario();
						usuario.NombreUsuario = Sesion.usuarioSesion;
						usuario.Contrasenia = nuevaContrasenia;
						brl = new UsuarioBRL(usuario);
						brl.UpdateContrasenia();
						//Inicio Enviando email
						#region enviar correo
						System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
						msg.To.Add(email);
						msg.Subject = "Informacion Confidencial Sistema cubestore";
						msg.SubjectEncoding = System.Text.Encoding.UTF8;

						msg.Body = "Importante! No compartas esta informacion a cualquier persona "+"  Las credenciales para usar el sistema cubestore son: "+"Usuario: "+ Nombreusuario + ",    Contraseña:   " + nuevaContrasenia;
						msg.BodyEncoding = System.Text.Encoding.UTF8;
						msg.IsBodyHtml = true;
						msg.From = new System.Net.Mail.MailAddress("cristoferhilaquita7@gmail.com");

						System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
						client.Credentials = new System.Net.NetworkCredential("cristoferhilaquita7@gmail.com", "Cristofer246");
						client.Port = 587;
						client.EnableSsl = true;
						client.Host = "smtp.gmail.com";
						client.Send(msg);
						#endregion
						//Fin Enviando email
						MessageBox.Show("El cambio de contraseña fue exitoso, Inicie sesion para comenzar por favor");
						Login login = new Login();
						this.Close();
						login.Show();

					}
					catch (Exception)
					{
						MessageBox.Show("Ocurrio un error al cambiar la contraseña intente de nuevo si el error persiste comuniquese con el administrador de sistemas");
						txtContrasenia.Clear();
						txtusuarioCambiarContrasenia.Clear();
					}
				}
				else
				{
					txbalertasCambiarContraseña.Text = "Ambas contraseñas deben ser iguales";
				}
			}
			else
			{
				txbalertasCambiarContraseña.Text = "Por favor ingrese la nueva contraseña y/o repita la contraseña";
			}		
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			txtContrasenia.Focus();
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				string nuevaContrasenia = txtContrasenia.Password;
				string repetircontrasenia = txtContraseniarepetir.Password;
				string email = Sesion.email;
				string Nombreusuario = Sesion.usuarioSesion;
				if (nuevaContrasenia != "" && repetircontrasenia != "")
				{
					if (nuevaContrasenia == repetircontrasenia)
					{
						try
						{
							usuario = new Usuario();
							usuario.NombreUsuario = Sesion.usuarioSesion;
							usuario.Contrasenia = nuevaContrasenia;
							brl = new UsuarioBRL(usuario);
							brl.UpdateContrasenia();
							//Inicio Enviando email
							#region enviar correo
							System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
							msg.To.Add(email);
							msg.Subject = "Informacion Confidencial Sistema cubestore";
							msg.SubjectEncoding = System.Text.Encoding.UTF8;

							msg.Body = "Importante! No compartas esta informacion a cualquier persona " + "  Las credenciales para usar el sistema cubestore son: " + "Usuario: " + Nombreusuario + ",    Contraseña:   " + nuevaContrasenia;
							msg.BodyEncoding = System.Text.Encoding.UTF8;
							msg.IsBodyHtml = true;
							msg.From = new System.Net.Mail.MailAddress("cristoferhilaquita7@gmail.com");

							System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
							client.Credentials = new System.Net.NetworkCredential("cristoferhilaquita7@gmail.com", "Cristofer246");
							client.Port = 587;
							client.EnableSsl = true;
							client.Host = "smtp.gmail.com";
							client.Send(msg);
							#endregion
							//Fin Enviando email
							MessageBox.Show("El cambio de contraseña fue exitoso, Inicie sesion para comenzar por favor");
							Login login = new Login();
							this.Close();
							login.Show();

						}
						catch (Exception)
						{
							MessageBox.Show("Ocurrio un error al cambiar la contraseña intente de nuevo si el error persiste comuniquese con el administrador de sistemas");
							txtContrasenia.Clear();
							txtusuarioCambiarContrasenia.Clear();
						}
					}
					else
					{
						txbalertasCambiarContraseña.Text = "Ambas contraseñas deben ser iguales";
					}
				}
				else
				{
					txbalertasCambiarContraseña.Text = "Por favor ingrese la nueva contraseña y/o repita la contraseña";
				}
			}
		}
	}
}
