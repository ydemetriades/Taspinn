using System;

namespace Taspin.Data
{
    public class DatabaseOptions
    {
        public readonly string ConnectionString;

        public DatabaseOptions(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
