using learn.core.Data;
using learn.core.DTO;
using learn.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FinalTaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class massage_taskk : ControllerBase
    {
        private readonly IMassageService massageService;
        public massage_taskk(IMassageService massageService)
        {
            this.massageService = massageService;
        }

        //Q2

        [HttpGet]
        [Route("GETcounOfMassage")]
        public int countOfmassage()
        {
            return massageService.countOfmassage();
        }
        [HttpGet]
        public List<massage_task> GetAllmassage()
        {
            return massageService.GetAllmassage();
        }

        //q5

        [HttpPost]
        [Route("filturdate")]
        public List<massage_task> SearchButweenDate([FromBody] filtermassagebutwwentwodatedto filter)
        {
            return massageService.SearchButweenDate(filter);
        }

        //q4

        [HttpPost]
        [Route("filturmassage")]
        public List<massage_task> FilterMassage([FromBody] filtermassagess c)
        
        {
            return massageService.FilterMassage(c);
        }

        [HttpPost]
        public massage_task Insertmassage(massage_task mass)
        {
            return massageService.Insertmassage(mass);
        }

        [HttpPost]
        [Route("list")]
        public List<massage_task> InsertMASSAGEList(massage_task[] massageins)
        {
            return massageService.InsertMASSAGEList( massageins);
        }


        [HttpPost]
        [Route("paymentuser")]
        public pymentdto GGGG(pymentdto py)
        {
            return massageService.GGGG(py);
        }
        }
    }
