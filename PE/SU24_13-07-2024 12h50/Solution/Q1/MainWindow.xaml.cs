using Microsoft.EntityFrameworkCore;
using Q1.Models;
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

namespace Q1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		List<Review> reviews { get; set; }
		public MainWindow()
		{
			InitializeComponent();
			LoadUserName();
			int userId = (int)cboName.SelectedValue;
			LoadReviewList(userId);
		}

		private void btnEdit_Click(object sender, RoutedEventArgs e)
		{
			int userId = (int)cboName.SelectedValue;
			int courseId = Convert.ToInt32(txtId.Text);
			try
			{
				using (var myDB = new PE_PRN_24SumB1Context())
				{
					if(lvReview.SelectedItem is Review selectedReview)
					{
						selectedReview.Rating = Convert.ToInt32(txtRating.Text);
						selectedReview.ReviewText = txtReviewText.Text;
						selectedReview.ReviewDate = dpReviewDate.SelectedDate;

						myDB.SaveChanges();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Edit review");
			}
		}

		private void btnRemove_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				using (var myDB = new PE_PRN_24SumB1Context())
				{
					if (lvReview.SelectedItem is Review selectedReview)
					{
						myDB.Reviews.Remove(selectedReview);
						myDB.SaveChanges();
						reviews.Remove(selectedReview);
						lvReview.Items.Refresh();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Remove review");
			}
		}

		private void LoadUserName()
		{
			try
			{
				using (var myDB = new PE_PRN_24SumB1Context())
				{
					List<User> users = new List<User>();
					users = myDB.Users.ToList();
					cboName.ItemsSource = users;
					cboName.DisplayMemberPath = "Username";
					cboName.SelectedValuePath = "UserId";
					cboName.SelectedIndex = 0;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Load users");
			}
		}

		private void LoadReviewList(int userId)
		{
			try
			{
				using (var myDB = new PE_PRN_24SumB1Context())
				{
					reviews = new List<Review>();
					reviews = myDB.Reviews
						.Where(r => r.UserId == userId)
						.Include(r => r.Course)
						.ToList();
					lvReview.ItemsSource = reviews;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Load reviews");
			}
		}

		private void cboName_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			int userId = (int)cboName.SelectedValue;
			LoadReviewList(userId);
		}
	}
}