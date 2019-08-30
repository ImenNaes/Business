using Admin.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            IEnumerable<Payment> paymentlist;
            //to bring data of payment table from webApi project
            HttpResponseMessage response = Helper.Helper.WebApiClient.GetAsync("Payment").Result;
            //To convert response to IEnumerable type 
            paymentlist = response.Content.ReadAsAsync<IEnumerable<Payment>>().Result;
            return View(paymentlist);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Payment payment)
        {
            var addpayment = Helper.Helper.WebApiClient.PostAsJsonAsync<Payment>("Payment",payment);
            addpayment.Wait();
            var result = addpayment.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            ModelState.AddModelError(string.Empty, "Something wrong!! please try again...");
            return View(payment);
        }

        public ActionResult Edit(int id)
        {
            Payment payment = null;
            var responseTask = Helper.Helper.WebApiClient.GetAsync("payment/" + id.ToString());
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Payment>();
                readTask.Wait();

                payment = readTask.Result;
            }
            
            return View(payment);
        }
        [HttpPost]
        public ActionResult Edit(Payment payment)
        {
            //HTTP Put
            var edit = Helper.Helper.WebApiClient.PutAsJsonAsync("payment/"+ payment.ID, payment);
            edit.Wait();
            var result = edit.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(payment);

        }

        public void Delete(int id)
        {
            //HTTP Delete
            var deletetask = Helper.Helper.WebApiClient.DeleteAsync("Payment/" +id.ToString());
            deletetask.Wait();

            var result = deletetask.Result;
            if (result.IsSuccessStatusCode)
            {
                RedirectToAction("Index");
            }


            RedirectToAction("Index");
        }
       
    }
}