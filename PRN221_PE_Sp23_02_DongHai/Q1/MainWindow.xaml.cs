using Q1.Models;
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
            LoadCategory();
            LoadProduct();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtProductId.Text = "";
            txtProductName.Text = "";
            cboCategory.Text = "";
            txtQuantity.Text = "";
            txtStock.Text = "";
            txtOrder.Text = "";
            cbDis.IsChecked = false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            using (PRN_Spr23_B1Context context = new PRN_Spr23_B1Context())
            {
                var product = new Product()
                {
                    ProductName = txtProductName.Text,
                    CategoryId = (int)cboCategory.SelectedValue,
                    QuantityPerUnit = txtQuantity.Text,
                    UnitPrice = decimal.Parse(txtStock.Text),
                    UnitsInStock = short.Parse(txtOrder.Text),
                    Discontinued = cbDis.IsChecked == true ? true : false,
                };

                context.Products.Add(product);
                context.SaveChanges();
                MessageBox.Show("Add product successfully!");
                LoadProduct();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            using (PRN_Spr23_B1Context context = new PRN_Spr23_B1Context())
            {
                var product = context.Products.FirstOrDefault(p => p.ProductId == int.Parse(txtProductId.Text));
                if (product != null)
                {
                    product.ProductName = txtProductName.Text;
                    product.CategoryId = (int)cboCategory.SelectedValue;
                    product.QuantityPerUnit = txtQuantity.Text;
                    product.UnitPrice = decimal.Parse(txtStock.Text);
                    product.UnitsInStock = short.Parse(txtOrder.Text);
                    product.Discontinued = cbDis.IsChecked == true ? true : false;
                }


                context.Products.Update(product);
                context.SaveChanges();
                MessageBox.Show("Update product successfully!");
                LoadProduct();
            }
        }


        void LoadCategory()
        {
            using(PRN_Spr23_B1Context context = new PRN_Spr23_B1Context())
            {
                var categories = context.Categories.ToList();
                cboCategory.ItemsSource = categories;
                cboCategory.DisplayMemberPath = "CategoryName";
                cboCategory.SelectedValuePath = "CategoryId";
            }
        }

        void LoadProduct()
        {
            using (PRN_Spr23_B1Context context = new PRN_Spr23_B1Context())
            {
                var products = context.Products.Select(p => new
                {
                    p.ProductId,
                    p.ProductName,
                    Category= p.Category.CategoryName,
                    p.QuantityPerUnit,
                    p.UnitPrice,
                    p.UnitsInStock,
                    p.Discontinued,
                }).ToList();
               lvEmployee.ItemsSource = products;
                var gridView = lvEmployee.View as GridView;
                if (gridView != null)
                {
                    gridView.Columns[0].DisplayMemberBinding = new Binding("ProductId");
                    gridView.Columns[1].DisplayMemberBinding = new Binding("ProductName");
                    gridView.Columns[2].DisplayMemberBinding = new Binding("Category"); 
                    gridView.Columns[3].DisplayMemberBinding = new Binding("QuantityPerUnit");
                    gridView.Columns[4].DisplayMemberBinding = new Binding("UnitPrice");
                    gridView.Columns[5].DisplayMemberBinding = new Binding("UnitsInStock");
                    gridView.Columns[6].DisplayMemberBinding = new Binding("Discontinued");
                }
            }

        }

        private void lvEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var product = lvEmployee.SelectedItem as dynamic;
            if (product != null) 
                {
                txtProductId.Text = product.ProductId.ToString();
                txtProductName.Text = product.ProductName;
                cboCategory.Text = product.Category;
                txtQuantity.Text = product.QuantityPerUnit;
                txtStock.Text = product.UnitPrice.ToString();
                txtOrder.Text = product.UnitsInStock.ToString();
                cbDis.IsChecked = product.Discontinued;
            }
        }
    }
}
