using PortfolioBi.Client.WebApi.PricingDataAnalysis.Base.Controllers;


namespace PortfolioBi.Client.WebApi.PricingDataAnalysis.Base
{
    public interface IPricingDataAnalysisDalUnitOfWork
    {
    
        ICaseStudyDalController CaseStudy { get; }
        
    }
}
