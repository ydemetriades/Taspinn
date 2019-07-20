using System;
namespace Taspin.Data.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string BarCode { get; set; }
        public string Name { get; set; }
        public string TypeId { get; set; }
    }
}
