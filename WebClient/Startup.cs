using DataLayer.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebClient {
    public class Startup {

        private IConfiguration configuration;
        
        public Startup(IConfiguration configuration) {
            this.configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services) {
            services.AddAppContext(configuration.GetConnectionString("default"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapGet("/", async context => {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}