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
            public string name { get; set; }

            public string barcode { get; set; }

            public int objid { get; set; }

            public int count { get; set; }
        }
    }
}
