using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Q2.Models;

namespace Q2.Pages.Movies
{
	public class Producer_MovieModel : PageModel
	{
		public List<Director> directors;
		public List<Movie> movies;
		public int directorId { get; set; }
		public void OnGet()
		{
			using (var myDB = new PE_PRN_Fall2023B1Context())
			{
				directors = myDB.Directors.ToList();
				movies = myDB.Movies
					.Include(m => m.Genres)
					.Include(m => m.Director)
					.ToList();
			}
		}

		public IActionResult OnGetFilter(int directorId)
		{
			directorId = directorId;
			using (var myDB = new PE_PRN_Fall2023B1Context())
			{
				directors = myDB.Directors.ToList();
				movies = myDB.Movies
					.Include(m => m.Genres)
					.Include(m => m.Director)
					.Where(m => m.DirectorId == directorId)
					.ToList();
			}
			return Page();
		}

		public IActionResult OnGetDelete(int movieId)
		{
			using (var myDB = new PE_PRN_Fall2023B1Context())
			{
				Movie movie = myDB.Movies
					.Include(m => m.Genres)
					.Include(m => m.MovieStars)
					.Include(m => m.Schedules)
					.FirstOrDefault(m => m.Id == movieId);
				directorId = movie.DirectorId;
				if (movie != null)
				{
					foreach(Genre genre in movie.Genres)
					{
						movie.Genres.Remove(genre);
					}
					foreach (MovieStar movieStar in movie.MovieStars)
					{
						movie.MovieStars.Remove(movieStar);
					}
					foreach(Schedule schedule in movie.Schedules)
					{
						myDB.Schedules.Remove(schedule);
					}
					myDB.Movies.Remove(movie);
					myDB.SaveChanges();

				}
			}
			return RedirectToPage(new { handler = "Filter", directorId });
		}
	}
}
