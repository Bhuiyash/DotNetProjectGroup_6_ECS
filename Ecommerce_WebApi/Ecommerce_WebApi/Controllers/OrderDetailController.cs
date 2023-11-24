
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
    [RoutePrefix("api/OrderDetails")]
=======

    [RoutePrefix("api/OrderDetails")]

>>>>>>> origin/main
    public class OrderDetailController : ApiController

    {

        EcommerceDBContext db = new EcommerceDBContext();

        //Get
<<<<<<< HEAD
        [HttpGet]
        [Route("OrderDetailsList")]
=======

        [HttpGet]

        [Route("OrderDetailsList")]

>>>>>>> origin/main
        public IEnumerable<OrderDetail> Get()

        {

            return db.OrderDetails.ToList();

        }

        //Get by ID
<<<<<<< HEAD
        [HttpGet]
        [Route("OrderListByID")]
=======

        [HttpGet]

        [Route("OrderListByID")]

>>>>>>> origin/main
        public OrderDetail Get(int id)

        {

            return db.OrderDetails.FirstOrDefault(x => x.OrderDetailsID == id);

        }

        //post or add
<<<<<<< HEAD
        [HttpPost]
        [Route("AddOrderDetails")]
=======

        [HttpPost]

        [Route("AddOrderDetails")]

>>>>>>> origin/main
        public IHttpActionResult PostOrderDetails([FromBody] OrderDetail od)

        {

            if (!ModelState.IsValid)

            {

                return BadRequest("validation Failed");

            }

            db.OrderDetails.Add(new OrderDetail()

            {

                OrderDetailsID = od.OrderDetailsID,

                OrderId = od.OrderId,
<<<<<<< HEAD
                CustomerId=od.CustomerId,
=======

>>>>>>> origin/main
                ProductId = od.ProductId,

                Quantity = od.Quantity,

                UnitCost = od.UnitCost,

            });

            db.SaveChanges();

            return Ok("Success"); // we can add instead od success any method name.

        }

        //put or edit
<<<<<<< HEAD
        [HttpPut]
        [Route("EditOrderDetailsByID")]
        public IHttpActionResult Put(int Id, [FromBody] OrderDetail od)
=======

        [HttpPut]

        [Route("EditOrderDetails")]

        public IHttpActionResult Put([FromBody] OrderDetail od)

>>>>>>> origin/main
        {

            if (!ModelState.IsValid)

            {
<<<<<<< HEAD
                return BadRequest("Invalid ModelState");
            }
            OrderDetail orderdetails = db.OrderDetails.Find(Id);
            if (orderdetails == null)
            {
                return NotFound();
            }
            // Update existingCustomer properties with values from updatedCustomer
            orderdetails.OrderId = od.OrderId;
            orderdetails.CustomerId = od.CustomerId;
            orderdetails.ProductId = od.ProductId;
            orderdetails.Quantity =od.Quantity;
            orderdetails.UnitCost = od.UnitCost;
            db.SaveChanges();
            return Ok("Updated");
        }

        //delete
        [HttpDelete]
        [Route("DeleteOrderDetailsByID")]
        public IHttpActionResult Delete(int id)
        {
            OrderDetail orderdetail = db.OrderDetails.Find(id);

            if (orderdetail == null)
=======

                db.Entry(od).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

            }

            return Ok("Modified");

        }

        //delete

        [HttpDelete]

        [Route("DeleteOrderDetails")]

        public IHttpActionResult Delete(int id)

        {

            OrderDetail orderdetail = db.OrderDetails.Find(id);

            if (orderdetail == null)

>>>>>>> origin/main
            {

                return NotFound();

            }

            db.OrderDetails.Remove(orderdetail);
<<<<<<< HEAD
=======

>>>>>>> origin/main
            db.SaveChanges();

            return Ok("Deleted");

        }

    }

}
