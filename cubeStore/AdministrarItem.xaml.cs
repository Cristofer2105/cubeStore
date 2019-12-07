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
using BRL;

namespace cubeStore
{
    /// <summary>
    /// Interaction logic for AdministrarItem.xaml
    /// </summary>
    public partial class AdministrarItem : Window
    {
		Item item;
		ItemBRL brl;
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
			//Modificar
			if (txtcodigo.Text == "" && txtidItem.Text == "" && txtpreciobase.Text == "" )
			{
				MessageBox.Show("Tiene que llenar el formulario");
			}
			else
			{

				txtcodigo.Text = txtcodigo.Text.Trim();
				txtidItem.Text = txtidItem.Text.Trim();
				txtpreciobase.Text = txtpreciobase.Text.Trim();

				try
				{
					//Modificar
					item= new Item();
					item.CodigoItem = txtcodigo.Text;
					item.PrecioBaseItem = double.Parse(txtpreciobase.Text.ToString());
					item.IdItem = int.Parse(txtidItem.Text.ToString());
					brl = new ItemBRL(item);
					brl.Update();
					MessageBox.Show("Registro Modificado Exitosamente");
					Items itemss = new Items();
					txtidItem.Text = "";
					txtcodigo.Text = "";
					txtpreciobase.Text = "";
					this.Close();
					itemss.Show();
				}
				catch (Exception ex)
				{

					MessageBox.Show(ex.Message);
				}

			}		

		}

		private void BtnEliminarItem_Click(object sender, RoutedEventArgs e)
		{
			if (txtidItem.Text!="")
			{
				if (MessageBox.Show("Esta Seguro de Eliminar el Registro?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					//Eliminacion Logica
					try
					{

						item = new Item();
						item.IdItem = int.Parse(txtidItem.Text.ToString());
						brl = new ItemBRL(item);
						brl.Delete();
						MessageBox.Show("Eliminado Exitosamente");
						Items items = new Items();
						txtidItem.Text = "";
						txtcodigo.Text = "";
						txtpreciobase.Text = "";
						this.Close();
						items.Show();
					}
					catch (Exception ex)
					{

						MessageBox.Show(ex.Message);
					}
				}
			}
			else
			{
				MessageBox.Show("Debe seleccionar un registro de la lista");
			}
		}
	}
}
