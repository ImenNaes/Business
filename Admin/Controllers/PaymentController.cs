using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
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
    }
}