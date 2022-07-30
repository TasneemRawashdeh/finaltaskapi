using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Service
{
    public interface IpostlikeService
    {

        public List<postlike_task> GetAllpostlike();
        public postlike_task Insertpostlike(postlike_task postlike);
        public bool Updatepostlike(postlike_task postlike);
        public bool Deletepostlike(int? pkId);
    }
}
