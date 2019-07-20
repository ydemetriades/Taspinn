using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Taspin.Data.Models
{
    public class DisposeListModel
    {
        public List<DisposeListItemModel> Items { get; set; }

        public class DisposeListItemModel
        {
            [DataMember(Name = "name")]
            public string Name { get; set; }

            [DataMember(Name = "barcode")]
            public string BarCode { get; set; }

            [DataMember(Name = "objid")]
            public int DisposeListToItemId { get; set; }

            [DataMember(Name = "count")]
            public int Count { get; set; }
        }
    }
}
