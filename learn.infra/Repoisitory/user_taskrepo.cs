using Dapper;
using learn.core.Data;
using learn.core.domain;
using learn.core.DTO;
using learn.core.Repoisitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repoisitory
{
    public class user_taskrepo : Iuser
    {
        private readonly IDBContext dBContext;

        public user_taskrepo(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public List<user_task> GetAlluser()
        {
            IEnumerable<user_task> result = dBContext.dbConnection.Query<user_task>
                 ("user_task_Package.GetAlluser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<usermassagecountdto> totaleachuser()
        {
            IEnumerable<usermassagecountdto> result = dBContext.dbConnection.Query<usermassagecountdto>
                            ("user_task_Package.totaleachuser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<CCU> CountCantryUser()
        {
            IEnumerable<CCU> result = dBContext.dbConnection.Query<CCU>
                ("user_task_Package.CountCantryUser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<countuservisacs> visaeachuser()
        {
            IEnumerable<countuservisacs> result = dBContext.dbConnection.Query<countuservisacs>
                ("user_task_Package.visaeachuser", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }
    }
}
