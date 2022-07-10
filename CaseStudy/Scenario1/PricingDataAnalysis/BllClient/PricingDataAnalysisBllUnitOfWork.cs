using PortfolioBi.PricingDataAnalysis.BllClient.Base;
using PortfolioBi.PricingDataAnalysis.BllClient.Base.Controllers;
using PortfolioBi.PricingDataAnalysis.BllClient.Controllers;
using PortfolioBi.PricingDataAnalysis.BllClient.Setting;
using PortfolioBi.Client.WebApi.PricingDataAnalysis.Base;
using System;
using System.Collections.Generic;
using System.Text;



namespace PortfolioBi.PricingDataAnalysis.BllClient
{
    public class PricingDataAnalysisBllUnitOfWork : IPricingDataAnalysisBllUnitOfWork
    {
        protected BllSetting Setting { get; set; }
        protected IPricingDataAnalysisDalUnitOfWork DalUnitOfWork { get; set; }

        

        #region CaseStudy
        protected ICaseStudyBllController caseStudy;
        public ICaseStudyBllController CaseStudy
        {
            get
            {
                if (caseStudy == null) caseStudy = new CaseStudyBllController(this.Setting, this.DalUnitOfWork);
                return caseStudy;
            }
        }
        #endregion

       

        public PricingDataAnalysisBllUnitOfWork(BllSetting setting, IPricingDataAnalysisDalUnitOfWork dalUnitOfWork)
        {
            this.Setting = setting;
            this.DalUnitOfWork = dalUnitOfWork;
        }
    }
}
