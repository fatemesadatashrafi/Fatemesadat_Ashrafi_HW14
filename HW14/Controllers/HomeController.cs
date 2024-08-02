using HW14.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HW14.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static string FilePath { get; set; } = "UserInformation.txt";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Subscription()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Submit(UserInformationViewModel u)
        {

            if (ModelState.IsValid)
            {
                if (u.AcceptingRules==false)
                {
                    ViewBag.AcceptingRules = "false";
                    return View(nameof(Subscription));
                }
                else
                {
                    Validation(u);
                    if (ViewBag.FirstNameType == "false" || ViewBag.LastNameType == "false" || ViewBag.BootcampCode == "false" || ViewBag.Age == "false")
                    {
                        return View(nameof(Subscription));
                    }
                    else
                    {
                        var json = JsonConvert.SerializeObject(u, Formatting.Indented);
                        string jsonString = JsonConvert.SerializeObject(json);
                        System.IO.File.WriteAllText(FilePath, jsonString);
                        return Json(u);
                    }
                }
            }
            //return Json(new { acceptingRules = acceptingRules});
            return View(nameof(Subscription));
        }
        public IActionResult Rules()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public void Validation(UserInformationViewModel u)
        {
            if (!Regex.IsMatch(u.FirstName.Trim(), @"^[a-zA-Z]+$"))
            
                ViewBag.FirstNameType = "false";
            else
                ViewBag.FirstNameType = "true";

            if (!Regex.IsMatch(u.LastName.Trim(), @"^[a-zA-Z]+$"))
                ViewBag.LastNameType = "false";
            else
                ViewBag.LastNameType = "true";
            if (!Regex.IsMatch(u.BootcampCode.ToString(), @"^[2468]\d{2}$"))
                ViewBag.BootcampCode = "false";
            else
                ViewBag.BootcampCode = "true";
            if ((DateTime.Now - u.BirthDate).TotalDays < 6570)
                ViewBag.Age = "false";
            else
                ViewBag.Age = "true";
        }
    }
}
