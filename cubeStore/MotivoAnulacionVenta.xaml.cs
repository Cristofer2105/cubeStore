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

namespace cubeStore
{
	/// <summary>
	/// Interaction logic for MotivoAnulacionVenta.xaml
	/// </summary>
	public partial class MotivoAnulacionVenta : Window
	{
		public MotivoAnulacionVenta()
		{
			InitializeComponent();
		}

		private void BtnCerrar_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void BtnAnularVenta_Click(object sender, RoutedEventArgs e)
		{
			if (txtmotivoAnulacion.Text!=""&&Validate.OnlyLettersAndSpaces(txtmotivoAnulacion.Text)==true)
			{
				this.Close();
				MessageBox.Show("Venta anulada con exito");
			}
			else
			{
				MessageBox.Show("Ingrese Correctamente los datos por favor");
			}
			
		}
	}
}
