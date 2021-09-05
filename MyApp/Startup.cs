using ElectronNET.API;
using VueCliMiddleware;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MyApp
{
    //public class Startup : ModularStartup
    //{

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            services.AddSpaStaticFiles(configuration =>
                configuration.RootPath = "ClientApp/dist");

            services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyApp", Version = "v1" }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyApp V1"));
            }

            
            app.UseRouting();
            app.UseAuthorization();
            app.UseStaticFiles();

            if (!env.IsDevelopment()) app.UseSpaStaticFiles();

            app.UseEndpoints(endpoints => endpoints.MapControllers());


            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp/";

                if (env.IsDevelopment()) spa.UseVueCli(npmScript: "serve");
              
            });


            Task.Run(async () => await Electron.WindowManager.CreateWindowAsync());
        }
    }
}
