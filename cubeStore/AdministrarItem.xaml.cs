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
using System.Data;

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
			Items items= new Items();
			this.Close();
			items.Show();
		}

		private void BtnActualizarItem_Click(object sender, RoutedEventArgs e)
		{
			//Modificar
			if (txtcodigo.Text == "" && txtidItem.Text == "" && txtpreciobase.Text == "" )
			{
				MessageBox.Show("El codigo y/o el precio del item no pueden ir vacios");
			}
			else
			{

				txtcodigo.Text = txtcodigo.Text.Trim();
				txtidItem.Text = txtidItem.Text.Trim();
				txtpreciobase.Text = txtpreciobase.Text.Trim();
				brl = new ItemBRL();
				DataTable dt = brl.VerificarItem(txtcodigo.Text);
				if (dt.Rows.Count == 0)
				{
					try
					{
						//Modificar
						item = new Item();
						item.CodigoItem = txtcodigo.Text;
						item.PrecioBaseItem = double.Parse(txtpreciobase.Text.ToString());
						item.IdItem = int.Parse(txtidItem.Text.ToString());
						brl = new ItemBRL(item);
						brl.Update();
						MessageBox.Show("Item Modificado Exitosamente");
						Items itemss = new Items();
						txtidItem.Text = "";
						txtcodigo.Text = "";
						txtpreciobase.Text = "";
						this.Close();
						itemss.Show();
					}
					catch (Exception)
					{

						MessageBox.Show("Ocurrio un error al modificar el Item intente nuevamente si el error persiste comuniquese con el administrador de sistemas");
					}
				}
				else
				{
					if (txtcodigo.Text==""&&txtpreciobase.Text=="")
					{
						MessageBox.Show("Complete el codigo y/o el precio del Item");
					}
					else
					{
						item = new Item();
						item.CodigoItem = txtcodigo.Text;
						item.PrecioBaseItem = double.Parse(txtpreciobase.Text.ToString());
						item.IdItem = int.Parse(txtidItem.Text.ToString());
						brl = new ItemBRL(item);
						brl.Update();
						MessageBox.Show("El Item ya existe solo se modifico el precio");
						Items itemss = new Items();
						txtidItem.Text = "";
						txtcodigo.Text = "";
						txtpreciobase.Text = "";
						this.Close();
						itemss.Show();
					}					
				}
			}		

		}

		private void BtnEliminarItem_Click(object sender, RoutedEventArgs e)
		{
			if (txtidItem.Text!="")
			{
				if (MessageBox.Show("Esta Seguro de Eliminar el Item?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					//Eliminacion Logica
					try
					{

						item = new Item();
						item.IdItem = int.Parse(txtidItem.Text.ToString());
						brl = new ItemBRL(item);
						brl.Delete();
						MessageBox.Show("Item eliminado Exitosamente");
						Items items = new Items();
						txtidItem.Text = "";
						txtcodigo.Text = "";
						txtpreciobase.Text = "";
						this.Close();
						items.Show();
					}
					catch (Exception ex)
					{

						MessageBox.Show("Ocurrio un error al eliminar intente nuevamente si el error persiste comuniquese con el administrador de sistemas");
					}
				}
			}
			else
			{
				MessageBox.Show("Debe seleccionar un registro de la lista de Items");
			}
		}
	}
}
