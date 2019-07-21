using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Taspin.Data.Models;

namespace Taspin.Data.Dac
{
    public class DisposeListDac
    {
        private readonly string connstring;

        private const string addDisposeListItemSP = "insertItemIntoDisposedList";
        private const string selectDisposeListSP = "retrieveDisposedList";
        private const string deleteDisposeListItemSP = "deleteItemFromDisposedList";
        private const string moveDisposeListItemToShoppingListSP = "moveItemFromDisposedToShopping";
        private const string updateCountForItemsInDisposedListSP = "updateCountForItemsInDisposedList";

        public DisposeListDac(DatabaseOptions databaseOptions)
        {
            connstring = databaseOptions.ConnectionString;
        }

        public void AddItem(int barcode, string username)
        {
            using(var db = new MySqlConnection(connstring))
            {
                db.Query(addDisposeListItemSP, new { input_bar_code = barcode, input_username = username }, commandType: CommandType.StoredProcedure);
            }
        }

        public List<DisposeListItemModel> SelectDisposeList(string userNameToSelect)
        {
            using (var db = new MySqlConnection(connstring))
            {
                return db.Query<DisposeListItemModel>(selectDisposeListSP, new { input_username = userNameToSelect }, commandType: CommandType.StoredProcedure).ToList();
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

        public void UpdateCountForItemInDisposeList(int disposeListToItemId, int count)
        {
            using (var db = new MySqlConnection(connstring))
            {
                db.Query(updateCountForItemsInDisposedListSP, new { item_objid = disposeListToItemId, in_count = count }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
