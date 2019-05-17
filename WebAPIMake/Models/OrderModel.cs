using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIMake.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public int? OrderNo { get; set; }

        public int TotalQuantity { get; set; }

        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }

        public int TotalPrice { get; set; }

        public string CustomerName { get; set; }

        public ModelCustomer Customer { get; set;}

        public List<OrderItemModel> Orderitems { get; set; }
    }
}