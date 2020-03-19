using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataLayer.Extensions {
    public static class AppContextService {
        public static IServiceCollection AddAppContext(this IServiceCollection services, string connectionString) {
            services.AddDbContext<AppContext>(options => {
                options.UseSqlServer(connectionString);
            });
            
            return services;
        }
    }
}