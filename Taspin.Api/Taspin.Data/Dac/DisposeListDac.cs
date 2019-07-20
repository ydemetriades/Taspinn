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
    public class DisposeListDac
    {
        private readonly string connstring;

        private const string selectDisposeListSP = "retrieveDisposedList";
        private const string deleteDisposeListItemSP = "deleteItemFromDisposedList";
        private const string moveDisposeListItemToShoppingListSP = "moveItemFromDisposedToShopping";

        public DisposeListDac(DatabaseOptions databaseOptions)
        {
            connstring = databaseOptions.ConnectionString;
        }

        public DisposeListModel SelectDisposeList(string userNameToSelect)
        {
            using (var db = new MySqlConnection(connstring))
            {
                return db.Query<DisposeListModel>(selectDisposeListSP, new { input_username = userNameToSelect }, commandType: CommandType.StoredProcedure).First();
            }
        }

        public void DeleteItem(int disposeListToItemId)
        {
            using (var db = new MySqlConnection(connstring))
            {
                db.Query(deleteDisposeListItemSP, new { item_objid = disposeListToItemId }, commandType: CommandType.StoredProcedure);
            }
        }

        public void MoveItemToShoppingList(int disposeListToItemId)
        {
            using (var db = new MySqlConnection(connstring))
            {
                db.Query(moveDisposeListItemToShoppingListSP, new { disposed_item_objid = disposeListToItemId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
