using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

using PortfolioBi.Client.WebApi.PricingDataAnalysis.Base;
using PortfolioBi.Client.WebApi.PricingDataAnalysis.Base.Controllers;
using PortfolioBi.Client.WebApi.PricingDataAnalysis.Controllers;
using PortfolioBi.Client.WebApi.PricingDataAnalysis.Setting;

namespace PortfolioBi.Client.WebApi.PricingDataAnalysis
{
    public class PricingDataAnalysisDalUnitOfWork : IPricingDataAnalysisDalUnitOfWork
    {
        public DalSetting Setting { get; set; }
        public IHttpClientFactory HttpClientFactory { get; set; }   

        #region CaseStudy
        protected ICaseStudyDalController caseStudy;
        public ICaseStudyDalController CaseStudy
        {
            get
            {
                if (caseStudy == null) caseStudy = new CaseStudyDalController(this.Setting, this.HttpClientFactory);
                return caseStudy;
            }
        }

        #endregion

      

        public PricingDataAnalysisDalUnitOfWork(DalSetting setting, IHttpClientFactory httpClientFactory)
        {
            this.Setting = setting;
            this.HttpClientFactory = httpClientFactory;
        }
    }
}
