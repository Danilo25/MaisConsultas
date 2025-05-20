using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MAISCONSULTAS.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Adiciona os serviços da API
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Habilita CORS para acesso via frontend
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod());
            });
        }

        // Configura o pipeline HTTP
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors("AllowAll");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}