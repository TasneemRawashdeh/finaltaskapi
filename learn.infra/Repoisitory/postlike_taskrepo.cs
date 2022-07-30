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
    public class postlike_taskrepo : Ilikepost
    {

        private readonly IDBContext dBContext;

        public postlike_taskrepo(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public bool Deletepostlike(int? pkId)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("@pkId", pkId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("postlike_task_Package.Deletepostlike", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public List<postlike_task> GetAllpostlike()
        {
            IEnumerable<postlike_task> result = dBContext.dbConnection.Query<postlike_task>
               ("postlike_task_Package.GetAllpostlike", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public postlike_task Insertpostlike(postlike_task postlike)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("postidd", postlike.postid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("useridd", postlike.userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
           

            var result = dBContext.dbConnection.ExecuteAsync
                ("postlike_task_Package.Insertpostlike", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return postlike;
        }

        public bool Updatepostlike(postlike_task postlike)
        {
            var parameter = new DynamicParameters();

            parameter.Add
               ("pkId", postlike.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("postidd", postlike.postid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("useridd", postlike.userid, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dBContext.dbConnection.ExecuteAsync
                ("postlike_task_Package.Updatepostlike", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return false;
            return true;
        }
    }
}
