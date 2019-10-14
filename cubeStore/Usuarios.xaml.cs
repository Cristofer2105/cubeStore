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
using System.Security.Cryptography;

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
		private void LoadDataGrid()
		{
			try
			{
				brl = new UsuarioBRL();
				dgdDatos.ItemsSource = brl.Select().DefaultView;
				dgdDatos.Columns[0].Visibility = Visibility.Hidden;
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}

		}
		static string ToM5Hash(string contrasenia)
		{
			byte[] bytespass = Encoding.ASCII.GetBytes(contrasenia);
			var md5 = new MD5CryptoServiceProvider();
			var md5data = md5.ComputeHash(bytespass);
			string strpass = Encoding.ASCII.GetString(md5data);
			return strpass;
		}

		static string ToM5Hash2(string contrasenia)
		{
			StringBuilder sb = new StringBuilder();
			using (MD5 md5 = MD5.Create())
			{
				byte[] md5HashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(contrasenia));
				foreach (byte b in md5HashBytes)
				{
					sb.Append(b.ToString("X2"));
				}
			}
			return sb.ToString();
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
			LoadDataGrid();
		}
		void habilitarrol()
		{
			chkEdit.IsEnabled = true;
			chkAdmin.IsEnabled = true;
			chkVend.IsEnabled = true;
		}
		private void BtnAgregarUsuario_Click(object sender, RoutedEventArgs e)
		{
			txtnombresAg.Text = txtnombresAg.Text.Trim();
			txtprimerapellidoAg.Text = txtprimerapellidoAg.Text.Trim();
			txtcorreoAg.Text = txtcorreoAg.Text.Trim();
			string rol="";
			if (chkAdmin.IsChecked==true)
			{
				chkEdit.IsEnabled = false;
				chkVend.IsEnabled = false;
				rol = rol+"Administrador";
			}
			else if (chkEdit.IsChecked==true)
			{
				chkVend.IsEnabled = false;
				chkAdmin.IsEnabled = false;
				rol = rol+"Editor";
			}
			else if (chkVend.IsChecked==true)
			{
				chkAdmin.IsEnabled = false;
				chkEdit.IsEnabled = false;
				rol = rol+"Vendedor";
			}


			txtTelefonoAg.Text = txtTelefonoAg.Text.Trim();
			string sexo="";
			if (chkhombre.IsChecked == true && chkmujer.IsChecked == false && chkotros.IsChecked == false)
			{
				sexo = sexo + "1";
			}
			else 
			if (chkmujer.IsChecked == true && chkhombre.IsChecked == false && chkotros.IsChecked == false)
			{
				sexo = sexo + "2";
			}else 
			if (chkotros.IsChecked == true && chkhombre.IsChecked == false && chkmujer.IsChecked == false)
			{
				rol = sexo + "3";
			}
			else
			{
				MessageBox.Show("Solo puede seleccionar uno");
			}
			
				
				
				
				
					
				
			
			
			
			
			string usuario1 = txtnombresAg.Text;
			string usuario2 = txtprimerapellidoAg.Text;
			string userName= usuario1.Substring(0, 3)+usuario2.Substring(0,2);


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

			

			#region enviar correo
			System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
			msg.To.Add(txtcorreoAg.Text);
			msg.Subject = "Registrado para usar el sistema cubestore";
			msg.SubjectEncoding = System.Text.Encoding.UTF8;

			msg.Body = "Hola que tal Bienvenido a cubestore "+txtnombresAg.Text+" "+txtprimerapellidoAg+"\n";
			msg.Body = "Sus credenciales para ingreso son:\n"+"Usuario:  "+userName+"\nContrseña:  "+contrasenia;
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
				usuario = new Usuario(txtnombresAg.Text,txtprimerapellidoAg.Text,txtsegundoApellidoAg.Text,byte.Parse(sexo),txtTelefonoAg.Text,userName,contrasenia,rol,txtcorreoAg.Text);
				brl = new UsuarioBRL(usuario);
				brl.Insert();
				client.Send(msg);
				MessageBox.Show("Usuario Agregado Exitosamente");
				LoadDataGrid();
			}
			catch (Exception)
			{

				MessageBox.Show("Error al Enviar");
			}


		}

		private void DgdDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (dgdDatos.Items.Count > 0 && dgdDatos.SelectedItem != null)
			{
				//Realizamos Get
				try
				{
					DataRowView dataRow = (DataRowView)dgdDatos.SelectedItem;
					int id = int.Parse(dataRow.Row.ItemArray[0].ToString());
					
					
					brl = new UsuarioBRL();
					usuario = brl.Get(id);
			

					txtnombresactelim.Text = usuario.Nombres;
					txtprimapellactelim.Text = usuario.PrimerApellido;
					txtsegapellactelim.Text = usuario.SegundoApellido;
					txtcorreoactelim.Text = usuario.Correo;
					txtrolactelim.Text = usuario.Rol;
					txttelefonoactelim.Text = usuario.Telefonos;					

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void BtnEliminar_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show("Esta Seguro de Eliminar el Usuario?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				//Eliminacion Logica
				try
				{
					brl = new UsuarioBRL(usuario);
					brl.Delete();
					MessageBox.Show("Eliminado Exitosamente");
					LoadDataGrid();
		
				}
				catch (Exception ex)
				{

					MessageBox.Show(ex.Message);
				}
			}
		}

		private void BtnModificar_Click(object sender, RoutedEventArgs e)
		{
			txtnombresactelim.Text = txtnombresactelim.Text.Trim();
			txtprimapellactelim.Text = txtprimapellactelim.Text.Trim();
			txtsegapellactelim.Text = txtsegapellactelim.Text.Trim();
			txtcorreoactelim.Text = txtcorreoactelim.Text.Trim();
			txtrolactelim.Text = txtrolactelim.Text.Trim();
			txttelefonoactelim.Text = txttelefonoactelim.Text.Trim();
	

			try
			{
				//Modificar
				//categoria = new Categoria(txtnombreCategoria.Text);
				usuario.Nombres = txtnombresactelim.Text.Trim();
				usuario.PrimerApellido = txtprimapellactelim.Text.Trim();
				usuario.SegundoApellido = txtsegapellactelim.Text.Trim();
				usuario.Correo = txtcorreoactelim.Text.Trim();
				usuario.Rol = txtrolactelim.Text.Trim();
				usuario.Telefonos = txttelefonoactelim.Text.Trim();

				brl = new UsuarioBRL(usuario);
				brl.Update();
				MessageBox.Show("Registro Modificado Exitosamente");				
				LoadDataGrid();
			
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}
	}
}
