//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPIMake.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int ItemQuantity { get; set; }
        public int ItemPrice { get; set; }
        public int ItemTotal { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual Orderdb Orderdb { get; set; }
    }
}
