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
            [DataMember(Name = "outName")]
            public string Name { get; set; }

            [DataMember(Name = "outBarcode")]
            public string BarCode { get; set; }

            [DataMember(Name = "outObjid")]
            public int DisposeListToItemId { get; set; }

            [DataMember(Name = "outCount")]
            public int Count { get; set; }
        }
    }
}
