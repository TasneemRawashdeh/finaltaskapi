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
    public class massage_taskrepo : Imassage
    {
        private readonly IDBContext dBContext;

        public massage_taskrepo(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public int countOfmassage()
        {
            List<massage_task> c = GetAllmassage();

            return c.Count;
        }

        public List<massage_task> GetAllmassage()
        {
            IEnumerable<massage_task> result = dBContext.dbConnection.Query<massage_task>
                 ("massage_task_Package.GetAllmassage", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<massage_task> SearchButweenDate(filtermassagebutwwentwodatedto filter)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("chackinn", filter.DateMassage, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add
                ("chackoutt", filter.DateMassage, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            IEnumerable<massage_task> result = dBContext.dbConnection.Query<massage_task>
                           ("massage_task_Package.SearchButweenDate", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<massage_task> FilterMassage(filtermassagess c)
        {
            var parameter = new DynamicParameters();
            parameter.Add
             ("@Massage", c.Massage, dbType: DbType.String, direction: ParameterDirection.Input);
      
            IEnumerable<massage_task> result = dBContext.dbConnection.Query<massage_task>
                           ("massage_task_Package.FilterMassage", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();



        }
        public massage_task Insertmassage(massage_task mass)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("UserIdd", mass.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("massageuser", mass.massage, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("datemassagee", mass.datemassage, dbType: DbType.DateTime, direction: ParameterDirection.Input);
           
            var result = dBContext.dbConnection.ExecuteAsync
                ("massage_task_Package.Insertmassage", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return mass;
        }

        public List<massage_task> InsertMASSAGEList(massage_task[] massageins)
        {
           
                for (int i = 0; i < massageins.Length; i++)
                {
                Insertmassage(massageins[i]);
                }

                return massageins.ToList();
            

        }

        public pymentdto GGGG(pymentdto py)
        {

            var parameter = new DynamicParameters();

            parameter.Add
                ("service_idd",py.service_idd, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("useridd", py.useridd, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("quntity", py.quntity, dbType: DbType.Int32, direction: ParameterDirection.Input);

            parameter.Add
                ("datesales", py.datesales, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            var result = dBContext.dbConnection.ExecuteAsync
                ("puyment.GGGG", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return py;

        }

    }
}
