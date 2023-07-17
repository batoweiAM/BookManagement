using BookManagement.DatabaseContext;
using BookManagement.Implementations;
using BookManagement.Services;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Extension
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationConext>(opts => opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IBookManagementRepository, BookManagementRepository>();
        }
    }
}
