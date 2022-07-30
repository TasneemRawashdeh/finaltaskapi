using learn.core.domain;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace learn.infra.domain
{
    public class DbContext: IDBContext
    {

        private DbConnection connection;
        private IConfiguration configuration;


        /*when execute project we will inialize value by constructor */
        public DbContext(IConfiguration configuration)
        {

            this.configuration = configuration;

        }

        public DbConnection dbConnection
        {
            get
            {
                if (connection == null)
                {

                    connection = new OracleConnection(configuration["ConnectionStrings:DBConnectionString"]);

                    connection.Open();
                }
                else if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                return connection;
            }
        }
    }
}
