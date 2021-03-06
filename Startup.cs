using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using moonminer.Repositories;
using moonminer.Services;
using MySql.Data.MySqlClient;

namespace moonminer
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
      services.AddCors(options =>
      {
        options.AddPolicy("CorsDevPolicy", builder =>
              {
                builder
                          .WithOrigins(new string[]{
                            "http://localhost:8080"
                      })
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials();
              });
      });

      services.AddControllers();

      // Connect to Database
      services.AddScoped<IDbConnection>(x => CreateDbConnection());

      // NOTE Resgister Services and Repositories
      services.AddTransient<TestGamesService>();
      services.AddTransient<TestGamesRepository>();
      services.AddTransient<TestPlanetsService>();
      services.AddTransient<TestPlanetsRepository>();
    }
    private IDbConnection CreateDbConnection()
    {
      string connectionString = Configuration.GetSection("DB").GetValue<string>("gearhost");
      return new MySqlConnection(connectionString);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseCors("CorsDevPolicy");
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();
      app.UseDefaultFiles();
      app.UseStaticFiles();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
