using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static int _counter = 0;

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _counter++;
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("stats")]
        public string CurrentStats()
        {
            return $"{Environment.MachineName} - {_counter}";
        }

        [HttpGet]
        [Route("fetch")]
        public async Task<string> RemoteJson()
        {
            var envRoute = Environment.GetEnvironmentVariable("NGINX");
             Console.WriteLine("envRoute" + envRoute);
            if (!string.IsNullOrEmpty(envRoute))
            {
                var http = new HttpClient();
                var request = await http.GetAsync(envRoute);
                Console.WriteLine("request" + request);
                return await request.Content.ReadAsStringAsync();
            }
            return "NGINX variable was not set up";
        }
    }
}
