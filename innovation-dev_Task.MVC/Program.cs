using innovation_dev_Task.Infrastructure.Context;
using innovation_dev_Task.MVC;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add DbContext to the container
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("innovation-dev_Task")));

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.Configure();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllerRoute(
            name: "default",
           pattern: "{controller=Student}/{action=Index}/{id?}");

        app.Run();
    }
}
