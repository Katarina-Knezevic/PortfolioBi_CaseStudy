using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PortfolioBi.Client.Db.PricingDataAnalysis.Base.Controllers
{
    public interface IQueryDalController
    {
        Task<List<T>> ExecuteQuery<T>(FormattableString queryString) where T : class;

    }
}