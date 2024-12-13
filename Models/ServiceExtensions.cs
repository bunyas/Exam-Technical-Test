using Microsoft.EntityFrameworkCore;
using exam.context;
using Exam.Data;
using Exam.Models;
using System.Configuration;

namespace Exam.Models
{
    public static class ServiceExtensions
    {
        public static void ConfigureExamContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<EXAMContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }

        public static void ConfigureApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }

        public static void ConfigureDataManagers(this IServiceCollection services)
        {
        }
    }
}
