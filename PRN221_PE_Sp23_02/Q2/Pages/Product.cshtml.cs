using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Q2.Models;

namespace Q2.Pages
{
    public class ProductModel : PageModel
    {

        public List<Product> Products { get; set; }

        public void OnGet()
        {
            using(PRN_Spr23_B1Context context = new PRN_Spr23_B1Context())
            {
                var products = context.Products.Include(p=>p.Category).ToList();

                Products = products.ToList();
            }
        }

        public IActionResult OnGetDelete(int id)
        {
            using (PRN_Spr23_B1Context context = new PRN_Spr23_B1Context())
            {
                var product = context.Products.Include(p=>p.OrderDetails).FirstOrDefault(p => p.ProductId == id);
                if (product != null)
                {
                    var relatedOrderDetails = context.OrderDetails.Where(od => od.ProductId == id).ToList();

                    context.OrderDetails.RemoveRange(relatedOrderDetails);

                    context.Products.Remove(product);
                    context.SaveChanges();
                }
            }
            // Redirect to the same page after deletion
            return RedirectToPage();
        }
    }
}
