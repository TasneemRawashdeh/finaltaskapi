using learn.core.Data;
using learn.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FinalTaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class postlike_taskk : ControllerBase
    {
        private readonly IpostlikeService postlikeService;

        public postlike_taskk(IpostlikeService postlikeService)
        {
            this.postlikeService = postlikeService;
        }

        [HttpDelete("delete/{pkId}")]
        public bool Deletepostlike(int? pkId)
        {
            return postlikeService.Deletepostlike(pkId);
        }
        [HttpGet]
        public List<postlike_task> GetAllpostlike()
        {
            return postlikeService.GetAllpostlike();
        }

        [HttpPost]
        public postlike_task Insertpostlike(postlike_task postlike)
        {
            return postlikeService.Insertpostlike(postlike);
        }

        [HttpPut]
        public bool Updatepostlike(postlike_task postlike)
        {
            return postlikeService.Updatepostlike(postlike);
        }
    }
}
