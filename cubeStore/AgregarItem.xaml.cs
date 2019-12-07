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
			Items items = new Items();
			this.Close();
			items.ShowDialog();
		}

		private void BtnAgregarItem_Click(object sender, RoutedEventArgs e)
		{
			//Insertar
			if (txtcodigoinsert.Text == "" && txtpreciobaseinsert.Text==""&&txtIdProductoInsertar.Text=="")
			{
				MessageBox.Show("Debe completar todos los campos del formulario");
			}
			else
			{
				txtpreciobaseinsert.Text = txtpreciobaseinsert.Text.Trim();
				txtcodigoinsert.Text = txtcodigoinsert.Text.Trim();

				try
				{
					//Insertar
					DateTime fechahora = DateTime.Now;
					item = new Item(txtcodigoinsert.Text, int.Parse(txtIdProductoInsertar.Text.ToString()), double.Parse(txtpreciobaseinsert.Text.ToString()), fechahora);
					brl = new ItemBRL(item);
					brl.Insert();
					MessageBox.Show("Registro Exitoso");
					txtcodigoinsert.Text = "";
					txtIdProductoInsertar.Text = "";
					txtnombreproductoinsert.Text = "";
					txtpreciobaseinsert.Text = "";
					Items itemswin = new Items();
					itemswin.dgdbusqueda.ItemsSource = null;
					itemswin.dgdbusqueda.Visibility = Visibility.Hidden;
					itemswin.txtnombreproductobuscado.Text = "";
					this.Close();
					itemswin.Show();



				}
				catch (Exception ex)
				{

					MessageBox.Show(ex.Message);
				}
			}					
		}
	}
}
