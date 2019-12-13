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
	/// Interaction logic for ConfirmarContraseña.xaml
	/// </summary>
	public partial class ConfirmarContraseña : Window
	{
		byte intentos=3;
		UsuarioBRL brl;
		Usuario usuario;
		public ConfirmarContraseña()
		{
			InitializeComponent();
			txtContrasenia.Focus();
		}

		private void BtnSalirConfirmarContraseña_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			txtContrasenia.Focus();
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{

		}

		private void BtnRestablecerContraseñaUsuario_Click(object sender, RoutedEventArgs e)
		{
			string contraReal = Sesion.contrasenia;
			string contraseniaAdmin = txtContrasenia.Password;
			string repetirContraseniaAdmin = txtContraseniarepetir.Password;
			int idEmpleado = int.Parse(txtidUsuarioRestablecimiento.Text);
			string correoEmpleado;
			string nombreUsuario;
			if (contraseniaAdmin!=""&&repetirContraseniaAdmin!="")
			{
				if (contraReal==contraseniaAdmin)
				{
					if (contraseniaAdmin==repetirContraseniaAdmin)
					{
						brl = new UsuarioBRL();
						DataTable dt = brl.RestablecerContraseñaDesdeAdministrador(idEmpleado);
						if (dt.Rows.Count > 0)
						{
							
								try
								{
									//Inicio Generando la contraseña nueva
									correoEmpleado = dt.Rows[0][7].ToString();
									nombreUsuario = dt.Rows[0][1].ToString();
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
									msg.To.Add(correoEmpleado);
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
									usuario.IdUsuario = idEmpleado;
									usuario.Contrasenia = contrasenia;
									brl = new UsuarioBRL(usuario);
									brl.UpdateContraseniaRestablecidaParaAdministrador();
									client.Send(msg);
									MessageBox.Show("Contraseña de empleado restablecida correctamente");
									this.Close();
									//Fin Actualizando estado de contrasenia inicial
								}
								catch (Exception)
								{

									MessageBox.Show("Ocurrio un error al enviar el correo por favor verifique su conexion a internet");
								}
							
						}
						else
						{
							MessageBox.Show("El empleado no pudo ser encontrado intente nuevamente si el error persiste comuniquese con el administrador de sistemas");
						}
					}
					else
					{
						txbalertasConfirmarContraseña.Text = "Ambas contraseñas deben ser iguales";
					}
				}
				else
				{
					txtContrasenia.Focus();
					txtContrasenia.Password = string.Empty;
					txtContraseniarepetir.Password = string.Empty;
					txbalertasConfirmarContraseña.Text = "Contraseña incorrecta quedan: "+(intentos-1)+" intentos!";
					intentos--;
					if (intentos==0)
					{
						this.Close();
					}
				}
			}
			else
			{
				txtContrasenia.Focus();
				txtContrasenia.Password = string.Empty;
				txtContraseniarepetir.Password = string.Empty;
				txbalertasConfirmarContraseña.Text = "Por favor ingrese su contraseña y/o repita su contraseña";
			}
		}
	}
}
