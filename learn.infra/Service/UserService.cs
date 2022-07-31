using learn.core.Data;
using learn.core.DTO;
using learn.core.Repoisitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
    public class UserService : IUserService
    {

        private readonly Iuser user_taskrepo;
        public UserService(Iuser user_taskrepo)
        {
            this.user_taskrepo = user_taskrepo;
        }
        public List<user_task> GetAlluser()
        {
            return user_taskrepo.GetAlluser();
        }

        public List<usermassagecountdto> totaleachuser()
        {
            return user_taskrepo.totaleachuser();
        }
        public List<CCU> CountCantryUser()
        {
            return user_taskrepo.CountCantryUser();
        }
        public List<countuservisacs> visaeachuser()
        {
            return user_taskrepo.visaeachuser();
        }

        public bool Insertuser(user_task i)
        {
            return user_taskrepo.Insertuser(i);
        }
    }
}
