using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using PortfolioBi.PricingDataAnalysis.Bll.Models;
using PortfolioBi.PricingDataAnalysis.Bll.Base;
using PortfolioBi.PricingDataAnalysis.Bll.WebApi.Controllers.Base;

namespace PortfolioBi.PricingDataAnalysis.WebApi.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class CaseStudyController : BaseController
    {
        private readonly ILogger<CaseStudyController> _logger;
        public CaseStudyController(ILogger<CaseStudyController> logger, IPricingDataAnalysisBllUnitOfWork bllUnitOfWork) : base(bllUnitOfWork)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<List<AvgPrice_Output>> AvgPrice(AvgPrice_Input input)
        {
            var output = await this.BllUnitOfWork.CaseStudy.AvgPrice(input);

            return output;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<List<MaxPrice_Output>> MaxPrice(MaxPrice_Input input)
        {
            var output = await this.BllUnitOfWork.CaseStudy.MaxPrice(input);

            return output;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<List<MinPrice_Output>> MinPrice(MinPrice_Input input)
        {
            var output = await this.BllUnitOfWork.CaseStudy.MinPrice(input);

            return output;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<List<LocalMaxPrice_Output>> LocalMaxPrice(LocalMaxPrice_Input input)
        {
            var output = await this.BllUnitOfWork.CaseStudy.LocalMaxPrice(input);

            return output;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<List<ReturnOnInvestment_Output>> ReturnOnInvestment(ReturnOnInvestment_Input input)
        {
            var output = await this.BllUnitOfWork.CaseStudy.ReturnOnInvestment(input);

            return output;
        }


    }
}
