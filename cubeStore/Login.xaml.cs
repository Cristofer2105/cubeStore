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
						MainWindow main = new MainWindow();
						this.Visibility=Visibility.Hidden;
						main.Show();

					}
					else
					{
						MessageBox.Show("Error Datos 2");
					}
				}
				catch (Exception ex)
				{

					MessageBox.Show("Error"+ex.Message);
				}
			}
			else
			{
				MessageBox.Show("Error Datos ");
			}
			
		}
	}
}
