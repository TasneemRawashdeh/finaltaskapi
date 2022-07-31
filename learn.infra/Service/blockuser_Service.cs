using learn.core.Repoisitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
    public class blockuser_Service : Igroupblock_Service
    {
        private readonly Igroupblock groupblock;
        public blockuser_Service(Igroupblock groupblock)
        {
            this.groupblock = groupblock;
        }
        public bool blockuser(int id)
        {
            return groupblock.blockuser(id);
        }
    }
}
