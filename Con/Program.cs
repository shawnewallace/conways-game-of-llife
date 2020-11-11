using System;
using System.Threading;
using Cgol.App;
using Cgol.Domain.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cgol.Con
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Clear();

			var serviceProvider = new ServiceCollection()
				.AddLogging()
				.AddTransient<IGame, Game>()
				.AddTransient<IGameFactory, GameFactory>()
				.AddTransient<ITicker, Ticker>()
				.AddTransient<INeighborCalculator, NeighborCalculator>()
				.BuildServiceProvider();

			var logger = serviceProvider
				.GetService<ILoggerFactory>()
				.CreateLogger<Program>();

			logger.LogDebug("Starting Applicaiton");

			var creator = serviceProvider.GetService<IGameFactory>();
			creator.Width = 3;
			creator.Height = 3;
			creator.FillFactor = .5;
			//creator.Generator = BoardGenerator.Random;

			var game = creator.Execute();

			Console.WriteLine(game.ToString());
			Pause(1);

			var lastBoard = game.Board;

			for (int i = 0; i < 10; i++)
			{
				game.Tick();
				lastBoard = game.Board;
				Console.Clear();
				Console.WriteLine(game.ToString());
				Pause(1);
			}

			logger.LogDebug("All done!");
			Console.WriteLine("All done!");
			// Console.ReadLine();
		}

		private static void Pause(int numSeconds = 3)
		{
			Thread.Sleep(numSeconds * 1000);
		}
	}
}
