using System;
using System.Collections.Generic;
using System.Text;

using PortfolioBi.Client.Db.PricingDataAnalysis.Base;
using PortfolioBi.Client.Db.PricingDataAnalysis.Base.Controllers;
using PortfolioBi.Client.Db.PricingDataAnalysis.Settings;
using PortfolioBi.Client.Db.PricingDataAnalysis.Controllers;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfolioBi.Client.Db.PricingDataAnalysis.Ef;

namespace PortfolioBi.Client.Db.PricingDataAnalysis
{
    public partial class PricingDataAnalysisDalUnitOfWork
    {
        #region Query
        protected IQueryDalController query;
        public IQueryDalController Query
        {
            get
            {
                if (query == null) query = new QueryDalController(this.DbContext);
                return query;
            }
        }
        #endregion
    }
}
