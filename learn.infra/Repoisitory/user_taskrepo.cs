using Dapper;
using learn.core.Data;
using learn.core.domain;
using learn.core.DTO;
using learn.core.Repoisitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        public bool Insertuser(user_task i)
        {
            Random random = new Random();
            StreamReader Filen = new StreamReader(@"C:\Users\HACKJO\Downloads\emp.txt");
            string[] email = { "@gmail.com", "@yahoo.com" };

            string line;
            do
            {
                line = Filen.ReadLine();
                string[] lines = line.Split(' ');
                int indexemail = random.Next(email.Length);

                // Console.WriteLine();
                var parameter = new DynamicParameters();

                parameter.Add("fullname", lines[0]+ lines[1], dbType: DbType.String, direction: ParameterDirection.Input);
                parameter.Add("emailuser", lines[0].ToLower() + lines[1].ToLower() + email[indexemail], dbType: DbType.String, direction: ParameterDirection.Input);




                var result = dBContext.dbConnection.ExecuteAsync("user_task_Package.Insertuser", parameter, commandType: CommandType.StoredProcedure);

            } while (!Filen.EndOfStream);
            Filen.Close();




            return true;
        }
    }
}
