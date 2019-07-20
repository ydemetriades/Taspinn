using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Taspin.Data.Models;

namespace Taspin.Data.Dac
{
    class DisposeListDac
    {
        private readonly string connstring;

        private const string selectDisposeListSP = "";

        public DisposeListDac(string conn)
        {
            connstring = conn;
        }

        public DisposeList SelectDisposeList(string userNameToSelect)
        {
            using (var db = new SqlConnection(connstring))
            {
                return db.Query(selectDisposeListSP, new { userName = userNameToSelect }, commandType: CommandType.StoredProcedure).First();
            }
        }
    }
}
