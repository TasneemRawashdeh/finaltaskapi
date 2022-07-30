using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
    public class postService : IpostService
    {
        private readonly Ipost post_taskrepo;
        public postService(Ipost post_taskrepo)
        {
            this.post_taskrepo = post_taskrepo;
        }
        public bool Deletepost(int? plId)
        {
           return post_taskrepo.Deletepost(plId);
        }

        public List<post_task> GetAllpost()
        {
            return post_taskrepo.GetAllpost();
        }

        public post_task Insertpost(post_task post)
        {
            return post_taskrepo.Insertpost(post);
        }

        public bool Updatepost(post_task post)
        {
            return post_taskrepo.Updatepost(post);
        }
    }
}
