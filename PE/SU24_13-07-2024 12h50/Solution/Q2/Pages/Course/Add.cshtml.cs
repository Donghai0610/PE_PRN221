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
		public Models.Course course { get; set; }
		[BindProperty]
		public List<int> selectedCategories { get; set; }
		public void OnGet()
		{
			using (var myDB = new PE_PRN_24SumB1Context())
			{
				Instructors = myDB.Instructors.ToList();
				Categories = myDB.CourseCategories.ToList();
			}
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			using (var myDB = new PE_PRN_24SumB1Context())
			{
				if (selectedCategories != null && selectedCategories.Any())
				{
					List<CourseCategory> categories = myDB.CourseCategories
						.Where(c => selectedCategories.Contains(c.CategoryId))
						.ToList();
					course.Categories = categories;
					myDB.Courses.Add(course);
					myDB.SaveChanges();
				}

			}
			return RedirectToPage();
		}
	}
}
