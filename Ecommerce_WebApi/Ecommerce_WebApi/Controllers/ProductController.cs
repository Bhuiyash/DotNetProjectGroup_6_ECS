using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ecommerce_WebApi.Models;

namespace Ecommerce_WebApi.Controllers
{
    public class ProductController : ApiController
    {
        EcommerceDBContext db = new EcommerceDBContext();
        //Get
        public IEnumerable<Product> Get()
        {
            return db.Products.ToList();
        }

        //Get by ID
        public Product Get(int id)
        {
            return db.Products.FirstOrDefault(x => x.ProductId == id);
        }

        //post or add
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
                ProductImage=p.ProductImage,
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
