using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIMake.Models
{
    public class OrderItemModel
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ItemId { get; set; }

         public string ItemName { get; set; }

        public int ItemQuantity { get; set; }

        public int ItemPrice { get; set; }

        public int ItemTotal { get; set; }
    }
}

   