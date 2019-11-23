using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SettingsReader.Application;
using SettingsReader.Models;

namespace SettingsReader.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMySettings settings;
        private readonly IConfiguration configuration;

        public HomeController(IMySettings settings, IConfiguration configuration)
        {
            this.settings = settings;
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.EnviromentName = settings.EnvironmentName;
            ViewBag.VariableToOverride = settings.VariableToOverride;
            ViewBag.SecretVariable = configuration["SecretVariable"] ?? string.Empty;
            ViewBag.SecretConnectionString = configuration.GetConnectionString("SecretConnectionString") ?? string.Empty;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
