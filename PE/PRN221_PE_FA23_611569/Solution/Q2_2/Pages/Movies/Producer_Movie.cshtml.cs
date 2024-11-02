using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Q2_2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q2_2.Pages.Movies
{
	public class Producer_MovieModel : PageModel
	{
		public List<Director> Directors { get; set; }
		public List<Movie> Movies { get; set; }
		public int? SelectedDirectorId { get; set; } 

		public async Task OnGetAsync(int? directorId = null)
		{
			using (PE_PRN_Fall2023B1Context _context = new PE_PRN_Fall2023B1Context())
			{
				Directors = await _context.Directors.ToListAsync();

				if (directorId.HasValue)
				{
					SelectedDirectorId = directorId;
					Movies = await _context.Movies
						.Where(m => m.DirectorId == directorId.Value)
						.Include(m => m.Genres) 
						.Include(m => m.Director)
						.ToListAsync();
				}
				else
				{
					Movies = await _context.Movies
						.Include(m => m.Genres)
						.Include(m => m.Director)
						.ToListAsync();
				}
			}
		}

		public async Task<IActionResult> OnPostDeleteAsync(int id)
		{
			using (var _context = new PE_PRN_Fall2023B1Context())
			{
				var movie = await _context.Movies.Include(m=> m.Genres).Include(m=> m.MovieStars)
					.Include(m=>m.Schedules)
					.FirstOrDefaultAsync(m => m.Id == id);
				if (movie != null)
				{
                    // Xóa các liên kết trong bảng Movie_Genre trước
                    movie.Genres.Clear();
                    await _context.SaveChangesAsync();
                    movie.MovieStars.Clear();
                    await _context.SaveChangesAsync();
                    _context.Schedules.RemoveRange(movie.Schedules);
                    await _context.SaveChangesAsync();
                    _context.Movies.Remove(movie);
					await _context.SaveChangesAsync();
				}
			}

			return RedirectToPage(new { directorId = SelectedDirectorId });
		}
	}
}
