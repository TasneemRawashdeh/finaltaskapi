using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
    public class cardService : IcardService
    {
        private readonly Icard card_taskrepo;
        public cardService(Icard card_taskrepo)
        {
            this.card_taskrepo = card_taskrepo;
        }
        public bool Deletecard(int? caId)
        {
            return card_taskrepo.Deletecard(caId);
        }

        public List<card_task> GetAllcard()
        {
            return card_taskrepo.GetAllcard();
        }

        public card_task Insertcard(card_task card)
        {
            return card_taskrepo.Insertcard(card);
        }

        public bool Updatecard(card_task card)
        {
            return card_taskrepo.Updatecard(card);
        }
    }
}
