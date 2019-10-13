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
    /// Interaction logic for Usuarios.xaml
    /// </summary>
    public partial class Usuarios : Window
    {
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
			System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
			msg.To.Add("cristoferhilaquita6@gmail.com");
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
			try
			{
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
