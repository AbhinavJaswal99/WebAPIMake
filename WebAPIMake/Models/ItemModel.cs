using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIMake.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public Nullable<int> ItemPrice { get; set; }
        public string ItemDescription { get; set; }
    }
}