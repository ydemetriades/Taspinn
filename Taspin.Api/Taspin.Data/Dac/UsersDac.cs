using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Taspin.Data.Models;
using Dapper;
using System.Linq;
using MySql.Data.MySqlClient;

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

        public UserModel SelectUser(string userNameToSelect)
        {
            using (var db = new MySqlConnection(connstring))
            {
                return db.Query<UserModel>(selectUserSP, new { input_username = userNameToSelect }, commandType: CommandType.StoredProcedure).First();
            }
        }

        public List<UserModel> SelectUsers()
        {
            using (var db = new MySqlConnection(connstring))
            {                
                var users = db.Query<UserModel>(" select * from TastPinDatabase.users ").ToList();

                return users;
            }
        }
    }
}
