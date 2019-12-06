using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SettingsReader.Application;
using SettingsReader.Models;

namespace SettingsReader.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMySettings settings;
        private readonly IConfiguration configuration;
        private readonly ILogger<HomeController> logger;

        public HomeController(IMySettings settings, IConfiguration configuration, ILogger<HomeController> logger)
        {
            this.settings = settings;
            this.configuration = configuration;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.EnviromentName = settings.EnvironmentName;
            ViewBag.VariableToOverride = settings.VariableToOverride;
            ViewBag.SecretVariable = configuration["SecretVariable"] ?? string.Empty;
            ViewBag.SecretConnectionString = configuration.GetConnectionString("SecretConnectionString") ?? string.Empty;
            ViewBag.IP = this.HttpContext.Connection.RemoteIpAddress.ToString();
            ViewBag.UserAgent = this.HttpContext.Request.Headers["User-Agent"].ToString();
            this.logger.LogInformation("Logging some information when the Index page is hit.");
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
