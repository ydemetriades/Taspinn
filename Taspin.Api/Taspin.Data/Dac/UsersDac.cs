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

        private const string selectUserSP = "";

        public UsersDac(string conn)
        {
            connstring = conn;
        }

        public User SelectUser(string userNameToSelect)
        {
            using (var db = new SqlConnection(connstring))
            {
                return db.Query(selectUserSP, new { userName = userNameToSelect }, commandType: CommandType.StoredProcedure).First();
            }
        }

    }
}
