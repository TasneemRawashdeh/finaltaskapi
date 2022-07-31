using Dapper;
using learn.core.domain;
using learn.core.DTO;
using learn.core.Repoisitory;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repoisitory
{
    public class groupblock : Igroupblock
    {

        private readonly IDBContext dBContext;

        public groupblock(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public bool blockuser(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("uid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //select * from course_api where id=idofcourse;

            IEnumerable<userblockk> result = dBContext.dbConnection.Query<userblockk>("groupuser_task_Package.blockuser", parameter, commandType: CommandType.StoredProcedure);
            //course_api result1 = dbContext.dbConnection.QueryFirstOrDefault<course_api>("course_package_api.getbyid", parameter, commandType: CommandType.StoredProcedure);
            MimeMessage message = new MimeMessage();
            BodyBuilder builder = new BodyBuilder();
            MailboxAddress from = new MailboxAddress("User", "newqroma@gmail.com");
            MailboxAddress to = new MailboxAddress("user", result.FirstOrDefault().Email);
            builder.HtmlBody = "Hi " +  " You are blocked from " + result.FirstOrDefault().groupname + ". ";
            message.Body = builder.ToMessageBody();
            message.From.Add(from);
            message.To.Add(to);
            message.Subject = "Blocked group";
            using (var item = new MailKit.Net.Smtp.SmtpClient())
            {
                item.Connect("smtp.gmail.com", 587, false);
                item.Authenticate("newqroma@gmail.com", "cfodqutfkmzlouut");
                item.Send(message);
                item.Disconnect(true);

            }
            //return result;
            return true;
        }
    }
}
