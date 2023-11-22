
using System;

using System.Collections.Generic;

using System.Linq;

using System.Net;

using System.Net.Http;

using System.Web.Http;

using Ecommerce_WebApi.Models;
 
 
namespace Ecommerce_WebApi.Controllers

{

    [RoutePrefix("api/ShoppingCart")]

    public class ShoppingCartController : ApiController

    {

        EcommerceDBContext db = new EcommerceDBContext();

        //Get

        [HttpGet]

        [Route("ShoppingCartList")]

        public IEnumerable<ShoppingCart> Get()

        {

            return db.ShoppingCarts.ToList();

        }

        //Get by ID

        [HttpGet]

        [Route("ShoppingCartListByID")]

        public ShoppingCart Get(int id)

        {

            return db.ShoppingCarts.FirstOrDefault(x => x.CartId == id);

        }

        //post or add

        [HttpPost]

        [Route("AddShoppingCart")]

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

        [HttpPut]

        [Route("EditShoppingCart")]

        public IHttpActionResult Put([FromBody] ShoppingCart sp)

        {

            if (!ModelState.IsValid)

            {

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

            {

                return NotFound();

            }

            db.ShoppingCarts.Remove(shoppingcart);

            db.SaveChanges();

            return Ok("Deleted");

        }

    }

}
