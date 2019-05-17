using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIMake.Models
{
    public class ModelCustomer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string AlternateNumber { get; set; }
        public string ImagePath { get; set; }
    }
}