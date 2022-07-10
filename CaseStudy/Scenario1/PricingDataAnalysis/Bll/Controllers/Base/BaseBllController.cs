using PortfolioBi.Client.Db.PricingDataAnalysis.Base;
using PortfolioBi.PricingDataAnalysis.Bll;

namespace PortfolioBi.PricingDataAnalysis.WebApi.BLL.Controllers.Base
{
    

    public class BaseUnitOfWorkBllController 
    {
        protected PricingDataAnalysisBllUnitOfWorkContext Context { get; set; }
        protected IPricingDataAnalysisDalUnitOfWork DalUnitOfWork { get; set; }
        public BaseUnitOfWorkBllController(PricingDataAnalysisBllUnitOfWorkContext context)
        {
            this.Context = context;
            this.DalUnitOfWork = this.Context.DalUnitOfWork;
        }


    }
}
