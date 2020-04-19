using EducatioNow.Api.Data.Interfaces;
using EducatioNow.Api.Data.Repositories;
using EducatioNow.Api.Utils;
using EducatioNow.Infra.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EducatioNow.Api
{
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

            services.Configure<ConnectionStringOption>(connectionStringOptions =>
            {
                connectionStringOptions.OracleConnection = Configuration.GetConnectionString("OracleConnection");
            });

            services.AddTransient<IAlunoRepository, AlunoRepository>();
            services.AddTransient<ITurmaRepository, TurmaRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {   
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
