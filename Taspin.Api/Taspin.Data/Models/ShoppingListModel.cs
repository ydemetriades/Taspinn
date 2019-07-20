using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Taspin.Data.Models
{
    [DataContract]
    public class ShoppingListModel
    {
        public List<ShoppingListItemModel> Items { get; set; }

        public class ShoppingListItemModel
        {
            [DataMember(Name = "name")]
            public string Name { get; set; }

            [DataMember(Name = "barcode")]
            public string BarCode { get; set; }

            [DataMember(Name = "objid")]
            public int ShoppingListToItemId { get; set; }

            [DataMember(Name = "count")]
            public int Count { get; set; }
        }
    }
}
