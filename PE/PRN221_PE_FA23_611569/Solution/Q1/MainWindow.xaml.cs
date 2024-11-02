using Microsoft.Win32;
using Q1.Models;
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
		private List<Director> directors = new List<Director>();
		private List<string> nations = new List<string>()
		{
			"USA",
			"UK",
			"France"
		};
		public MainWindow()
		{
			InitializeComponent();
			rdGenderMale.IsChecked = true;
			cboNationality.ItemsSource = nations;
			cboNationality.SelectedIndex = 0;

			//test
			using (var myDB = new PE_PRN_Fall2023B1Context())
			{
				lvDirectors.ItemsSource = myDB.Directors.ToList();
			}
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			try
			{
                Director director = new Director
                {
                    Name = txtDirectorName.Text,
                    Dob = dtpDate.SelectedDate,
                    Male = rdGenderMale.IsChecked == true,
                    Description = txtDescription.Text,
                    Nationality = cboNationality.SelectedValue.ToString()
                };
                directors.Add(director);
                lvDirectors.Items.Add(director);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Director");
            }
            
		}

		private void btnImport_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
				Title = "Select a JSON File"
			};
			if (openFileDialog.ShowDialog() == true)
			{
				try
				{
					string jsonContent = File.ReadAllText(openFileDialog.FileName);
					List<Director> directorsFile = JsonSerializer.Deserialize<List<Director>>(jsonContent);
					foreach (Director d in directorsFile)
					{
						lvDirectors.Items.Add(d);
						directors.Add(d);
					}
					MessageBox.Show("Import success", "Import from file");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Import from file");
				}
			}
		}

		private void btnSave_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				using (var myDB = new PE_PRN_Fall2023B1Context())
				{
					foreach (var director in directors)
					{
						director.Id = 0;
						myDB.Directors.Add(director);
					}
					myDB.SaveChanges();
					MessageBox.Show("Save to database successfully!");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Save to database");
			}

		}
	}
}