using PortfolioBi.Client.Db.PricingDataAnalysis.Base;

namespace PortfolioBi.PricingDataAnalysis.Bll
{
    public partial class PricingDataAnalysisBllUnitOfWorkContext
    {
        public IPricingDataAnalysisDalUnitOfWork DalUnitOfWork { get; set; }
        public PricingDataAnalysisBllUnitOfWorkContext( IPricingDataAnalysisDalUnitOfWork dalUnitOfWork)
        {
            this.DalUnitOfWork = dalUnitOfWork;
        }
    }
}
