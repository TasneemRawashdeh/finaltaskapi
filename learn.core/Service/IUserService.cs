using learn.core.Data;
using learn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Service
{
    public interface IUserService
    {
        public List<user_task> GetAlluser();
        public List<usermassagecountdto> totaleachuser();
        public List<CCU> CountCantryUser();
        public List<countuservisacs> visaeachuser();
        public bool Insertuser(user_task i);




    }
}
