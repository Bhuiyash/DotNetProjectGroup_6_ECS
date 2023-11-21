using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ecommerce_WebApi.Models;

namespace Ecommerce_WebApi.Controllers
{
    public class OrderController : ApiController
    {
        EcommerceDBContext db = new EcommerceDBContext();

        //Get
        public IEnumerable<Order> Get()
        {
            return db.Orders.ToList();
        }

        //Get by ID
        public Order Get(int id)
        {
            return db.Orders.FirstOrDefault(x => x.OrderId == id);

        }

        //post or add
        public IHttpActionResult PostOrder([FromBody] Order o)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("validation Failed");
            }
            db.Orders.Add(new Order()
            {
              OrderId=o.OrderId,
              CustomerId=o.CustomerId,
              OrderDate=o.OrderDate,
              ShipDate = o.ShipDate,
            });

            db.SaveChanges();
            return Ok("Success"); // we can add instead od success any method name.
        }

        //put or edit
        public IHttpActionResult Put([FromBody] Order o)
        {
            if (!ModelState.IsValid)
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Ok("Modified");
        }

        //delete
        public IHttpActionResult Delete(int id)
        {
            Order order = db.Orders.Find(id);

            if (order == null)
            {
                return NotFound();
            }

            db.Orders.Remove(order);
            db.SaveChanges();
            return Ok("Deleted");
        }

    }
}
