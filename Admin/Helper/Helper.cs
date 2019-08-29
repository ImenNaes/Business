using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Admin.Helper
{
    public static class Helper
    {
        public static HttpClient WebApiClient = new HttpClient();
         static Helper()
        {

            WebApiClient.BaseAddress = new Uri("http://localhost:57622/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}