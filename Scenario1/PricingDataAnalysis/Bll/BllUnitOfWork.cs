using PortfolioBi.PricingDataAnalysis.Bll.Base;
using PortfolioBi.PricingDataAnalysis.Bll.Base.Controllers;
using PortfolioBi.PricingDataAnalysis.WebApi.BLL.Controllers;

namespace PortfolioBi.PricingDataAnalysis.Bll
{
    public class PricingDataAnalysisBllUnitOfWork : IPricingDataAnalysisBllUnitOfWork
    {
        protected PricingDataAnalysisBllUnitOfWorkContext Context { get; set; }


        #region CaseStudy
        protected ICaseStudyBllController caseStudy;
        public ICaseStudyBllController CaseStudy
        {
            get
            {
                if (caseStudy == null) caseStudy = new CaseStudyBllController(this.Context);
                return caseStudy;
            }
        }
        #endregion

        

        public PricingDataAnalysisBllUnitOfWork(PricingDataAnalysisBllUnitOfWorkContext context)
        {
            this.Context = context;
        }
    }
}
