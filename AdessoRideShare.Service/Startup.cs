using AdessoRideShare.BL.Abstract;
using AdessoRideShare.BL.AutoMapper;
using AdessoRideShare.BL.Concrete;
using AdessoRideShare.BL.Extensions;
using AdessoRideShare.DataAccess;
using AdessoRideShare.Service.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Collections.Generic;
using System.Globalization;

namespace AdessoRideShare.Service
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
      services.AddLocalization(options => options.ResourcesPath = "Resources");

      services.Configure<RequestLocalizationOptions>(
        options =>
        {
          var supportedCultures = new List<CultureInfo> {
          new CultureInfo("tr-TR"),
          new CultureInfo("en-US")
          };

          options.DefaultRequestCulture = new RequestCulture(culture: "tr-TR", uiCulture: "tr-TR");
          options.SupportedCultures = supportedCultures;
          options.SupportedUICultures = supportedCultures;
          options.RequestCultureProviders = new[] { new Extensions.RouteDataRequestCultureProvider { IndexOfCulture = 1, IndexofUICulture = 1 } };
        });
      services.Configure<RouteOptions>(options =>
      {
        options.ConstraintMap.Add("culture", typeof(LanguageRouteConstraint));
      });
      //services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "AdessoRideShare.Service", Version = "v1" });
      });
      services.AddAutoMapper(typeof(MapperProfile));
      services.LoadMyServices();

      services.AddDbContext<Context>();

      services.AddScoped<ITravelPlanService, TravelPlanService>();
      services.AddScoped<IParticipantService, ParticipantService>();

      services.AddControllers();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdessoRideShare.Service v1"));
      }

      app.UseHttpsRedirection();

      var localizedOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
      app.UseRequestLocalization(localizedOptions.Value);

        //app.UseSerilogRequestLogging();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        endpoints.MapControllerRoute("default", "api/v1/{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
