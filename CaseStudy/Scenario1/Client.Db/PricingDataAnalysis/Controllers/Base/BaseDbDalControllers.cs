using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PortfolioBi.Client.Db.PricingDataAnalysis.Base.Controllers;

namespace PortfolioBi.Client.Db.PricingDataAnalysis.Base.Controllers
{
    public abstract class BaseDbDalController<TDbContext>
        where TDbContext : DbContext
    {
        public TDbContext DbContext { get; set; }
        public BaseDbDalController(TDbContext dbContext)
        {
            this.DbContext = dbContext;
        }
    }
    public class BaseQueryDalController<TDbContext> : BaseDbDalController<TDbContext>, IQueryDalController
        where TDbContext : DbContext
    {
        public BaseQueryDalController(TDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<T>> ExecuteQuery<T>(FormattableString queryString) where T : class
        {
            var query = this.DbContext.Set<T>().FromSqlInterpolated(queryString);
            var list = query.ToList();
            return await Task.FromResult<List<T>>(list);
        }
        
    }
    
}
