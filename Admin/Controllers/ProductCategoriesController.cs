using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
 
namespace Admin.Controllers
{
    public class ProductCategoriesController : Controller
    {
        // GET: ProductCategories
        public ActionResult Index()
        {
            IEnumerable<ProductCategorie> ListproductsCat;
            HttpResponseMessage response = Helper.Helper.WebApiClient.GetAsync("ProductCategorie").Result;
            ListproductsCat = response.Content.ReadAsAsync<IEnumerable<ProductCategorie>>().Result;
            return View(ListproductsCat);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductCategorie productcategorie)
        {
            var AddTask = Helper.Helper.WebApiClient.PostAsJsonAsync<ProductCategorie>("ProductCategorie", productcategorie);
            AddTask.Wait();
            var result = AddTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(productcategorie);
        }

        public ActionResult Edit(Guid id)
        {
            ProductCategorie productcat= null;
            var product = Helper.Helper.WebApiClient.GetAsync("ProductCategorie/" + id.ToString());
            product.Wait();

            var result = product.Result;
            if (result.IsSuccessStatusCode)
            {
                var prdetoedit = result.Content.ReadAsAsync<ProductCategorie>();
                prdetoedit.Wait();
                productcat = prdetoedit.Result;
            }
            return View(productcat);
        }

        [HttpPost]
        public ActionResult Edit(ProductCategorie productcategorie)
        {
            var editTask = Helper.Helper.WebApiClient.PutAsJsonAsync<ProductCategorie>("ProductCategorie/" + productcategorie.ID, productcategorie);
            editTask.Wait();
            var result = editTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(productcategorie);
        }


        public ActionResult Delete(Guid id)
        {
            var deletetask = Helper.Helper.WebApiClient.DeleteAsync("ProductCategorie/" + id.ToString());

            var result = deletetask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Delete");
        }
    }
}