using learn.core.Data;
using learn.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FinalTaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class country_taskk : ControllerBase
    {
        private readonly IcountryService countryService;

        public country_taskk(IcountryService countryService)
        {
            this.countryService = countryService;
        }
        [HttpDelete("delete/{conId}")]
        public bool Deletecountry(int? conId)
        {
            return countryService.Deletecountry(conId);
        }

        [HttpGet]
        public List<country_task> GetAllcountry()
        {
            return countryService.GetAllcountry();
        }

        [HttpPost]
        public country_task Insertcountry(country_task country)
        {
            return countryService.Insertcountry(country);
        }

        [HttpPut]
        public bool Updatecountry(country_task country)
        {
            return countryService.Updatecountry(country);
        }
    }
}
