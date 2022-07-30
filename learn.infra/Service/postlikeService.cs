using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
    public class postlikeService: IpostlikeService
    {
        private readonly Ilikepost postlike_taskrepo;
        public postlikeService(Ilikepost postlike_taskrepo)
        {
            this.postlike_taskrepo = postlike_taskrepo;
        }

        public bool Deletepostlike(int? pkId)
        {
            return postlike_taskrepo.Deletepostlike(pkId);
        }

        public List<postlike_task> GetAllpostlike()
        {
            return postlike_taskrepo.GetAllpostlike();
        }

        public postlike_task Insertpostlike(postlike_task postlike)
        {
            return postlike_taskrepo.Insertpostlike(postlike);
        }

        public bool Updatepostlike(postlike_task postlike)
        {
            return postlike_taskrepo.Updatepostlike(postlike);
        }
    }
}
