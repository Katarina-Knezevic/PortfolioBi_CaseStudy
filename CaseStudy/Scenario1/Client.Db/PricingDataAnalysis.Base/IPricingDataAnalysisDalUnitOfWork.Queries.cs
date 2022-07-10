using PortfolioBi.Client.Db.PricingDataAnalysis.Base.Controllers;

namespace PortfolioBi.Client.Db.PricingDataAnalysis.Base
{
    public partial interface IPricingDataAnalysisDalUnitOfWork
    {
        IQueryDalController Query { get; }
    }
}
