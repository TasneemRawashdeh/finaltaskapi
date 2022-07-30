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
    public class country_taskrepo: Icountry
    {
        private readonly IDBContext dBContext;

        public country_taskrepo(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public bool Deletecountry(int? conId)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("@conId", conId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("country_task_Package.Deletecountry", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public List<country_task> GetAllcountry()
        {
            IEnumerable<country_task> result = dBContext.dbConnection.Query<country_task>
                  ("country_task_Package.GetAllcountry", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public country_task Insertcountry(country_task country)
        {
            var parameter = new DynamicParameters();

           
            parameter.Add
               ("NameCountryy", country.NameCountry, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("country_task_Package.Insertcountry", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return country;
        }

        public bool Updatecountry(country_task country)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("@conId", country.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            parameter.Add
               ("NameCountryy", country.NameCountry, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("country_task_Package.Updatecountry", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return false;
            return true;
        }
    
    }
}
