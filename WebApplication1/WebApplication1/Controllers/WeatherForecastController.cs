using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using WebApplication1.Exceptions;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {

            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //[HttpPost()]
        //public JsonResult Save([FromBody] JToken fb)
        //{
        //    JsonDocument jd= JsonDocument.Parse(fb.ToString());


        //    return new JsonResult(new Result<object, object, object, object> { });
        //}

        //[HttpGet("demo")]
        //public IEnumerable<DateTime> Get2()
        //{
        //    yield return Convert.ToDateTime("2019-01-01T00:00:00");
        //}


        //[HttpGet("demo2")]
        //public IEnumerable<string> FindBobs()
        //{
        //    var names = new List<string>();
        //    names.Add("dddd");
        //    names.Add("Bob");
        //    foreach (var currName in names)
        //    {
        //        if (currName == "Bob")
        //            yield return currName;
        //    }
        //}


        //[HttpGet("exc")]
        //public JsonResult FindBobsJsonResult2()
        //{
        //    a();
        //    return null;
        //}

        //public void a()
        //{

        //    throw new BizException("测试异常");
        //}

        //[HttpGet("json")]
        //public JsonResult FindBobsJsonResult()
        //{
        //    return new JsonResult(new { Value = "sss" });
        //}

        //[HttpGet("json2")]
        //public JsonResult TestJson()
        //{

        //    string person = "[{\"name\":\"fanqi\",\"age\":25,\"userName\":\"333\",\"phone\":[\"10086\",\"10010\"]}]";
        //    List<Person> personList = JsonSerializer.Deserialize<List<Person>>(person, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        //    string json = JsonSerializer.Serialize(personList, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

        //    //JsonDocument document = JsonDocument.Parse(person);
        //    //Console.ReadKey();
        //    return new JsonResult(personList);
        //}
    }


    class Person
    {
        public string name { get; set; }
        public int? age { get; set; }
        public List<string> phone { get; set; }

        public string UserName { get; set; }
    }
}
