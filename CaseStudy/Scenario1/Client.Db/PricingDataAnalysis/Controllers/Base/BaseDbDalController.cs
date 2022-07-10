using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PortfolioBi.Client.Db.PricingDataAnalysis.Ef;
using PortfolioBi.Client.Db.PricingDataAnalysis.Base.Controllers;

namespace PortfolioBi.Client.Db.PricingDataAnalysis.Controllers
{
    
    public class QueryDalController : BaseQueryDalController<PricingDataAnalysisDbContext>, IQueryDalController
    {
        public QueryDalController(PricingDataAnalysisDbContext dbContext) : base(dbContext)
        {
        }
    }
}
