using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Q2.Models;

namespace Q2.Pages.Course
{
    public class AddModel : PageModel
    {
        public List<Instructor> Instructors { get; set; }
        public List<CourseCategory> Categories { get; set; }
        [BindProperty]
        public Models.Course NewCourse { get; set; }

        [BindProperty]
        public List<int> SelectedCategoryIds { get; set; }
        public void OnGet()
        {
            using (PE_PRN_24SumB1Context context = new PE_PRN_24SumB1Context())
            {
                Categories = context.CourseCategories.ToList();
                Instructors = context.Instructors.ToList();
            }
        }

        public IActionResult OnPost()
        {
            using (PE_PRN_24SumB1Context _context = new PE_PRN_24SumB1Context())
            {
                if (!ModelState.IsValid)
                {
                    Categories = _context.CourseCategories.ToList();
                    Instructors = _context.Instructors.ToList();
                    return Page();
                }
                NewCourse.Categories = _context.CourseCategories.Where(c => SelectedCategoryIds.Contains(c.CategoryId)).ToList();
                _context.Courses.Add(NewCourse);
                _context.SaveChanges();
                return RedirectToPage();

            }

        }

       
    }
}
