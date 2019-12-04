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
		byte operacion = 0;
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
		private void Habilitar(byte operacion)
		{
			btnGuardarUsuario.IsEnabled = true;
			btncancelarAcion.IsEnabled = true;
			txtnombresAg.IsEnabled = true;
			txtprimerapellidoAg.IsEnabled = true;
			txtsegundoApellidoAg.IsEnabled = true;
			txtcorreoAg.IsEnabled = true;

			rbtAdmin.IsEnabled = true;
			rbtEditor.IsEnabled = true;
			rbtVend.IsEnabled = true;
			rbtHombre.IsEnabled = true;
			rbtMujer.IsEnabled = true;

			btnAgregarUsuario.IsEnabled = false;
			btnModificar.IsEnabled = false;
			btnEliminar.IsEnabled = false;
			this.operacion = operacion;
		}

		private void DesHabilitar()
		{
			btnGuardarUsuario.IsEnabled = false;
			btncancelarAcion.IsEnabled = false;
			txtnombresAg.IsEnabled=false;
			txtprimerapellidoAg.IsEnabled = false;
			txtsegundoApellidoAg.IsEnabled = false;
			txtcorreoAg.IsEnabled = false;

			rbtAdmin.IsEnabled = false;
			rbtEditor.IsEnabled = false;
			rbtVend.IsEnabled = false;
			rbtHombre.IsEnabled = false;
			rbtMujer.IsEnabled = false;

			btnAgregarUsuario.IsEnabled = true;
			btnModificar.IsEnabled = true;
			btnEliminar.IsEnabled = true;
		}
		void LimpiarCamposAg()
		{
			txtnombresAg.Text = "";	
			txtprimerapellidoAg.Text = "";	
			txtsegundoApellidoAg.Text = "";	
			txtcorreoAg.Text = "";						
		}
		
		private void BtnSalir_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show("Esta Seguro de Salir?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				Login login = new Login();
				this.Close();
				login.Show();
			}
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
		private void BtnAgregarUsuario_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Complete los campos para agregar un usuario");
			Habilitar(1);
			LimpiarCamposAg();
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

					if (usuario.Rol=="Administrador")
					{
						rbtAdmin.IsChecked = true;
					}
					else if (usuario.Rol == "Editor")
					{
						rbtEditor.IsChecked = true;
					}
					else if (usuario.Rol == "Vendedor")
					{
						rbtVend.IsChecked = true;
					}
					if (usuario.Sexo==1)
					{
						rbtHombre.IsChecked = true;
					}
					else if (usuario.Sexo == 2)
					{
						rbtMujer.IsChecked = true;
					}
					txtnombresAg.Text = usuario.Nombres;
					txtprimerapellidoAg.Text = usuario.PrimerApellido;
					txtsegundoApellidoAg.Text = usuario.SegundoApellido;
					txtcorreoAg.Text = usuario.Correo;	
					
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void BtnEliminar_Click(object sender, RoutedEventArgs e)
		{
			if (txtnombresAg.Text=="")
			{
				MessageBox.Show("Seleccione un registro de la lista para eliminarlo");
			}
			else
			{

			
				if (MessageBox.Show("Esta Seguro de Eliminar el Usuario?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					//Eliminacion Logica
					try
					{
						brl = new UsuarioBRL(usuario);
						brl.Delete();
						LimpiarCamposAg();
						MessageBox.Show("Eliminado Exitosamente");
					
						LoadDataGrid();
		
					}
					catch (Exception ex)
					{

						MessageBox.Show(ex.Message);
					}
				}
			}
		}

		private void BtnModificar_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Seleccione un registro de la lista para modificarlo");
			Habilitar(2);
			LimpiarCamposAg();
		}

		private void BtnGuardarUsuario_Click(object sender, RoutedEventArgs e)
		{
			switch (operacion)
			{
				case 1:
					if (txtnombresAg.Text == "" && txtprimerapellidoAg.Text == "" && txtsegundoApellidoAg.Text == "" && txtcorreoAg.Text == "")
					{
						MessageBox.Show("Debe Llenar los campos para poder agregar un registro");
					}
					else
					{
						txtnombresAg.Text = txtnombresAg.Text.Trim();
						txtprimerapellidoAg.Text = txtprimerapellidoAg.Text.Trim();
						txtcorreoAg.Text = txtcorreoAg.Text.Trim();
						string rol = "";
						if (rbtAdmin.IsChecked == true)
						{
							rol = rol + "Administrador";
						}
						else if (rbtEditor.IsChecked == true)
						{
							rol = rol + "Editor";
						}
						else if (rbtVend.IsChecked == true)
						{
							rol = rol + "Vendedor";
						}



						string sexo = "";
						if (rbtHombre.IsChecked == true)
						{
							sexo = sexo + "1";
						}
						else
						if (rbtMujer.IsChecked == true)
						{
							sexo = sexo + "2";
						}
						
						string usuario1 = txtnombresAg.Text;
						string usuario2 = txtprimerapellidoAg.Text;
						string userName = usuario1.Substring(0, 3) + usuario2.Substring(0, 3);


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

						msg.Body = "Hola que tal Bienvenido a cubestore " + txtnombresAg.Text + " " + txtprimerapellidoAg + "\n";
						msg.Body = "Sus credenciales para ingreso son:\n" + "Usuario:  " + userName + "\nContrseña:  " + contrasenia;
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
							DateTime fecha = DateTime.Now;						
							usuario = new Usuario(txtnombresAg.Text.Trim(), txtprimerapellidoAg.Text.Trim(), txtsegundoApellidoAg.Text.Trim(), byte.Parse(sexo), userName, contrasenia, rol, txtcorreoAg.Text, fecha);
							brl = new UsuarioBRL(usuario);
							brl.Insert();
							client.Send(msg);
							MessageBox.Show("Usuario Agregado Exitosamente");
							LimpiarCamposAg();
							DesHabilitar();
							LoadDataGrid();
						}
						catch (Exception)
						{

							MessageBox.Show("Error al Enviar");
						}
					}
					break;

				case 2:
					if (txtnombresAg.Text == "")
					{
						MessageBox.Show("Seleccione un registro de la lista para modificarlo");
					}
					else
					{
						try
						{
							//Modificar
							//categoria = new Categoria(txtnombreCategoria.Text);
							usuario.Nombres = txtnombresAg.Text.Trim();
							usuario.PrimerApellido = txtprimerapellidoAg.Text.Trim();
							usuario.SegundoApellido = txtsegundoApellidoAg.Text.Trim();
							usuario.Correo = txtcorreoAg.Text.Trim();
							brl = new UsuarioBRL(usuario);
							brl.Update();
							MessageBox.Show("Registro Modificado Exitosamente");
							LimpiarCamposAg();
							DesHabilitar();
							LoadDataGrid();

						}
						catch (Exception ex)
						{

							MessageBox.Show(ex.Message);
						}
					}
					break;
				
			}
		}

		private void BtncancelarAcion_Click(object sender, RoutedEventArgs e)
		{
			DesHabilitar();
			LimpiarCamposAg();
		}
	}
}
