namespace Q2_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddRazorPages();

			var app = builder.Build();

			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.Use(async (context, next) =>
			{
				if (context.Request.Path == "/")
				{
					context.Response.Redirect("/Movies/Producer_Movie");
					return; 
				}
				await next();
			});

			app.UseRouting();

			app.MapRazorPages();

			app.Run();
		}
    }
}
