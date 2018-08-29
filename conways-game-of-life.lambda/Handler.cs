using System;
using System.Collections.Generic;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using conways_game_of_life.core;
using conways_game_of_life.lamda.Models;
using conways_game_of_life.lib;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

[assembly : LambdaSerializer (typeof (Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace conways_game_of_life.lamda {
  public class Handler {
    private IServiceProvider _serviceProvider;
    private readonly Dictionary<string, string> _headers;

    public Handler () {
      _serviceProvider = new ServiceCollection ()
        .AddTransient<ICGolGame, Game> ()
        .AddTransient<ICGolGameCreator, GameCreator> ()
        .AddTransient<ITicker, Ticker> ()
        .AddTransient<ILivingNeighborCalculator, LivingNeighborCalculator> ()
        .BuildServiceProvider ();

      _headers = new Dictionary<string, string> { { "Content-Type", "application/json" },
        { "Access-Control-Allow-Origin", "*" },
        { "Access-Control-Allow-Credentials", "true" }
      };

    }

    public APIGatewayProxyResponse GetBoardGenerators (APIGatewayProxyRequest request, ILambdaContext context) {
      var result = new List<Generator> ();
      result.Add (new Generator () { id = 0, name = "Random" });
      result.Add (new Generator () { id = 1, name = "Blank" });
      result.Add (new Generator () { id = 2, name = "Symmetric" });
      result.Add (new Generator () { id = 3, name = "Checkerboard" });
      result.Add (new Generator () { id = 4, name = "Gosper's Gliding Gun" });

      var response = new APIGatewayProxyResponse {
        StatusCode = 200,
        Body = JsonConvert.SerializeObject (result),
        Headers = _headers
      };

      return response;
    }

    public APIGatewayProxyResponse CreateNewGame (APIGatewayProxyRequest request, ILambdaContext context) {
      NewGame gameParams = JsonConvert.DeserializeObject<NewGame> (request.Body);

      var creator = _serviceProvider.GetService<ICGolGameCreator> ();
      creator.Height = gameParams.height;
      creator.Width = gameParams.width;
      creator.FillFactor = gameParams.fillFactor;
      creator.Generator = gameParams.generator;
      
      var game = creator.Execute ();

      var response = new APIGatewayProxyResponse {
        StatusCode = 201,
        Body = JsonConvert.SerializeObject (new GameModel (game)),
        Headers = _headers
      };

      return response;
    }

    public APIGatewayProxyResponse TickAGame (APIGatewayProxyRequest request, ILambdaContext context) {
      GameModel game = JsonConvert.DeserializeObject<GameModel> (request.Body);
      var ticker = _serviceProvider.GetService<ITicker> ();
      
      ICGolGame domainGame = new Game(ticker);
      domainGame = game.ApplyTo(domainGame);
      domainGame.Tick();

      var response = new APIGatewayProxyResponse {
        StatusCode = 200,
        Body = JsonConvert.SerializeObject (new GameModel (domainGame)),
        Headers = _headers
      };

      return response;
    }
  }
}