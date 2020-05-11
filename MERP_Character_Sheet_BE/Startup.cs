using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MERP_Character_Sheet_BE.Models;
using MERP_Character_Sheet_BE.Services;
using MERP_Character_Sheet_BE.Interfaces;
using MERP_Character_Sheet_BE.Repository;

namespace MERP_Character_Sheet_BE
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var database = Configuration["EntityFramework:DatabaseName"];

            services.AddTransient<ICharacterService, CharactersService>();
            services.AddSingleton<ICharacterRepository, CharacterRepository>();
            services.AddDbContext<CharacterContext>(opt => opt.UseInMemoryDatabase(database));

            services.AddTransient<IGameClassService, GameClassService>();
            services.AddSingleton<IGameClassRepository, GameClassRepository>();
            services.AddDbContext<GameClassContext>(opt => opt.UseInMemoryDatabase(database));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
