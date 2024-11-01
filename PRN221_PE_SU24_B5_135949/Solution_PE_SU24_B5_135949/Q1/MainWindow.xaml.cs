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
        public MainWindow()
        {
            InitializeComponent();
        }

        List<Customer> customers = new List<Customer>();    
        Dictionary<int, Customer> customerDictionary = new Dictionary<int, Customer>();
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {


            if (txtID.Text == "" || txtName.Text == "" || dtpDOB.SelectedDate == null)
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            if (customerDictionary.ContainsKey(Convert.ToInt32(txtID.Text)))
            {
                MessageBox.Show("Customer already exists");
                return;
            }

            if(dtpDOB.SelectedDate.Value > DateTime.Now)
            {
                MessageBox.Show("Invalid Date of Birth");
                return;
            }

            Customer c = new Customer();
            c.ID = Convert.ToInt32(txtID.Text);
            c.Name = txtName.Text;
            c.DOB = dtpDOB.SelectedDate.Value;
            customers.Add(c);
            customerDictionary.Add(c.ID, c);
            lstCustomer.Items.Add(c);
        }

        private void btnSave_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.ShowDialog();
            dialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            dialog.DefaultExt = "json";

            if(dialog.ShowDialog() == true)
            {
                string filePath = dialog.FileName;
                var json = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string jsonData = JsonSerializer.Serialize(customers, json);
                File.WriteAllText(filePath, jsonData);
                MessageBox.Show("Data saved successfully");
            }

        }

        private void btnLoad_Click()
        {

        }
    }
}