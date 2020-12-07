using System;

namespace Cgol.Api
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

		public class CreateGameModel
		{
			public int Width {get;set;}
			public int Height {get;set;}
			public double FillFactor {get;set;}
		}
}
