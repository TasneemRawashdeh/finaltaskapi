using learn.core.Data;
using learn.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalTaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly IAuthenticationservice authenticationservice;
        public AuthenController(IAuthenticationservice authenticationservice)
        {
            this.authenticationservice = authenticationservice;
        }

        [HttpPost]
        public IActionResult authen([FromBody] login_task login)
        {
            var RESULT = authenticationservice.Authentication_jwt(login);

            if (RESULT == null)
            {
                return Unauthorized(); //401
            }
            else
            {
                return Ok(RESULT); //200
            }


        }
    }
}
