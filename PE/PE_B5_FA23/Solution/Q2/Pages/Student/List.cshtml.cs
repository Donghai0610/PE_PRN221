using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Q2.Models;

namespace Q2.Pages.Student
{
	public class ListModel : PageModel
	{
		public List<Major> majors { get; set; }
		public List<Models.Student> students { get; set; }
		[BindProperty(SupportsGet = true)]
		public string? MajorCode { get; set; }

		[BindProperty(SupportsGet = true)]
		public int? Gender { get; set; }

		[BindProperty(SupportsGet = true)]
		public string? Sort { get; set; }
		public void OnGet()
		{
			using (var myDB = new PE_PRN221_Fall23B5Context())
			{
				students = myDB.Students.ToList();
				majors = myDB.Majors.ToList();

				if (!string.IsNullOrEmpty(MajorCode))
				{
					students = students.Where(s => s.Major.Equals(MajorCode)).ToList();
				}
				if (Gender.HasValue)
				{
					students = students.Where(s => s.Male == (Gender == 0 ? true : false)).ToList();
				}
				if (!string.IsNullOrEmpty(Sort))
				{
					if (Sort.Equals("name"))
					{
						students = students.OrderBy(s => s.FullName).ToList();
					}
					else if (Sort.Equals("id"))
					{
						students = students.OrderBy(s => s.StudentId).ToList();
					}
					if (Sort.Equals("dob"))
					{
						students = students.OrderBy(s => s.Dob).ToList();
					}
				}
			}
		}
	}
}
