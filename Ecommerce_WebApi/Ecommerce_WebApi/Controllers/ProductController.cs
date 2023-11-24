
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
    [RoutePrefix("api/Product")]
=======

    [RoutePrefix("api/Product")]

>>>>>>> origin/main
    public class ProductController : ApiController

    {

        EcommerceDBContext db = new EcommerceDBContext();

        //Get
<<<<<<< HEAD
        [HttpGet]
        [Route("ProductList")]
=======

        [HttpGet]

        [Route("ProductList")]

>>>>>>> origin/main
        public IEnumerable<Product> Get()

        {

            return db.Products.ToList();

        }

        //Get by ID
<<<<<<< HEAD
        [HttpGet]
        [Route("ProductListByID")]
=======

        [HttpGet]

        [Route("ProductListByID")]

>>>>>>> origin/main
        public Product Get(int id)

        {

            return db.Products.FirstOrDefault(x => x.ProductId == id);

        }

        //post or add
<<<<<<< HEAD
        [HttpPost]
        [Route("AddProduct")]
=======

        [HttpPost]

        [Route("AddProduct")]

>>>>>>> origin/main
        public IHttpActionResult PostProduct([FromBody] Product p)

        {

            if (!ModelState.IsValid)

            {

                return BadRequest("validation Failed");

            }

            db.Products.Add(new Product()

            {

                ProductId = p.ProductId,

                CategoryId = p.CategoryId,

                ModelNumber = p.ModelNumber,

                ModelName = p.ModelName,

                UnitCost = p.UnitCost,

                Description = p.Description,

                ProductImage = p.ProductImage,

            });

            db.SaveChanges();

            return Ok("Success"); // we can add instead od success any method name.

        }

        //put or edit
<<<<<<< HEAD
        [HttpPut]
        [Route("EditProductByID")]
        public IHttpActionResult Put(int Id, [FromBody] Product p)
=======

        [HttpPut]

        [Route("EditProduct")]

        public IHttpActionResult Put([FromBody] Product p)

>>>>>>> origin/main
        {

            if (!ModelState.IsValid)

            {
<<<<<<< HEAD
                return BadRequest("Invalid ModelState");
            }
            Product product = db.Products.Find(Id);
            if (product == null)
            {
                return NotFound();
            }
            // Update existingCustomer properties with values from updatedCustomer
            product.CategoryId = p.CategoryId;
            product.ModelNumber = p.ModelNumber;
            product.ModelName = p.ModelName;
            product.UnitCost = p.UnitCost;
            product.Description=p.Description;
            product.ProductImage = p.ProductImage;
            db.SaveChanges();
            return Ok("Updated");
        }

        //delete
        [HttpDelete]
        [Route("DeleteProductByID")]
=======

                db.Entry(p).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

            }

            return Ok("Modified");

        }

        //delete

        [HttpDelete]

        [Route("DeleteProduct")]

>>>>>>> origin/main
        public IHttpActionResult Delete(int id)

        {

            Product product = db.Products.Find(id);

            if (product == null)

            {

                return NotFound();

            }

            db.Products.Remove(product);

            db.SaveChanges();

            return Ok("Deleted");

        }

    }

}
