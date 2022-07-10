using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortfolioBi.PricingDataAnalysis.Bll.Models;

namespace PortfolioBi.IdentityCenterTest.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<WebApiInfo> Index()
        {
            var output = new WebApiInfo();
            output.Code = "PortfolioBi.PricingDataAnalysis.WebApi";
            output.Name = "WebApi - PortfolioBi CaseStudy";

            return await Task.FromResult(output);
        }
    }
    public class WebApiInfo
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
