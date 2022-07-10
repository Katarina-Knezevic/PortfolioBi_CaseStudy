using System;
using System.Collections.Generic;
using System.Text;

using PortfolioBi.PricingDataAnalysis.BllClient.Base.Controllers;

namespace PortfolioBi.PricingDataAnalysis.BllClient.Base
{
    public interface IPricingDataAnalysisBllUnitOfWork
    {

        ICaseStudyBllController CaseStudy { get; }
        
    }
}
