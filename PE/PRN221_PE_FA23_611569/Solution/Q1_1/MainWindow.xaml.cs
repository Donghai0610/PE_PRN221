using Microsoft.Win32;
using Q1_1.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Windows.Data;

namespace Q1_1
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Director> directors = new ObservableCollection<Director>();

        public MainWindow()
        {
            InitializeComponent();
            ConfigureListView(); 
            lvDirectors.ItemsSource = directors; 
            LoadDirectors(); 
        }

        private void ConfigureListView()
        {
            // Tạo GridView và cột trong code-behind
            var gridView = new GridView();

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Name",
                DisplayMemberBinding = new Binding("Name")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Gender",

                DisplayMemberBinding = new Binding("GenderDisplay")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Date of Birth",
                DisplayMemberBinding = new Binding("Dob")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Nationality",
                DisplayMemberBinding = new Binding("Nationality")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Description",
                DisplayMemberBinding = new Binding("Description")
            });

            // Gán GridView vào ListView
            lvDirectors.View = gridView;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var director = new Director
            {
                Name = txtDirectorName.Text.Trim(),
                Dob = dtpDate.SelectedDate,
                Male = rdGenderMale.IsChecked == true,
                Nationality = cboNationality.Text.Trim(),
                Description = txtDescription.Text.Trim(),
            };

            directors.Add(director); 

           
            txtDirectorName.Clear();
            rdGenderMale.IsChecked = true; 
            dtpDate.SelectedDate = null;
            cboNationality.SelectedIndex = -1;
            txtDescription.Clear();
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string jsonContent = File.ReadAllText(openFileDialog.FileName);
                    List<Director> importedDirectors = JsonSerializer.Deserialize<List<Director>>(jsonContent);

                    if (importedDirectors != null)
                    {
                        foreach (var director in importedDirectors)
                        {
                            directors.Add(director);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi đọc file JSON: " + ex.Message);
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            using (PE_PRN_Fall2023B1Context context = new PE_PRN_Fall2023B1Context())
            {
                foreach (var director in directors)
                {
                    director.Id = 0;

                    if (!context.Directors.Any(d => d.Name == director.Name && d.Dob == director.Dob))
                    {
                        context.Directors.Add(director);
                    }
                }

                context.SaveChanges();
                MessageBox.Show("Dữ liệu đã được lưu vào cơ sở dữ liệu!");
            }
        }


        void LoadDirectors()
        {
            using (PE_PRN_Fall2023B1Context context = new PE_PRN_Fall2023B1Context())
            {
                var loadedDirectors = context.Directors.ToList();

                directors.Clear();
                foreach (var director in loadedDirectors)
                {
                    directors.Add(director);
                }
            }
        }

        private void lvDirectors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var director = lvDirectors.SelectedItem as Director;

            if (director != null)
            {
                txtDirectorName.Text = director.Name;
                rdGenderMale.IsChecked = director.Male;
                rdGenderFemale.IsChecked = !director.Male;
                dtpDate.SelectedDate = director.Dob;
                cboNationality.Text = director.Nationality;
                txtDescription.Text = director.Description;
            }
        }
    }
}
