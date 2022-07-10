using System;
using System.Threading.Tasks;
using System.Collections.Generic;


using PortfolioBi.PricingDataAnalysis.BllClient.Setting;
using PortfolioBi.Client.WebApi.PricingDataAnalysis.Base;

namespace PortfolioBi.PricingDataAnalysis.BllClient.Base
{
    public class BaseBllController
    {
        protected BllSetting Setting { get; set; }
        public BaseBllController(BllSetting setting)
        {
            this.Setting = setting;
        }
    }
    public class BaseBllUnitOfWorkController : BaseBllController
    {
        protected IPricingDataAnalysisDalUnitOfWork DalUnitOfWork { get; set; }
        public BaseBllUnitOfWorkController(BllSetting setting, IPricingDataAnalysisDalUnitOfWork dalUnitOfWork) : base(setting)
        {
            this.DalUnitOfWork = dalUnitOfWork;
        }

        //protected async Task<List<T>> GetDataFromCashOrLoad<T>(string cachDataKey)
        //{
        //    var cashingData = await this.GetCashingData();
        //    return (List<T>)cashingData.GetDataFromCash(cachDataKey);
        //}
        //protected async Task<CashingData> GetCashingData()
        //{
        //    var cashingContext = CashingHelper.GetCashingContext(this.Setting.CashingSetting);

        //    var cashingData = await cashingContext.LoadData<CashingData>(
        //    "EnumContext",
        //    async () =>
        //    {
        //        var data = new CashingData();
        //        object list = null;
    
        //        // Ukoliko budemo dodavali enumeratore
        //        // Za sada nismo radili na klijentskom kesiranju

        //        return data;
        //    }
        //    );

        //    return cashingData;
        //}
    }
}
