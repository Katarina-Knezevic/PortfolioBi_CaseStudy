using PortfolioBi.Client.Db.PricingDataAnalysis.Settings;
using PortfolioBi.Client.Db.PricingDataAnalysis.Ef;

namespace PortfolioBi.Client.Db.PricingDataAnalysis
{
    public partial class PricingDataAnalysisDalUnitOfWorkContext
    {
        public DalSetting Setting { get; set; }
        public PricingDataAnalysisDbContext DbContext { get; set; }

        public PricingDataAnalysisDalUnitOfWorkContext
                (DalSetting setting,
                PricingDataAnalysisDbContext dbContext)
        {
            this.Setting = setting;
            this.DbContext = dbContext;
        }
    }
}
