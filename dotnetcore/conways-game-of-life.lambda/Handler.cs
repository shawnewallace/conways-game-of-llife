using System;
using System.Collections.Generic;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using AwsDotnetCsharp.Models;
using Newtonsoft.Json;

[assembly : LambdaSerializer (typeof (Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AwsDotnetCsharp {
  public class Handler {
    public APIGatewayProxyResponse GetBoardGenerators (APIGatewayProxyRequest request, ILambdaContext context) {
      var result = new List<Generator> ();
      result.Add (new Generator () { id = 0, name = "Random" });
      result.Add (new Generator () { id = 1, name = "Blank" });
      result.Add (new Generator () { id = 2, name = "Symmetric" });
      result.Add (new Generator () { id = 3, name = "Checkerboard" });
      result.Add (new Generator () { id = 4, name = "Gosper's Gliding Gun" });

      var response = new APIGatewayProxyResponse {
        StatusCode = 200,
        Body = JsonConvert.SerializeObject(result),
        Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
      };

      return response;
    }
  }

  public APIGatewayProxyResponse CreateNewGame (APIGatewayProxyRequest request, ILambdaContext context) {
    var response = 
  }
}