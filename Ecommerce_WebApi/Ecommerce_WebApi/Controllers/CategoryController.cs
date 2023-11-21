using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ecommerce_WebApi.Models;

namespace Ecommerce_WebApi.Controllers
{
    public class CategoryController : ApiController
    {
        EcommerceDBContext db = new EcommerceDBContext();

        //Get
        public IEnumerable<Category> Get()
        {
            return db.Categories.ToList();
        }

        //Get by ID
        public Category Get(int id)
        {
            return db.Categories.FirstOrDefault(x => x.CategoryId == id);
        }

        //post or add
        public IHttpActionResult PostCategory([FromBody] Category cat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("validation Failed");
            }
            db.Categories.Add(new Category()
            {
              CategoryId = cat.CategoryId,
              CategoryName= cat.CategoryName,
              Description = cat.Description,

            });
            db.SaveChanges();
            return Ok("Success");
        }

        //put or edit
        public IHttpActionResult Put([FromBody] Category cat)
        {
            if (!ModelState.IsValid)
            {
                db.Entry(cat).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Ok("Modified");
        }
        public IHttpActionResult Delete(int id)
        {
            Category category = db.Categories.Find(id);

            if (category == null)
            {
                return NotFound();

            }

            db.Categories.Remove(category);
            db.SaveChanges();
            return Ok("Deleted");
        }
    }
}
