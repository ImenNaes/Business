using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            IEnumerable<Product> Listproducts;
            HttpResponseMessage response = Helper.Helper.WebApiClient.GetAsync("Product").Result;
            Listproducts = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            return View(Listproducts);
        }

        public ActionResult Create()
        {          
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            var AddTask = Helper.Helper.WebApiClient.PostAsJsonAsync<Product>("Product", product);
            AddTask.Wait();
            var result = AddTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Edit(Guid id)
        {
            Product prod = null;
            var product = Helper.Helper.WebApiClient.GetAsync("Product/"+id.ToString());
            product.Wait();

            var result = product.Result;
            if (result.IsSuccessStatusCode)
            {
                var prdetoedit = result.Content.ReadAsAsync<Product>();
                prdetoedit.Wait();
                prod = prdetoedit.Result;
            }
            return View(prod);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            var editTask = Helper.Helper.WebApiClient.PutAsJsonAsync<Product>("Product/"+ product.ID, product);
            editTask.Wait();
            var result = editTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }


        public ActionResult Delete(Guid id)
        {
            var deletetask = Helper.Helper.WebApiClient.DeleteAsync("Product/" + id.ToString());
            
            var result = deletetask.Result;
            if (result.IsSuccessStatusCode)
            {   
                return RedirectToAction("Index");
            }
            return View("Delete"); 
        }
    }
}