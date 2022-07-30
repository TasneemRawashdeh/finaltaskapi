using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repoisitory
{
    public interface Ipost
    {
        public List<post_task> GetAllpost();
        public post_task Insertpost(post_task post);
        public bool Updatepost(post_task post);
        public bool Deletepost(int? plId);
       
    }
}
