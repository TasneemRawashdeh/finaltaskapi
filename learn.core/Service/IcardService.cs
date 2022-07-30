using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Service
{
    public interface IcardService
    {
        public List<card_task> GetAllcard();
        public card_task Insertcard(card_task card);
        public bool Updatecard(card_task card);
        public bool Deletecard(int? caId);
    }
}
