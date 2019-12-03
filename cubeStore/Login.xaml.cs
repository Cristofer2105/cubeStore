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

namespace cubeStore
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
		UsuarioBRL brl;
        public Login()
        {
            InitializeComponent();
        }

		private void BtnSalir_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
			
		}

		private void BtnIngresar_Click(object sender, RoutedEventArgs e)
		{
			txtUusario.Text = txtUusario.Text.Trim();
			if (txtUusario.Text!=""&&txtContrasenia.Password!="")
			{
				try
				{
					brl = new UsuarioBRL();
					DataTable dt = brl.Login(txtUusario.Text, txtContrasenia.Password);
					if (dt.Rows.Count>0)
					{
						
						Sesion.idSesion= int.Parse(dt.Rows[0][0].ToString());
						Sesion.usuarioSesion= dt.Rows[0][1].ToString();
						Sesion.rolSesion= dt.Rows[0][2].ToString();
						if (dt.Rows[0][2].ToString() == "Administrador")
						{
							MainWindow menu = new MainWindow();
							this.Visibility = Visibility.Hidden;
							menu.Show();
						}
						else if (dt.Rows[0][2].ToString() == "Editor")
						{
							MenuEditor menuedit = new MenuEditor();
							this.Visibility = Visibility.Hidden;
							menuedit.Show();
						}
						else if (dt.Rows[0][2].ToString() == "Vendedor")
						{
							MenuVendedor menVend = new MenuVendedor();
							this.Visibility = Visibility.Hidden;
							menVend.Show();
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

					MessageBox.Show("Error"+ex.Message);
				}
			}
			else
			{
				MessageBox.Show("Tiene que llenar los campos para ingresar");
			}
			
		}
	}
}
