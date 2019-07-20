using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Taspin.Data.Models
{
    public class DisposeList
    {
        public List<DisposeListItem> Items { get; set; }

        public class DisposeListItem
        {
            [DataMember(Name = "outName")]
            public string Name { get; set; }

            [DataMember(Name = "outBarcode")]
            public string BarCode { get; set; }

            [DataMember(Name = "outObjid")]
            public int DisposeListToItemId { get; set; }
        }
    }
}
