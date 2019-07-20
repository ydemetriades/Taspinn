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
    class ShoppingListDac
    {

        private readonly string connstring;

        private const string selectShoppingListSP = "";

        public ShoppingListDac(string conn)
        {
            connstring = conn;
        }

        public ShoppingList SelectShoppingList(string userNameToSelect)
        {
            using (var db = new SqlConnection(connstring))
            {
                return db.Query(selectShoppingListSP, new { userName = userNameToSelect }, commandType: CommandType.StoredProcedure).First();
            }
        }
    }
}
