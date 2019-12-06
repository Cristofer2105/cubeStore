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
    /// Interaction logic for AgregarItem.xaml
    /// </summary>
    public partial class AgregarItem : Window
    {
		ItemBRL brl;
		Item item;
		public AgregarItem()
        {
            InitializeComponent();
        }

		private void BtnCerrar_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void BtnAgregarItem_Click(object sender, RoutedEventArgs e)
		{
			//Insertar
			/*
				DateTime fechahora = DateTime.Now;
				item = new Item("asus4566",2,60.2,fechahora);
				brl = new ItemBRL(item);
				brl.Insert();
				MessageBox.Show("Registro Exitoso");
				*/
			
		}
	}
}
