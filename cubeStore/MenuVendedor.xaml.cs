﻿using Common;
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
    /// Interaction logic for MenuVendedor.xaml
    /// </summary>
    public partial class MenuVendedor : Window
    {
        public MenuVendedor()
        {
            InitializeComponent();			
		}

		private void BtnPerfilUsVendedor_Click(object sender, RoutedEventArgs e)
		{
			PerfilVendedor perfilVendedor = new PerfilVendedor();
			this.Close();
			perfilVendedor.Show();
		}

		private void BtnSalir1UsVendedor_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show("Esta Seguro de Salir?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				Login login = new Login();
				this.Close();
				login.Show();
			}
		}

		private void BtnAcercaDeUsVendedor_Click(object sender, RoutedEventArgs e)
		{
			AcercaDe acercaDe = new AcercaDe();
			acercaDe.ShowDialog();
		}

		private void BtnVentasUsVendedor_Click(object sender, RoutedEventArgs e)
		{
			MenuVentasVendedor menuVentas = new MenuVentasVendedor();
			menuVentas.ShowDialog();
		}

		private void BtnSalirUsVendedor_Click(object sender, RoutedEventArgs e)
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
