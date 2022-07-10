using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

using PortfolioBi.PricingDataAnalysis.Bll.Base;
using PortfolioBi.PricingDataAnalysis.Bll.Base.Controllers;
using PortfolioBi.PricingDataAnalysis.Bll.Models;

namespace PortfolioBi.PricingDataAnalysis.Bll.WebApi.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        protected IPricingDataAnalysisBllUnitOfWork BllUnitOfWork { get; set; }

        public BaseController(IPricingDataAnalysisBllUnitOfWork bllUnitOfWork)
        {
            this.BllUnitOfWork = bllUnitOfWork;
        }
    }

    //public class BaseLoggerController<T> : BaseController
    //{
    //    protected readonly ILogger<T> _logger;
    //    public BaseLoggerController(ILogger<T> logger, IPricingDataAnalysisBllUnitOfWork bllUnitOfWork) : base(bllUnitOfWork)
    //    {
    //        _logger = logger;
    //    }
    //}
}