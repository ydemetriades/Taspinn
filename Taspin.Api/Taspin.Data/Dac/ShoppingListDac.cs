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
    public class ShoppingListDac
    {

        private readonly string connstring;

        public ShoppingListDac(DatabaseOptions databaseOptions)
        {
            connstring = databaseOptions.ConnectionString;
        }

        public ShoppingList SelectShoppingList(string userNameToSelect)
        {
            return new ShoppingList(0, "shoppingListName");
            //using (var db = new SqlConnection(connstring))
            //{
            //    return db.Query(selectShoppingListSP, new { userName = userNameToSelect }, commandType: CommandType.StoredProcedure).First();
            //}
        }
    }
}
