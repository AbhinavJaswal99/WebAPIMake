using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIMake.Models;

namespace WebAPIMake.Controllers
{
    //[Authorize]
    public class ProductsController : ApiController
    {
        abhinav_testEntities2 db = new abhinav_testEntities2();


        [HttpGet]
        public IEnumerable<ModelCustomer> GetCustomers()
        {
            try
            {
                //return db.tblCustomers.ToList();

                //var lstCustomer = db.tblCustomers.Take(100).ToList();
                return  db.tblCustomers.Select(p => new ModelCustomer()
                {
                    CustomerId = p.CustomerId,
                    CustomerName = p.CustomerName,
                    Email = p.Email,
                    Phone = p.Email,
                    Address = p.Address,
                    AlternateNumber = p.AlternateNumber,
                    ImagePath = p.ImagePath
                }).ToList();
            
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet]
        public ModelCustomer GetCustomer(int id)
        {
            //var cust = db.tblCustomers.SingleOrDefault(x => x.CustomerId == id);

            var cust = db.tblCustomers.Select(p => new ModelCustomer()
            {
                CustomerId = p.CustomerId,
                CustomerName = p.CustomerName,
                Email = p.Email,
                Phone = p.Phone,
                Address = p.Address,
                AlternateNumber = p.AlternateNumber,
                ImagePath = p.ImagePath
            }).SingleOrDefault(z => z.CustomerId == id);

            if (cust == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return cust;
        }



        [HttpPost]
        public tblCustomer CreateCustomer(tblCustomer Customer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }

                db.tblCustomers.Add(Customer);
                db.SaveChanges();

                return Customer;
            } 
            catch (Exception ex)
            {
                throw ex;
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        public void UpdateCustomer(int id, tblCustomer Customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var cust = db.tblCustomers.SingleOrDefault(x => x.CustomerId == id);

            if (cust == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            cust.CustomerName = Customer.CustomerName;
            cust.Email = Customer.Email;
            cust.AlternateNumber = Customer.AlternateNumber;
            cust.Address = Customer.Address;
            cust.Phone = Customer.Phone;
            cust.ImagePath = Customer.ImagePath;

            db.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var cust = db.tblCustomers.SingleOrDefault(x => x.CustomerId == id);

            if (cust == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            db.tblCustomers.Remove(cust);
            db.SaveChanges();
        }
    }
}
