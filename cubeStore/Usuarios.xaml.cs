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

namespace cubeStore
{
    /// <summary>
    /// Interaction logic for Usuarios.xaml
    /// </summary>
    public partial class Usuarios : Window
    {
		Usuario usuario;
		UsuarioBRL brl;
        public Usuarios()
        {
            InitializeComponent();
        }

		private void BtnSalir_Click(object sender, RoutedEventArgs e)
		{
			Login login = new Login();
			this.Close();
			login.Show();
		}

		private void BtnVolver_Click(object sender, RoutedEventArgs e)
		{
			MainWindow main = new MainWindow();
			this.Close();
			main.Show();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("prueba");
		}

		private void BtnAgregarUsuario_Click(object sender, RoutedEventArgs e)
		{
			txtnombresAg.Text = txtnombresAg.Text.Trim();
			txtprimerapellidoAg.Text = txtprimerapellidoAg.Text.Trim();
			txtcorreoAg.Text = txtcorreoAg.Text.Trim();
			txtrolad.Text = txtrolad.Text.Trim();
			txtTelefonoAg.Text = txtTelefonoAg.Text.Trim();
			txtsexoAg.Text = txtsexoAg.Text.Trim();

			
			#region enviar correo
			System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
			msg.To.Add(txtcorreoAg.Text);
			msg.Subject = "Registrado para usar el sistema cubestore";
			msg.SubjectEncoding = System.Text.Encoding.UTF8;
	

			msg.Body = "Sus credenciales para ingreso son";
			msg.BodyEncoding = System.Text.Encoding.UTF8;
			msg.IsBodyHtml = true;
			msg.From = new System.Net.Mail.MailAddress("cristoferhilaquita7@gmail.com");

			System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
			client.Credentials = new System.Net.NetworkCredential("cristoferhilaquita7@gmail.com", "Cristofer246");
			client.Port = 587;
			client.EnableSsl = true;
			client.Host = "smtp.gmail.com";
			#endregion

			try
			{
				usuario = new Usuario(txtnombresAg.Text,txtprimerapellidoAg.Text,txtsegundoApellidoAg.Text,byte.Parse(txtsexoAg.Text),txtTelefonoAg.Text,"lucio","123456",txtrolad.Text,txtcorreoAg.Text);
				brl = new UsuarioBRL(usuario);
				brl.Insert();
				client.Send(msg);
				MessageBox.Show("Usuario Agregado Exitosamente");
			}
			catch (Exception)
			{

				MessageBox.Show("Error al Enviar");
			}


		}
	}
}
