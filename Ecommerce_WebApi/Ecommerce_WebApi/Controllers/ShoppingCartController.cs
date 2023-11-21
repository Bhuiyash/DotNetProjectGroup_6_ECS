using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ecommerce_WebApi.Models;


namespace Ecommerce_WebApi.Controllers
{
    public class ShoppingCartController : ApiController
    {
        EcommerceDBContext db = new EcommerceDBContext();

        //Get
        public IEnumerable<ShoppingCart> Get()
        {
            return db.ShoppingCarts.ToList();
        }

        //Get by ID
        public ShoppingCart Get(int id)
        {
            return db.ShoppingCarts.FirstOrDefault(x => x.CartId == id);

        }

        //post or add
        public IHttpActionResult PostShoppingcart([FromBody] ShoppingCart sp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("validation Failed");
            }
            db.ShoppingCarts.Add(new ShoppingCart()
            {
              CartId = sp.CartId,
              CustomerID=sp.CustomerID,
              Quantity=sp.Quantity,
              ProductId=sp.ProductId,
              DateCreated=sp.DateCreated,
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
