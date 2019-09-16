using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class CitiesController : Controller
    {
        // GET: Cities
        public ActionResult Index()
        {
            IEnumerable<City> CitiesList;
            HttpResponseMessage response =Helper.Helper.WebApiClient.GetAsync("City").Result;
            CitiesList = response.Content.ReadAsAsync<IEnumerable<City>>().Result;

            return View(CitiesList);
        }
      
        public ActionResult Create()
        {
            //IEnumerable<Country> countries;
            //HttpResponseMessage response = Helper.Helper.WebApiClient.GetAsync("Country").Result;
            //countries = response.Content.ReadAsAsync<IEnumerable<Country>>().Result;
            //ViewBag.countries = countries;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(City city)
        {
            var newcity = Helper.Helper.WebApiClient.PostAsJsonAsync<City>("City", city);
            newcity.Wait();

            var result = newcity.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Something wrong!! please try again...");

            return View(city);
        }

        public ActionResult Edit(Guid id)
        {
            City city = null;
            var response = Helper.Helper.WebApiClient.GetAsync("City/" + id.ToString());
            response.Wait();

            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var contentnewcity = result.Content.ReadAsAsync<City>();
                contentnewcity.Wait();
                city = contentnewcity.Result;
            }
            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(City city)
        {
            var cityedited = Helper.Helper.WebApiClient.PutAsJsonAsync("City/"+ city.ID, city);
            cityedited.Wait();

            var result = cityedited.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Something wrong!! please try again...");

            return View(city);
        }


        public void Delete(Guid id)
        {
            var city = Helper.Helper.WebApiClient.DeleteAsync("City/"+ id.ToString());
            city.Wait();

            var res = city.Result;
            if (res.IsSuccessStatusCode)
            {
                 RedirectToAction("Index");
            }
            RedirectToAction("Index");
        }
   
    }
}