using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ecommerce_WebApi.Models;

namespace Ecommerce_WebApi.Controllers
{
    public class OrderDetailController : ApiController
    {
        EcommerceDBContext db = new EcommerceDBContext();

        //Get
        public IEnumerable<OrderDetail> Get()
        {
            return db.OrderDetails.ToList();
        }

        //Get by ID
        public OrderDetail Get(int id)
        {
            return db.OrderDetails.FirstOrDefault(x => x.OrderDetailsID == id);

        }

        //post or add
        public IHttpActionResult PostOrderDetails([FromBody] OrderDetail od)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("validation Failed");
            }
            db.OrderDetails.Add(new OrderDetail()
            {
                OrderDetailsID= od.OrderDetailsID,
                OrderId = od.OrderId,
                ProductId = od.ProductId,
                Quantity = od.Quantity,
                UnitCost = od.UnitCost,
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
