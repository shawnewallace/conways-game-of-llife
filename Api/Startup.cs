using System;
using System.Collections.Generic;
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
using Microsoft.OpenApi.Models;
using Cgol.App;
using Cgol.Core;
using Cgol.Domain.Infrastructure;

namespace Api
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

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
			});

			services.AddLogging();

			services.AddLogging();
			services.AddTransient<IGame, Game>();
			services.AddTransient<IGameFactory, GameFactory>();
			services.AddTransient<ITicker, Ticker>();

			//https://hamidmosalla.com/2018/06/30/dependency-injection-conditional-resolving-of-multiple-implementation-of-interface/
			// services.AddTransient<Func<bool, ITicker>>(service);


			services.AddTransient<INeighborCalculator, NeighborCalculator>();

			//var logger = services
			//	.GetService<ILoggerFactory>()
			//	.CreateLogger<Startup>();

			//logger.LogDebug("Starting Applicaiton");
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
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
