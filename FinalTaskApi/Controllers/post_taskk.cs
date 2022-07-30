using learn.core.Data;
using learn.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FinalTaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class post_taskk : ControllerBase
    {
        private readonly IpostService postService;

        public post_taskk(IpostService postService)
        {
            this.postService = postService;
        }

        [HttpDelete("delete/{plId}")]

        public bool Deletepost(int? plId)
        {
            return postService.Deletepost(plId);
        }

        [HttpGet]
        public List<post_task> GetAllpost()
        {
            return postService.GetAllpost();
        }

        [HttpPost]
        public post_task Insertpost(post_task post)
        {
            return postService.Insertpost(post);
        }

        [HttpPut]
        public bool Updatepost(post_task post)
        {
            return postService.Updatepost(post);
        }

    }
}
