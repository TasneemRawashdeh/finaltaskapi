using Dapper;
using learn.core.Data;
using learn.core.domain;
using learn.core.Repoisitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repoisitory
{
    public class Authentication : IAuthentication
    {
        private readonly IDBContext dBContext;
        public Authentication(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public login_task auth(login_task login)
        {
            var parameter = new DynamicParameters();
            parameter.Add("username1", login.username, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("password1", login.password, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<login_task> result = dBContext.dbConnection.Query<login_task>("loginapi_package.Auth", parameter, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
    }
}
