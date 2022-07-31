using learn.core.Data;
using learn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repoisitory
{
   public interface Iuser
    {

        public List<user_task> GetAlluser();
        public List<usermassagecountdto> totaleachuser();
        public List<CCU> CountCantryUser();
        public bool Insertuser(user_task i);

        public List<countuservisacs> visaeachuser();

    }
}
