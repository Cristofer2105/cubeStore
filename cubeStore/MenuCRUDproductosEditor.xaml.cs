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
	/// Interaction logic for MenuCRUDproductosEditor.xaml
	/// </summary>
	public partial class MenuCRUDproductosEditor : Window
	{
		public MenuCRUDproductosEditor()
		{
			InitializeComponent();
		}

		private void BtnArticulos_Click(object sender, RoutedEventArgs e)
		{

		}

		private void BtnCategorias_Click(object sender, RoutedEventArgs e)
		{
			Categorias categorias = new Categorias();
			categorias.ShowDialog();
		}

		private void BtnItems_Click(object sender, RoutedEventArgs e)
		{

		}

		private void BtnProvedores_Click(object sender, RoutedEventArgs e)
		{
			Provedores provedores = new Provedores();
			provedores.ShowDialog();
		}
		private void BtnSalir_Click(object sender, RoutedEventArgs e)
		{
			MenuEditor menuEditor = new MenuEditor();
			this.Close();
			menuEditor.Show();
		}
		private void BtnVolver_Click(object sender, RoutedEventArgs e)
		{
			MenuEditor menuEditor = new MenuEditor();
			this.Close();
			menuEditor.Show();
		}

		private void BtnPerfilEditor_Click(object sender, RoutedEventArgs e)
		{
			PerfilEditor perfilEditor = new PerfilEditor();
			this.Close();
			perfilEditor.Show();
		}

		private void BtnSalirEditor_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show("Esta Seguro de Salir?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				Login login = new Login();
				this.Close();
				login.Show();
			}
		}
	}
}
