using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Q1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private List<Product> products = new List<Product>();
		public MainWindow()
		{
			InitializeComponent();
		}

		Dictionary<int, Product> productDictionary = new Dictionary<int, Product>();
		private void btnAddToList_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (checkValid())
				{
					Product product = new Product
					{
						ID = Convert.ToInt32(txtId.Text),
						Name = txtName.Text,
						Price = Convert.ToDouble(txtPrice.Text)
					};
					products.Add(product);
					productDictionary.Add(product.ID, product);
					lvProducts.Items.Add(product);

					txtId.Clear();
					txtName.Clear();
					txtPrice.Clear();
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Add product");
			}
		}

		private void btnSaveFile_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog dialog = new SaveFileDialog
			{
				Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
				DefaultExt = ".json"
			};
			if(dialog.ShowDialog() == true)
			{
				string jsonString = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
				File.WriteAllText(dialog.FileName, jsonString);
				MessageBox.Show("Save to file successfully!", "Save File");
			}
		}

		private bool checkValid()
		{
			bool valid = true;
			string msg = "";

			if (string.IsNullOrEmpty(txtId.Text.Trim()))
			{
				msg += "Id can not be empty\n";
			}
			else
			{
				if (!int.TryParse(txtId.Text.Trim(), out int id))
				{
					msg += "Id must be a number\n";
				}
			}
			if (string.IsNullOrEmpty(txtName.Text.Trim()))
			{
				msg += "Name can not be empty\n";
			}
			if (string.IsNullOrEmpty(txtPrice.Text.Trim()))
			{
				msg += "Price can not be empty\n";
			}
			else
			{
				if (!double.TryParse(txtPrice.Text.Trim(), out double price))
				{
					msg += "Price must be a number\n";
				}
			}
			if (msg.Length > 0)
			{
				valid = false;
				MessageBox.Show(msg);
			}
			return valid;
		}
	}
}