using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Q2_2.Models;

namespace Q2_2.Pages.Course
{
    public class AddModel : PageModel
    {

        public List<CourseCategory> categories { get; set; }
        public List<Instructor> instructors { get; set; }
        [BindProperty]
        public Models.Course Course { get; set; }

        [BindProperty]
        public List<int> SelectedCategoryIds { get; set; }
        public void OnGet()
        {
            using (PE_PRN_24SumB1Context context = new PE_PRN_24SumB1Context())
            {
                categories = context.CourseCategories.ToList();
                instructors = context.Instructors.ToList();
            }
        }

        public IActionResult OnPost()
        {
            using (PE_PRN_24SumB1Context _context = new PE_PRN_24SumB1Context())
            {
                if (!ModelState.IsValid)
                {
                    categories = _context.CourseCategories.ToList();
                    instructors = _context.Instructors.ToList();
                    return Page();
                }

                var newCourse = new Models.Course
                {
                    Title = Course.Title,
                    Description = Course.Description,
                    InstructorId = Course.InstructorId
                };

                if (SelectedCategoryIds != null && SelectedCategoryIds.Count > 0)
                {
                    var selectedCategories = _context.CourseCategories
                                                     .Where(c => SelectedCategoryIds.Contains(c.CategoryId))
                                                     .ToList();

                    newCourse.Categories = selectedCategories;
                }

                _context.Courses.Add(newCourse);
                _context.SaveChanges();

                return RedirectToPage("/Course/Add");
            }

        }
    }
}


