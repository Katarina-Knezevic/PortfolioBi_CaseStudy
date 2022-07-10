using PortfolioBi.PricingDataAnalysis.BllClient.Base;

namespace PortfolioBi.PricingDataAnalysis.Bll.TestConsoleApp.Views
{
    public class BaseView
    {
        protected IPricingDataAnalysisBllUnitOfWork BllUnitOfWork { get; set; }
        public BaseView(IPricingDataAnalysisBllUnitOfWork bllUnitOfWork)
        {
            this.BllUnitOfWork = bllUnitOfWork;
        }
    }
}
