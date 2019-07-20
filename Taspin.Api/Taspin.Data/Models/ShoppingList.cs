using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Taspin.Data.Models
{
    [DataContract]
    public class ShoppingList
    {
        public List<ShoppingListItem> Items { get; set; }

        public class ShoppingListItem
        {
            [DataMember(Name = "outName")]
            public string Name { get; set; }

            [DataMember(Name = "outBarcode")]
            public string BarCode { get; set; }

            [DataMember(Name = "outObjid")]
            public int ShoppingListToItemId { get; set; }
        }
    }
}
