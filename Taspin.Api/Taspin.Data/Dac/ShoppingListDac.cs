using Dapper;
using MySql.Data.MySqlClient;
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
        private const string selectShoppingListSP = "retrieveShoppingList";
        private const string deleteShoppingListItemSP = "deleteItemFromShoppingList";

        private readonly string connstring;

        public ShoppingListDac(DatabaseOptions databaseOptions)
        {
            connstring = databaseOptions.ConnectionString;
        }

        public List<ShoppingListItemModel> SelectShoppingList(string userNameToSelect)
        {
            using (var db = new MySqlConnection(connstring))
            {
                return db.Query<ShoppingListItemModel>(selectShoppingListSP, new { input_username = userNameToSelect }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void DeleteItem(int shoppingListToItemId)
        {
            using (var db = new MySqlConnection(connstring))
            {
                db.Query(deleteShoppingListItemSP, new { item_objid = shoppingListToItemId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
