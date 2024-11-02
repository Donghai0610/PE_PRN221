using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Q2_2.Models;

namespace Q2_2.Pages.Course
{
    public class AddsModel : PageModel
    {
        public List<Instructor> Instructors { get; set; }
        public List<CourseCategory> Categories { get; set; }
        [BindProperty]
        public Models.Course Course { get; set; }

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

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                using (PE_PRN_24SumB1Context _context = new PE_PRN_24SumB1Context())
                {
                    if (!ModelState.IsValid)
                    {
                        return Page();
                    }

                    // Attach the selected categories to the new course
                    Course.Categories = _context.CourseCategories
                        .Where(c => SelectedCategoryIds.Contains(c.CategoryId))
                        .ToList();

                    _context.Courses.Add(Course);
                    await _context.SaveChangesAsync();

                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToPage("/Course/Adds");
        }
    }
}
