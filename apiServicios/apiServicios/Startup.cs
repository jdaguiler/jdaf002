using WebApplication3.Business.Clases;
using WebApplication3.Business.Contracts;
using WebApplication3.Services.Clases;
using WebApplication3.Services.Contracts;

namespace WebApplication3
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
            services.AddResponseCaching();
            services.AddTransient<IRolService, RolService>();
            services.AddTransient<IRolRepository, RolRepository>();

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
        public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
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
