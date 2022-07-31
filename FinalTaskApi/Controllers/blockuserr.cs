using learn.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalTaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class blockuserr : ControllerBase
    {
        private readonly Igroupblock_Service blockuser_Service;
        public blockuserr(Igroupblock_Service blockuser_Service)
        {
            this.blockuser_Service = blockuser_Service;
        }

        [HttpGet("block/{id}")]
        public bool blockuser(int id)
        {
            return blockuser_Service.blockuser(id);
        }
    }
}
