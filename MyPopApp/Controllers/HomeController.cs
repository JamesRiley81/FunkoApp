using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;

namespace MyPopApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }   
        public async Task<ActionResult> GetAttributes(string bc)
        {
            var apiURL = "https://api.upcitemdb.com/prod/trial/lookup?upc=";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiURL + bc);
                var response = client.GetAsync(apiURL + bc).Result;
                var data = response.Content.ReadAsStringAsync().Result;
                dynamic jsonData = JsonConvert.DeserializeObject(data);
                string title = jsonData.fields["title"];
            }
            return null;
        }
    }
}
