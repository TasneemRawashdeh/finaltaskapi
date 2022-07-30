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
    public class post_taskrepo : Ipost
    {


        private readonly IDBContext dBContext;

        public post_taskrepo(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public bool Deletepost(int? plId)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("@plId", plId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("post_task_Package.Deletepost", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public List<post_task> GetAllpost()
        {
            IEnumerable<post_task> result = dBContext.dbConnection.Query<post_task>
               ("post_task_Package.GetAllpost", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public post_task Insertpost(post_task post)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("useriddd", post.userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("postt", post.post, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = dBContext.dbConnection.ExecuteAsync
                ("post_task_Package.Insertpost", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return post;
        }

        public bool Updatepost(post_task post)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("plId", post.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            parameter.Add
                ("useriddd", post.userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("postt", post.post, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = dBContext.dbConnection.ExecuteAsync
                ("post_task_Package.Updatepost", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return false;
            return true;
        }
    }
}
