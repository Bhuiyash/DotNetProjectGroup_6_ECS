using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Ecommerce_MVC.Models;
using Newtonsoft.Json;

namespace Ecommerce_MVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        //category list
        public ActionResult Category()
        {
            IEnumerable<Category> categorylist = null;
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44376/api/");
                var responsetask = webclient.GetAsync("Category");
                responsetask.Wait();
                var result = responsetask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultdata = result.Content.ReadAsStringAsync().Result;
                    categorylist = JsonConvert.DeserializeObject<List<Category>>(resultdata);
                }
                else
                {
                    categorylist = Enumerable.Empty<Category>();
                    ModelState.AddModelError(string.Empty, "Some Error Occured..Try Later");
                }
                return View(categorylist);
            }
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            using (HttpClient client = new HttpClient())
            {
                if (!ModelState.IsValid)
                {
                    return View(category);
                }
                client.BaseAddress = new Uri("https://localhost:44376/api");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("api/Category", category).Result;

                if (response.IsSuccessStatusCode)
                {
                    // Registration successful, you can redirect to a success page or login
                    ViewBag.result = "Category added successfull";
                    return RedirectToAction("~/Customer/Login");
                }
                else
                {
                    // Registration failed, handle errors
                    ModelState.AddModelError(string.Empty, "Not able to add category. Please try again.");
                    return View(category);
                }
            }
        }



    }
}