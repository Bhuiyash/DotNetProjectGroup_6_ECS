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
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        EcommerceDBContext db = new EcommerceDBContext();

        ////Get
        //[HttpGet]
        //[Route("CustomerList")]
        public IEnumerable<Customer> Get()
        {
            return db.Customers.ToList();
        }

        //Get by ID
        //[HttpGet]
        //[Route("CustomerListByID")]
        public Customer Get(int id)
        {
            return db.Customers.FirstOrDefault(x => x.CustomerId == id);
        }

        //post or add
        //[HttpPost]
        //[Route("AddCustomer")]
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
        [HttpGet]
        [Route("Login")]
        public IHttpActionResult Login(string emailaddress, string password)
        {

            var Login = db.Customers.Where(x => (x.EmailAddress == emailaddress) && (x.Password == password)).Select(y => new { y.CustomerId, y.FullName }).SingleOrDefault();
            if (Login != null)
            {
                return Ok(Login);
            }
            else
            {
                return NotFound();
            }
        }

        //[HttpPost]
        //public IHttpActionResult Login([FromBody] Customer login)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest("Invalid login credentials");
        //    }
        //    // Authenticate the user based on email and password
        //    Customer customer = db.Customers.FirstOrDefault(x => x.EmailAddress == login.EmailAddress && x.Password == login.Password);
        //    if (customer != null)
        //    {
        //        // Login successful
        //        // You can generate a token or set a session variable to indicate the user is logged in
        //        return Ok("Login successful");
        //    }
        //    else
        //    {
        //        // Login failed
        //        return BadRequest("Invalid email address or password");
        //    }
        //}
        //public IHttpActionResult Put([FromBody] Order o)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        db.Entry(o).State = System.Data.Entity.EntityState.Modified;
        //        db.SaveChanges();
        //    }
        //    return Ok("Modified");
        //}

        //put or edit
        //[HttpPut]
        //[Route("EditCustomerByID")]
        public IHttpActionResult Put(int Id, [FromBody] Customer c)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid ModelState");
            }
            Customer customer = db.Customers.Find(Id);
            if (customer == null)
            {
                return NotFound();
            }
            // Update existingCustomer properties with values from updatedCustomer
            customer.FullName = c.FullName;
            customer.EmailAddress = customer.EmailAddress;
            customer.Password = c.Password;
            customer.DeliveryAddress = c.DeliveryAddress;
            customer.PhoneNumber = c.PhoneNumber;
            db.SaveChanges();
            return Ok("Updated");
        }

        //delete
        //[HttpDelete]
        //[Route("DeleteCustomerByID")]
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
