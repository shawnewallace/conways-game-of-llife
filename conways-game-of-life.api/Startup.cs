using conways_game_of_life.core;
using conways_game_of_life.lib;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace conways_game_of_life.api
{
  public class Startup {
    public Startup (IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices (IServiceCollection services) {
      services.AddMvc ()
              .SetCompatibilityVersion (CompatibilityVersion.Version_2_1)
              .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
      services.AddCors();

      services.AddTransient<ICGolGame, Game>();
      services.AddTransient<ICGolGameCreator, GameCreator>();
      services.AddTransient<ITicker, Ticker>();
      services.AddTransient<ILivingNeighborCalculator, LivingNeighborCalculator>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
      if (env.IsDevelopment ()) {
        app.UseDeveloperExceptionPage ();
      } else {
        app.UseHsts ();
      }

      app.UseCors(builder => 
        builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
      );

      app.UseHttpsRedirection ();
      app.UseMvc ();
    }
  }
}