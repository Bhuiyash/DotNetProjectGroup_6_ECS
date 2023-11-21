using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Ecommerce_WebApi.Models;

namespace Ecommerce_WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        EcommerceDBContext db = new EcommerceDBContext();

        //Get
        public IEnumerable<Customer> Get()
        {
            return db.Customers.ToList();
        }

        //Get by ID
        public Customer Get(int id)
        {
            return db.Customers.FirstOrDefault(x => x.CustomerId == id);
        }

        //post or add
        public IHttpActionResult PostCustomer([FromBody] Customer c)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("validation Failed");
            }
            db.Customers.Add(new Customer()
            {
                 CustomerId= c.CustomerId,
                 FullName=c.FullName,
                 EmailAddress=c.EmailAddress,
                 Password=c.Password,
                 DeliveryAddress=c.DeliveryAddress,
                 PhoneNumber=c.PhoneNumber
            });

            db.SaveChanges();
            return Ok("Success"); // we can add instead od success any method name.
        }

        //put or edit
        public IHttpActionResult Put([FromBody] Customer c)
        {
            if (!ModelState.IsValid)
            {
                db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Ok("Modified");
        }

        //delete
        public IHttpActionResult Delete(int id)
        {
            Customer customer = db.Customers.Find(id);

            if(customer == null)
            {
                return NotFound();

            }

            db.Customers.Remove(customer);
            db.SaveChanges();
            return Ok("Deleted");
        }
       
   

    }

}
