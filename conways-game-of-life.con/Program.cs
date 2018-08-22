using System;
using conways_game_of_life.core;
using conways_game_of_life.lib;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace conways_game_of_life.con
{
	class Program
	{
		static void Main(string[] args)
		{
			var serviceProvider = new ServiceCollection()
				.AddLogging()
        .AddTransient<ICGolGame, Game>()
				.AddTransient<ICGolGameCreator, GameCreator>()
				.AddTransient<ITicker, Ticker>()
				.AddTransient<ILivingNeighborCalculator, LivingNeighborCalculator>()
				.BuildServiceProvider();

			serviceProvider
				.GetService<ILoggerFactory>()
				.AddConsole(LogLevel.Debug);

			var logger = serviceProvider
				.GetService<ILoggerFactory>()
				.CreateLogger<Program>();

			logger.LogDebug("Starting Applicaiton");

			var creator = serviceProvider.GetService<ICGolGameCreator>();
			creator.Width = 10;
			creator.Height = 10;
			creator.FillFactor = .5;
			creator.Generator = BoardGenerator.Random;

			var game = creator.Execute();

			Console.WriteLine(game.ToString());

			Console.WriteLine("--------");
      

			for (int i = 0; i < 3; i++)
			{
				game.Tick();
				Console.WriteLine(game.ToString());
			}


			logger.LogDebug("All done!");
			Console.ReadLine();
		}
	}
}
