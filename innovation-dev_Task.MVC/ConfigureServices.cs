using innovation_dev_Task.Application.Interfaces;
using innovation_dev_Task.Application.Services;
using innovation_dev_Task.Infrastructure.Repositories;

namespace innovation_dev_Task.MVC
{
    public static class ConfigureServices
    {
        public static void Configure(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
