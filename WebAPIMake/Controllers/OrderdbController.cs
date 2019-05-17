using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIMake.Models;
using System.Data.Entity;

namespace WebAPIMake.Controllers
{
    public class OrderdbController : ApiController
    {
        abhinav_testEntities2 db = new abhinav_testEntities2();
        
        [HttpGet]
        public IEnumerable<OrderModel> GetOrderdbs()
        {

            var orderdb =  db.Orderdbs.Select(p => new OrderModel()
            {
                Id = p.Id,
                CustomerId = p.CustomerId,
                OrderNo = p.OrderNo,
                TotalQuantity = p.TotalQuantity,
                OrderDate = p.OrderDate,
                TotalPrice = p.TotalPrice,
                CustomerName = p.tblCustomer.CustomerName,
                Orderitems = p.OrderItems.Select(z => new OrderItemModel {
                    Id = z.Id,
                    OrderId = z.OrderId,
                    ItemId = z.ItemId,
                    ItemQuantity = z.ItemQuantity,
                    ItemPrice = z.ItemPrice,
                    ItemTotal = z.ItemTotal,
                    ItemName = z.Item.ItemName
                }).ToList()
            });

            return orderdb;
           //var hello = db.Orderdbs.Include("tblCustomer").ToList();
           // return hello;
        }

        [HttpGet]
        public OrderModel GetOrderdb(int id)
        {
          

            var getord = db.Orderdbs.Select(p => new OrderModel()
            {
                Id = p.Id,
                CustomerId = p.CustomerId,
                OrderNo = p.OrderNo,
                TotalQuantity = p.TotalQuantity,
                OrderDate = p.OrderDate,
                TotalPrice = p.TotalPrice,
                CustomerName = p.tblCustomer.CustomerName,
                Orderitems = p.OrderItems.Select(z => new OrderItemModel
                {
                    Id = z.Id,
                    OrderId = z.OrderId,
                    ItemId = z.ItemId,
                    ItemQuantity = z.ItemQuantity,
                    ItemPrice = z.ItemPrice,
                    ItemTotal = z.ItemTotal,
                    ItemName = z.Item.ItemName
                }).ToList()
            }).FirstOrDefault(z => z.Id == id);
            //var getord = db.Orderdbs.Include(x=>x.OrderItems)
            //    .FirstOrDefault(x => x.Id == id);

             //var cust = db.tblCustomers.SingleOrDefault(x => x.CustomerId == id);

            if (getord == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return getord;
        }

        [HttpPost]
        public Orderdb CreateOrderdb(Orderdb orderdb)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                db.Orderdbs.Add(orderdb);
                db.SaveChanges();

                return orderdb;
            }
        
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        public void UpdateOrderdb(int id, Orderdb orderdb)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var orders = db.Orderdbs.SingleOrDefault(x => x.Id == id);

            if(orders == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var newItem = orderdb.OrderItems.Where(x => x.Id == 0).ToList();
            foreach (var item in newItem)
            {
                orders.OrderItems.Add(item);
            }

            var updatedItem = orderdb.OrderItems.Where(x => x.OrderId == orderdb.Id).ToList();
            if (updatedItem != null)
            {
                foreach (var item in updatedItem)
                {
                   var existingitem =   orders.OrderItems.FirstOrDefault(x => x.ItemId == item.ItemId);
                    existingitem.ItemQuantity = item.ItemQuantity;
                    existingitem.ItemTotal = item.ItemTotal;
                }
            }

           


            //orders.OrderItems = orderdb.OrderItems;
            orderdb.OrderNo = orders.OrderNo;
            orders.TotalPrice = orderdb.TotalPrice;
            orders.TotalQuantity = orderdb.TotalQuantity;
            db.SaveChanges();
        }

        public void DeleteOrderdb(int id)
        {
            var orderss = db.Orderdbs.SingleOrDefault(x => x.Id == id);

            if(orderss == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            db.Orderdbs.Remove(orderss);
            db.SaveChanges();
        }


    }
}
