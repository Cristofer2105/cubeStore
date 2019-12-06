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
    /// Interaction logic for AdministrarItem.xaml
    /// </summary>
    public partial class AdministrarItem : Window
    {
        public AdministrarItem()
        {
            InitializeComponent();
        }

		private void BtnCerrar_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void BtnActualizarItem_Click(object sender, RoutedEventArgs e)
		{
			/*
			//Modificar
			item = new Item();
			item.IdItem = 2;
			item.CodigoItem = "corsair34566";
			item.PrecioBaseItem = 90.99;
			brl = new ItemBRL(item);
			brl.Update();
			MessageBox.Show("Registro modificado exitosamente");
			*/
		
		}

		private void BtnEliminarItem_Click(object sender, RoutedEventArgs e)
		{
			//Eliminar
			/*
			item = new Item();
			item.IdItem = 2;
			brl = new ItemBRL(item);
			brl.Delete();
			MessageBox.Show("Eliminado Exitosamente");
			*/
		}
	}
}
