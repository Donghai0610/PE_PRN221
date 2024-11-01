using Q1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Q1
{
    public partial class MainWindow : Window
    {
        public List<Review> Reviews { get; set; }
        private readonly PE_PRN_24SumB1Context _context;
        public List<User> Users { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            _context = new PE_PRN_24SumB1Context();

            LoadData();
        }

        private void LoadData()
        {
            _context.Users.Load();
            Users = _context.Users.Local.ToList();
            UserComboBox.ItemsSource = Users;

            // Set the first user as selected by default
            if (Users.Count > 0)
            {
                UserComboBox.SelectedIndex = 0;
                LoadReviewsForUser(Users[0].UserId);
            }
        }

        private void LoadReviewsForUser(int userId)
        {
            Reviews = _context.Reviews.Include(r => r.Course)
                                      .Where(r => r.UserId == userId)
                                      .ToList();
            ReviewsDataGrid.ItemsSource = Reviews;
        }

        private void UserComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserComboBox.SelectedItem is User selectedUser)
            {
                LoadReviewsForUser(selectedUser.UserId);
            }
        }

        private void ReviewsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ReviewsDataGrid.SelectedItem is Review selectedReview)
            {
                CourseIdTextBox.Text = selectedReview.Course.CourseId.ToString();
                CourseTitleTextBox.Text = selectedReview.Course.Title;
                DescriptionTextBox.Text = selectedReview.Course.Description;
                RatingTextBox.Text = selectedReview.Rating.ToString();
                ReviewTextTextBox.Text = selectedReview.ReviewText;
                ReviewDatePicker.SelectedDate = selectedReview.ReviewDate;
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (ReviewsDataGrid.SelectedItem is Review selectedReview)
            {
                selectedReview.Course.CourseId = int.Parse(CourseIdTextBox.Text);
                selectedReview.Course.Title = CourseTitleTextBox.Text;
                selectedReview.Course.Description = DescriptionTextBox.Text;
                selectedReview.Rating = int.Parse(RatingTextBox.Text);
                selectedReview.ReviewText = ReviewTextTextBox.Text;
                selectedReview.ReviewDate = ReviewDatePicker.SelectedDate.GetValueOrDefault(DateTime.Now);

                _context.SaveChanges();
                ReviewsDataGrid.Items.Refresh();
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ReviewsDataGrid.SelectedItem is Review selectedReview)
            {
                _context.Reviews.Remove(selectedReview);
                _context.SaveChanges();
                Reviews.Remove(selectedReview);
                ReviewsDataGrid.Items.Refresh();
            }
        }
    }
}
