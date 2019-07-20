using System;

namespace Taspinn.Models
{
    public class Item
    {
        public string Id { get; set; } //TODO: Int

        public string Name { get; set; }

        public string Description { get; set; }

        public string Barcode { get; set; }

        public int Count { get; set; }
    }
}
