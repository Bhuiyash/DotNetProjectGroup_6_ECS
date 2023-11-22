
using System;

using System.Collections.Generic;

using System.Linq;

using System.Net;

using System.Net.Http;

using System.Web.Http;

using Ecommerce_WebApi.Models;
 
namespace Ecommerce_WebApi.Controllers

{

    [RoutePrefix("api/OrderDetails")]

    public class OrderDetailController : ApiController

    {

        EcommerceDBContext db = new EcommerceDBContext();

        //Get

        [HttpGet]

        [Route("OrderDetailsList")]

        public IEnumerable<OrderDetail> Get()

        {

            return db.OrderDetails.ToList();

        }

        //Get by ID

        [HttpGet]

        [Route("OrderListByID")]

        public OrderDetail Get(int id)

        {

            return db.OrderDetails.FirstOrDefault(x => x.OrderDetailsID == id);

        }

        //post or add

        [HttpPost]

        [Route("AddOrderDetails")]

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

                ProductId = od.ProductId,

                Quantity = od.Quantity,

                UnitCost = od.UnitCost,

            });

            db.SaveChanges();

            return Ok("Success"); // we can add instead od success any method name.

        }

        //put or edit

        [HttpPut]

        [Route("EditOrderDetails")]

        public IHttpActionResult Put([FromBody] OrderDetail od)

        {

            if (!ModelState.IsValid)

            {

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

            {

                return NotFound();

            }

            db.OrderDetails.Remove(orderdetail);

            db.SaveChanges();

            return Ok("Deleted");

        }

    }

}
