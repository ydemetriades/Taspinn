using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Taspin.Data.Models;
using Dapper;
using System.Linq;

namespace Taspin.Data.Dac
{
    public class UsersDac
    {
        private readonly string connstring;

        private const string selectUserSP = "retrieveUser";

        public UsersDac(DatabaseOptions databaseOptions)
        {
            connstring = databaseOptions.ConnectionString;
        }

        public User SelectUser(string userNameToSelect)
        {
            using (var db = new SqlConnection(connstring))
            {
                return db.Query(selectUserSP, new { input_username = userNameToSelect }, commandType: CommandType.StoredProcedure).First();
            }
        }

    }
}
