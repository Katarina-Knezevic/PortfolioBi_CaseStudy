using PortfolioBi.PricingDataAnalysis.Bll.Base.Controllers;

namespace PortfolioBi.PricingDataAnalysis.Bll.Base
{
    public interface IPricingDataAnalysisBllUnitOfWork
    {

        ICaseStudyBllController CaseStudy { get; }

    }
}
