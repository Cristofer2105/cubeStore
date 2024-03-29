﻿using System;
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
	/// Interaction logic for MenuVentas.xaml
	/// </summary>
	public partial class MenuVentas : Window
	{
		public MenuVentas()
		{
			InitializeComponent();
		}

		private void BtnSalirVentas_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void BtnClientes_Click(object sender, RoutedEventArgs e)
		{
			Clientes clientes = new Clientes();
			clientes.ShowDialog();
		}

		private void BtnVender_Click(object sender, RoutedEventArgs e)
		{
			Vender venders = new Vender();
			venders.ShowDialog();
		}

		private void BtnVentas_Click(object sender, RoutedEventArgs e)
		{
			AdministrarVentas administrarVentas = new AdministrarVentas();
			administrarVentas.ShowDialog();
		}
	}
}
