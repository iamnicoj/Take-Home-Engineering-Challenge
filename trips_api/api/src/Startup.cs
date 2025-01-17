using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.ApplicationInsights.Extensibility;
using TripsAPI.Repositories;
using TripsAPI.Services;
using TripsAPI.ActionFilters;
using TripsAPI.Telemetry;

namespace TripsAPI
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
            // Register custom services
            services.AddScoped<ITripsService, TripsService>();
            services.AddScoped<ITripsCustomTelemetry, TripsCustomTelemetry>();
            services.AddScoped<BuildQueryActionFilter>();
            services.AddMvc(options => options.Filters.Add(new 
                ServiceExceptionInterceptor()));
            
            services.AddApplicationInsightsTelemetry();

            // services.Configure<TelemetryConfiguration>(
            //     (o) => {
            //     o.InstrumentationKey = "123";
            //     o.DisableTelemetry = true;
            //     o.TelemetryInitializers.Add(new OperationCorrelationTelemetryInitializer());
            //     });

            // This code adds other services for your application.
            services.AddMvc();

            services.AddDbContext<TripContext>(opt => 
                opt.UseSqlServer(Configuration.GetConnectionString("TripApiDB")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TripsAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TripsAPI v1"));
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
