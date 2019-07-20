using System;
using System.Collections.Generic;
using System.Text;
using Taspin.Data.Models;

namespace Taspin.Data.Dac
{
    public class ItemsDac
    {
        private readonly string connstring;

        public ItemsDac(DatabaseOptions databaseOptions)
        {
            connstring = databaseOptions.ConnectionString;
        }
    }
}
