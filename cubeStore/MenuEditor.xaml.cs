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
    /// Interaction logic for MenuEditor.xaml
    /// </summary>
    public partial class MenuEditor : Window
    {
        public MenuEditor()
        {
            InitializeComponent();			
		}

		private void BtnPerfilUsEditor_Click(object sender, RoutedEventArgs e)
		{
			PerfilEditor perfilEditor = new PerfilEditor();
			this.Close();
			perfilEditor.Show();
		}

		private void BtnSalirUsEditor_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show("Esta Seguro de Salir?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				Login login = new Login();
				this.Close();
				login.Show();
			}
		}

		private void BtnProductosUsEditor_Click(object sender, RoutedEventArgs e)
		{
			MenuCRUDproductosEditor menuCRUDproductosEditor = new MenuCRUDproductosEditor();
			this.Close();
			menuCRUDproductosEditor.Show();
		}

		private void BtnAcercaDeUsEditor_Click(object sender, RoutedEventArgs e)
		{
			AcercaDe acercaDe = new AcercaDe();
			acercaDe.ShowDialog();

		}
	}
}
