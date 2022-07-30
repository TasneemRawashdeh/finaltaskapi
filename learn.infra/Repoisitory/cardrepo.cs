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
    public class cardrepo : Icard
    {
        private readonly IDBContext dBContext;

        public cardrepo(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public bool Deletecard(int? caId)
        {
            var parameter = new DynamicParameters();

            parameter.Add
                ("@caId", caId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("API_Card_Package.Deletecard", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;

        }

        public List<card_task> GetAllcard()
        {
            IEnumerable<card_task> result = dBContext.dbConnection.Query<card_task>
                 ("API_Card_Package.GetAllcard", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public card_task Insertcard(card_task card)
        {
            var parameter = new DynamicParameters();
            
            parameter.Add
                ("UserIdd", card.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("cardNoo", card.cardNo, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("caedEndDatee", card.caedEndDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add
               ("CardTypee", card.CardType, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = dBContext.dbConnection.ExecuteAsync
                ("API_Card_Package.Insertcard", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return null;
            return card;
        }

        public bool Updatecard(card_task card)
        {
            var parameter = new DynamicParameters();
            parameter.Add
               ("@caId", card.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("UserIdd", card.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("cardNoo", card.cardNo, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("caedEndDatee", card.caedEndDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add
               ("CardTypee", card.CardType, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = dBContext.dbConnection.ExecuteAsync
                ("API_Card_Package.Updatecard", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return false;
            return true;
        }
    }
}
