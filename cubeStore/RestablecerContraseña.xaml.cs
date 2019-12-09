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
		public RestablecerContraseña()
        {
            InitializeComponent();
        }

		private void BtnRestablecerContrasenia_Click(object sender, RoutedEventArgs e)
		{
			txtUusario.Text = txtUusario.Text.Trim();
			if (txtUusario.Text != "" && txtUusarioemail.Text != "")
			{
					try
					{
						brl = new UsuarioBRL();
						DataTable dt = brl.RestablecerContrasenia(txtUusario.Text);
						if (dt.Rows.Count > 0)
						{
							if (dt.Rows[0][1].ToString() == txtUusario.Text)
							{
								try
								{
								//Generando la contraseña nueva
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
								//
								//Enviando email
								#region enviar correo
								System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
								msg.To.Add(txtUusarioemail.Text);
								msg.Subject = "Su contraseña se restablecio exitosamente";
								msg.SubjectEncoding = System.Text.Encoding.UTF8;

								msg.Body = "Hola de nuevo:  " + txtUusario.Text + "    Su contraseña es:   "+ contrasenia;
								msg.BodyEncoding = System.Text.Encoding.UTF8;
								msg.IsBodyHtml = true;
								msg.From = new System.Net.Mail.MailAddress("cristoferhilaquita7@gmail.com");

								System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
								client.Credentials = new System.Net.NetworkCredential("cristoferhilaquita7@gmail.com", "Cristofer246");
								client.Port = 587;
								client.EnableSsl = true;
								client.Host = "smtp.gmail.com";
								#endregion
								//
								//Actualizando estado de contrasenia inicial
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
								//
							}
							catch (Exception ex)
								{

									throw ex;
								}
								
						}
						else
							{
								MessageBox.Show("El usuario no Existe");
								txtUusario.Text = "";
								txtUusarioemail.Text = "";
							}
						}
						else
						{
							MessageBox.Show("Usuario o email incorrectos");
							txtUusario.Text = "";
							txtUusarioemail.Text = "";
						}
					}
					catch (Exception ex)
					{

						MessageBox.Show("Error" + ex.Message);
					}
				}
			else
			{
				MessageBox.Show("Tiene que llenar los campos para restablecer su contrasenia");
			}
		}

		private void BtnSalirRestablecer_Click(object sender, RoutedEventArgs e)
		{
			Login login = new Login();
			this.Close();
			login.ShowDialog();
		}
	}
}
