using PortfolioBi.Client.Db.PricingDataAnalysis.Base;
using System.Threading.Tasks;
using PortfolioBi.Client.Db.PricingDataAnalysis.Ef;

namespace PortfolioBi.Client.Db.PricingDataAnalysis
{
    public partial class PricingDataAnalysisDalUnitOfWork: IPricingDataAnalysisDalUnitOfWork
    {
        public PricingDataAnalysisDalUnitOfWorkContext Context { get; set; }
        public PricingDataAnalysisDbContext DbContext { get; set; }

        public PricingDataAnalysisDalUnitOfWork(PricingDataAnalysisDalUnitOfWorkContext context)
        {
            this.Context = context;
            this.DbContext = this.Context.DbContext;
        }

        public PricingDataAnalysisDbContext GetDbContext()
        {
            return this.DbContext;
        }


    }
}
