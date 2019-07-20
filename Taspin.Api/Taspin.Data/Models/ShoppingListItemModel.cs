using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Taspin.Data.Models
{
    [DataContract]
    public class ShoppingListItemModel
    {
        public string name { get; set; }

        public string barcode { get; set; }

        public int objid { get; set; }

        public int count { get; set; }
    }
}
