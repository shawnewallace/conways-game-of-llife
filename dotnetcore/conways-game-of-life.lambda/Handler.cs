using System;
using System.Collections.Generic;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using AwsDotnetCsharp.Models;

[assembly : LambdaSerializer (typeof (Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AwsDotnetCsharp {
  public class Handler {
    public Response Hello (Request request) {
      return new Response ("Fairly Ready to Rock...", request);
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
        //Body = "{ \"Message\": \"Hello World\" }",
        Body = result,
        Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
      };

      return response;
    }
  }

  public class Response {
    public string Message { get; set; }
    public Request Request { get; set; }

    public Response (string message, Request request) {
      Message = message;
      Request = request;
    }
  }

  public class Request {
    public string Key1 { get; set; }
    public string Key2 { get; set; }
    public string Key3 { get; set; }

    public Request (string key1, string key2, string key3) {
      Key1 = key1;
      Key2 = key2;
      Key3 = key3;
    }
  }
}