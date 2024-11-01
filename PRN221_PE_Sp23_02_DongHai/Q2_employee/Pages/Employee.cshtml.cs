using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Q2_employee.Models;

namespace Q2_employee.Pages
{
    public class EmployeeModel : PageModel
    {
        public List<Employee> Employees { get; set; }

        public void OnGet()
        {
            using (PRN_Spr23_B1Context context = new PRN_Spr23_B1Context())
            {
                var products = context.Employees.Include(p => p.Department).ToList();

                Employees = products.ToList();
            }
        }

        public IActionResult OnGetDelete(int id)
        {
            using (PRN_Spr23_B1Context context = new PRN_Spr23_B1Context())
            {
                var employee = context.Employees.Include(p => p.Orders).FirstOrDefault(p => p.EmployeeId == id);
                if (employee != null)
                {
                    var relatedOrderDetails = context.Orders.Where(od => od.EmployeeId == id).ToList();

                    context.Orders.RemoveRange(relatedOrderDetails);

                    context.Employees.Remove(employee);
                    context.SaveChanges();
                }
            }
            // Redirect to the same page after deletion
            return RedirectToPage();
        }
    }
}
