using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Q2.Models;

namespace Q2.Pages.Student
{
    public class ListModel : PageModel
    {

        public List<Major> Majors{ get; set; }

        public IEnumerable<dynamic> Students { get; set; }

        //[BindProperty]
        //public string MajorCode { get; set; }

        //[BindProperty]
        //public int Gender { get; set; }
        //[BindProperty]
        //public string SortBy{ get; set; }

        public void OnGet(string MajorCode, int? Gender, string SortBy)
        {
            using(PE_PRN_Sum24_B5Context context = new PE_PRN_Sum24_B5Context())
            {
                Majors = context.Majors.ToList();
                var query= context.Students.AsQueryable();

                if (!string.IsNullOrEmpty(MajorCode))
                {
                    query = query.Where(s => s.Major == MajorCode);
                }

                query.Where(s => s.Male == (Gender == 1));
                if (SortBy == "StudentName")
                {
                    query = query.OrderBy(s => s.FullName);
                }
                else if (SortBy == "StudentId")
                {
                    query = query.OrderBy(s => s.StudentId);
                }
                else if (SortBy == "StudentDob")
                {
                    query = query.OrderBy(s => s.Dob);
                }
                Students = query.Join(context.Majors,
                 student => student.Major,
                 major => major.MajorCode,
                 (student, major) => new
                 {
                     student.StudentId,
                     student.FullName,
                     student.Male,
                     student.Dob,
                     MajorName = major.MajorName  
                 })
           .ToList<object>();
            }
        }
    }
}
