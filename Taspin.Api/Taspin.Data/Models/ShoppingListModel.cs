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
            [DataMember(Name = "outName")]
            public string Name { get; set; }

            [DataMember(Name = "outBarcode")]
            public string BarCode { get; set; }

            [DataMember(Name = "outObjid")]
            public int ShoppingListToItemId { get; set; }

            [DataMember(Name = "outCount")]
            public int Count { get; set; }
        }
    }
}
