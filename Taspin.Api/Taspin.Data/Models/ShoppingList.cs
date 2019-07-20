using System;
namespace Taspin.Data.Models
{
    public class ShoppingList
    {
        public ShoppingList(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int id { get; set; }
        public string name { get; set; }


    }
}
