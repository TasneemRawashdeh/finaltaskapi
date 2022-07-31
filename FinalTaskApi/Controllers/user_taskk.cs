using learn.core.Data;
using learn.core.DTO;
using learn.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Net;
using learn.core.WeatherForecase;
using static learn.core.WeatherForecase.Class1;

namespace FinalTaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class user_taskk : ControllerBase
    {
        private readonly IUserService UserService;
        

        public user_taskk(IUserService UserService)
        {
            this.UserService = UserService;
        }
        [HttpGet]
        public List<user_task> GetAlluser()
        {
            return UserService.GetAlluser();
        }
        //Q3

        [HttpGet]
        [Route("GETcountofmassageeachuser")]
        public List<usermassagecountdto> totaleachuser()
        {
            return UserService.totaleachuser();
        }


        [HttpGet]
        [Route("CountCantryUser")]
        public List<CCU> CountCantryUser()
        {
            return UserService.CountCantryUser();
        }
        [HttpGet]
        [Route("getcountvisauser")]
        public List<countuservisacs> visaeachuser()
        {
            return UserService.visaeachuser();
        }

        [HttpPost("with/{City}")]
        public String WeatherDetail(string City)
        {

            //Assign API KEY which received from OPENWEATHERMAP.ORG  
            string appId = "19241589958ba572cf9006b2657b6526";

            //API path with CITY parameter and other parameters.  
            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&cnt=1&APPID={1}", City, appId);

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                //********//  
                //     JSON RECIVED   
                //********//  
                //{"coord":{ "lon":72.85,"lat":19.01},  
                //"weather":[{"id":711,"main":"Smoke","description":"smoke","icon":"50d"}],  
                //"base":"stations",  
                //"main":{"temp":31.75,"feels_like":31.51,"temp_min":31,"temp_max":32.22,"pressure":1014,"humidity":43},  
                //"visibility":2500,  
                //"wind":{"speed":4.1,"deg":140},  
                //"clouds":{"all":0},  
                //"dt":1578730750,  
                //"sys":{"type":1,"id":9052,"country":"IN","sunrise":1578707041,"sunset":1578746875},  
                //"timezone":19800,  
                //"id":1275339,  
                //"name":"Mumbai",  
                //"cod":200}  

                //Converting to OBJECT from JSON string.  
                RootObject weatherInfo = (new JavaScriptSerializer()).Deserialize<RootObject>(json);

                //Special VIEWMODEL design to send only required fields not all fields which received from   
                //www.openweathermap.org api  
                ResultViewModel rslt = new ResultViewModel();

                rslt.Country = weatherInfo.sys.country;
                rslt.City = weatherInfo.name;
                rslt.Lat = Convert.ToString(weatherInfo.coord.lat);
                rslt.Lon = Convert.ToString(weatherInfo.coord.lon);
                rslt.Description = weatherInfo.weather[0].description;
                rslt.Humidity = Convert.ToString(weatherInfo.main.humidity);
                rslt.Temp = Convert.ToString(weatherInfo.main.temp);
                rslt.TempFeelsLike = Convert.ToString(weatherInfo.main.feels_like);
                rslt.TempMax = Convert.ToString(weatherInfo.main.temp_max);
                rslt.TempMin = Convert.ToString(weatherInfo.main.temp_min);
                rslt.WeatherIcon = weatherInfo.weather[0].icon;

                //Converting OBJECT to JSON String   
                var jsonstring = new JavaScriptSerializer().Serialize(rslt);

                //Return JSON string.  
                return jsonstring;
            }
        }

        [HttpPost]
        public bool Insertuser([FromBody] user_task i)
        {
            return UserService.Insertuser(i);
        }
    }
}
