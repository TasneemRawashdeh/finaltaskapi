using learn.core.Data;
using learn.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FinalTaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class card_taskk : ControllerBase
    {
        private readonly IcardService cardService;

        public card_taskk(IcardService cardService)
        {
            this.cardService = cardService;
        }

        [HttpDelete("delete/{caId}")]
        public bool Deletecard(int? caId)
        {
            return cardService.Deletecard(caId);
        }
        [HttpGet]
        public List<card_task> GetAllcard()
        {
            return cardService.GetAllcard();
        }

        [HttpPost]
        public card_task Insertcard(card_task card)
        {
            return cardService.Insertcard(card);
        }

        [HttpPut]
        public bool Updatecard(card_task card)
        {
            return cardService.Updatecard(card);
        }
    }
}
