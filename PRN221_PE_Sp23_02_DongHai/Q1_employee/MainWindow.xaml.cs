using Q1_employee.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Q1_employee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadEmployee();
            LoadDepartment();
        }
        void LoadEmployee()
        {
            using (PRN_Spr23_B1Context context = new PRN_Spr23_B1Context())
            {
                var employees = context.Employees.Select(p => new
                {
                    p.EmployeeId,
                    p.FirstName,
                    p.LastName,
                    DepartmentName = p.Department.DepartmentName,
                    p.Title,
                    p.TitleOfCourtesy,
                    p.BirthDate
                }).ToList();

                lvEmployee.ItemsSource = employees;
                var gridView = lvEmployee.View as GridView;
                if (gridView != null)
                {
                    gridView.Columns[0].DisplayMemberBinding = new Binding("EmployeeId");
                    gridView.Columns[1].DisplayMemberBinding = new Binding("FirstName");
                    gridView.Columns[2].DisplayMemberBinding = new Binding("LastName");
                    gridView.Columns[3].DisplayMemberBinding = new Binding("DepartmentName");
                    gridView.Columns[4].DisplayMemberBinding = new Binding("Title");
                    gridView.Columns[5].DisplayMemberBinding = new Binding("TitleOfCourtesy");
                    gridView.Columns[6].DisplayMemberBinding = new Binding("BirthDate");
                }
            }

        }

        void LoadDepartment()
        {
            using (PRN_Spr23_B1Context context = new PRN_Spr23_B1Context())
            {
                var departments = context.Departments.ToList();
                cboCategory.ItemsSource = departments;
                cboCategory.DisplayMemberPath = "DepartmentName";
                cboCategory.SelectedValuePath = "DepartmentId";
            }

        }
        private void lvEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var employee = lvEmployee.SelectedItem as dynamic;
            if (employee != null)
            {
                txtEmployeeID.Text = employee.EmployeeId.ToString();
                txtFirstName.Text = employee.FirstName;
                txtLastname.Text = employee.LastName;
                cboCategory.Text = employee.DepartmentName;
                txtTitle.Text = employee.Title;
                cboCour.Text = employee.TitleOfCourtesy;
                dtpDOB.Text = employee.BirthDate.ToString();

            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtEmployeeID.Text = "";
            txtFirstName.Text = "";
            txtLastname.Text = "";
            cboCategory.Text = "";
            txtTitle.Text = "";
            cboCour.Text = "";
            dtpDOB.Text = null;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            using (PRN_Spr23_B1Context context = new PRN_Spr23_B1Context())
            {


                var employee = new Employee()
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastname.Text,
                    DepartmentId = (int)cboCategory.SelectedValue,
                    Title = txtTitle.Text,
                    TitleOfCourtesy = cboCour.Text,
                    BirthDate = dtpDOB.SelectedDate
                };

                context.Employees.Add(employee);
                context.SaveChanges();
                MessageBox.Show("Add employee successfully!");
                LoadEmployee();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            using (PRN_Spr23_B1Context context = new PRN_Spr23_B1Context())
            {
                var employee = context.Employees.FirstOrDefault(p => p.EmployeeId == int.Parse(txtEmployeeID.Text));
                if (employee != null)
                {
                    employee.FirstName = txtFirstName.Text;
                    employee.LastName = txtLastname.Text;
                    employee.DepartmentId = (int)cboCategory.SelectedValue;
                    employee.Title = txtTitle.Text;
                    employee.TitleOfCourtesy = cboCour.Text;
                    employee.BirthDate = dtpDOB.SelectedDate;
                }
                context.Employees.Update(employee);
                context.SaveChanges();
                MessageBox.Show("Update employee successfully!");
                LoadEmployee();
            }

           

        }
    }
}