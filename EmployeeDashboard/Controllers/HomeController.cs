using Employee.Data.Model;
using EmployeeDashboard.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServer _server;      

        public HomeController(ILogger<HomeController> logger, IServer server)
        {
            _logger = logger;
            _server = server;
        }

        public IActionResult Index()
        {
            List<Department> list = new List<Department>();
            list = GetAllDepartments();
            return View(list);
        }
                

        private List<Department> GetAllDepartments()
        {
            List<Department> departments = new List<Department>();
            string localhost = _server.Features.Get<IServerAddressesFeature>().Addresses.ToList()[0];
            string URL = localhost + "api/Department/GetDepartment";
            
            HttpClient client = new HttpClient();
            HttpResponseMessage response = new HttpResponseMessage();

            response = client.GetAsync(URL).Result;

            if (response.IsSuccessStatusCode)
            {
                departments = JsonConvert.DeserializeObject<List<Department>>(response.Content.ReadAsStringAsync().Result);
            }

            return departments;
        }
    }
}
