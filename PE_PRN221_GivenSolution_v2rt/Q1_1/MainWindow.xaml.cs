using Microsoft.EntityFrameworkCore;
using Q1_1.Models;
using System.Diagnostics.Metrics;
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

namespace Q1_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadUser();

        }

        private void LoadUser()
        {
            using (PE_PRN_24SumB1Context context = new PE_PRN_24SumB1Context())
            {
                var users = context.Users.ToList();
                cboUser.ItemsSource = users;
                cboUser.DisplayMemberPath = "Username";
                cboUser.SelectedValuePath = "UserId";
                if (users.Count > 0)
                {
                    cboUser.SelectedIndex = 0;
                    LoadReviewForUser(users[0].UserId);
                }
            }
        }

        void LoadReviewForUser(int userId)
        {
            using (PE_PRN_24SumB1Context context = new PE_PRN_24SumB1Context())
            {
                var reviews = context.Reviews.Include(r => r.Course)
                    .Where(r => r.UserId == userId).Select(r => new
                    {
                        r.CourseId,
                        Title = r.Course.Title,
                        Description = r.Course.Description,
                        r.Rating,
                        ReviewText = r.ReviewText,
                        ReviewDate = r.ReviewDate
                    }).ToList();
                dgvCourse.ItemsSource = reviews;
            }
        }


        private void cboUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboUser.SelectedItem is User selectedUser)
            {
                LoadReviewForUser(selectedUser.UserId);
            }
        }

        private void dgvCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           var selectedReview = dgvCourse.SelectedItem as dynamic;
            if (selectedReview != null)
            {
                txtCourseId.Text = Convert.ToInt32(selectedReview.CourseId).ToString();
                txtReview.Text = selectedReview.ReviewText;
                txtTitle.Text = selectedReview.Title;
                txtDes.Text = selectedReview.Description;
                txtRating.Text = selectedReview.Rating.ToString();
                txtReview.Text = selectedReview.ReviewText;
               dtpDate.SelectedDate = selectedReview.ReviewDate;

            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            txtCourseId.IsReadOnly = true;
            txtTitle.IsReadOnly = true;
            txtDes.IsReadOnly = true;

            if(string.IsNullOrEmpty(txtTitle.Text) && string.IsNullOrEmpty(txtDes.Text))
            {
                MessageBox.Show("Can not edit course information");
                return;
                
            }
            if (!int.TryParse(txtRating.Text,out int rating))
            {
                MessageBox.Show("Rating must be a number");
                return;
            }
                try
            {
                using(PE_PRN_24SumB1Context context = new PE_PRN_24SumB1Context())
                {
                   var review = context.Reviews.FirstOrDefault(r => r.CourseId == Convert.ToInt32(txtCourseId.Text));
                    int userid = (int)cboUser.SelectedValue;
                    if (review != null)
                    {
                        review.Rating = Convert.ToInt32(txtRating.Text);
                        review.ReviewText = txtReview.Text;
                        review.ReviewDate = dtpDate.SelectedDate;
                        context.Reviews.Update(review);
                        if  (context.SaveChanges() > 0)
                        {
                            MessageBox.Show("Review updated successfully");
                        }
                        else
                        {
                            MessageBox.Show("Review not updated");
                        }


                        LoadReviewForUser(userid);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemoce_Click(object sender, RoutedEventArgs e)
        {
            if (dgvCourse.SelectedItem != null)
            {
                var selectedReview = dgvCourse.SelectedItem as dynamic;
                int userid = (int)cboUser.SelectedValue;
                using (PE_PRN_24SumB1Context context = new PE_PRN_24SumB1Context())
                {
                    var review = context.Reviews.Include(r=>r.Course).FirstOrDefault(r => r.CourseId == Convert.ToInt32(txtCourseId.Text));
                    if (review != null)
                    {
                        context.Reviews.Remove(review);
                        if(context.SaveChanges() > 0)
                        {
                            MessageBox.Show("Review removed successfully");
                        }
                        else
                        {
                            MessageBox.Show("Review not removed");
                        }
                        LoadReviewForUser(userid);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a review to remove");
            }
        }
    }
}