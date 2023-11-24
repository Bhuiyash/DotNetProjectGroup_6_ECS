
using System;

using System.Collections.Generic;

using System.Linq;

using System.Net;

using System.Net.Http;

using System.Web.Http;

using Ecommerce_WebApi.Models;
 
 
namespace Ecommerce_WebApi.Controllers

{
<<<<<<< HEAD
    [RoutePrefix("api/ShoppingCart")]
=======

    [RoutePrefix("api/ShoppingCart")]

>>>>>>> origin/main
    public class ShoppingCartController : ApiController

    {

        EcommerceDBContext db = new EcommerceDBContext();

        //Get
<<<<<<< HEAD
        [HttpGet]
        [Route("ShoppingCartList")]
=======

        [HttpGet]

        [Route("ShoppingCartList")]

>>>>>>> origin/main
        public IEnumerable<ShoppingCart> Get()

        {

            return db.ShoppingCarts.ToList();

        }

        //Get by ID
<<<<<<< HEAD
        [HttpGet]
        [Route("ShoppingCartListByID")]
=======

        [HttpGet]

        [Route("ShoppingCartListByID")]

>>>>>>> origin/main
        public ShoppingCart Get(int id)

        {

            return db.ShoppingCarts.FirstOrDefault(x => x.CartId == id);

        }

        //post or add
<<<<<<< HEAD
        [HttpPost]
        [Route("AddShoppingCart")]
=======

        [HttpPost]

        [Route("AddShoppingCart")]

>>>>>>> origin/main
        public IHttpActionResult PostShoppingcart([FromBody] ShoppingCart sp)

        {

            if (!ModelState.IsValid)

            {

                return BadRequest("validation Failed");

            }

            db.ShoppingCarts.Add(new ShoppingCart()

            {

                CartId = sp.CartId,

                CustomerID = sp.CustomerID,

                Quantity = sp.Quantity,

                ProductId = sp.ProductId,

                DateCreated = sp.DateCreated,

            });

            db.SaveChanges();

            return Ok("Success"); // we can add instead od success any method name.

        }

        //put or edit
<<<<<<< HEAD
        [HttpPut]
        [Route("EditShoppingCartByID")]
        public IHttpActionResult Put(int Id, [FromBody] ShoppingCart sc)
=======

        [HttpPut]

        [Route("EditShoppingCart")]

        public IHttpActionResult Put([FromBody] ShoppingCart sp)

>>>>>>> origin/main
        {

            if (!ModelState.IsValid)

            {
<<<<<<< HEAD
                return BadRequest("Invalid ModelState");
            }
            ShoppingCart shoppingCart = db.ShoppingCarts.Find(Id);
            if (shoppingCart == null)
            {
                return NotFound();
            }
            // Update existingCustomer properties with values from updatedCustomer
            shoppingCart.CustomerID = sc.CustomerID;
            shoppingCart.Quantity = sc.Quantity;
            shoppingCart.ProductId=sc.ProductId;
            shoppingCart.DateCreated=sc.DateCreated;
           
            db.SaveChanges();
            return Ok("Updated");
        }

        //delete
        [HttpDelete]
        [Route("DeleteShoppingCartByID")]
        public IHttpActionResult Delete(int id)
        {
            ShoppingCart shoppingcart = db.ShoppingCarts.Find(id);

            if (shoppingcart == null)
=======

                db.Entry(sp).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

            }

            return Ok("Modified");

        }

        //delete

        [HttpDelete]

        [Route("DeleteShoppingCart")]

        public IHttpActionResult Delete(int id)

        {

            ShoppingCart shoppingcart = db.ShoppingCarts.Find(id);

            if (shoppingcart == null)

>>>>>>> origin/main
            {

                return NotFound();

            }

            db.ShoppingCarts.Remove(shoppingcart);
<<<<<<< HEAD
=======

>>>>>>> origin/main
            db.SaveChanges();

            return Ok("Deleted");

        }

    }

}
