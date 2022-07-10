using System.Collections.Generic;
using System.Threading.Tasks;
using PortfolioBi.PricingDataAnalysis.Bll.Models;

namespace PortfolioBi.PricingDataAnalysis.Bll.Base.Controllers
{
    public interface ICaseStudyBllController
    {
        Task<List<AvgPrice_Output>> AvgPrice(AvgPrice_Input input);
        Task<List<MaxPrice_Output>> MaxPrice(MaxPrice_Input input);
        Task<List<MinPrice_Output>> MinPrice(MinPrice_Input input);
        Task<List<LocalMaxPrice_Output>> LocalMaxPrice(LocalMaxPrice_Input input);
        Task<List<ReturnOnInvestment_Output>> ReturnOnInvestment(ReturnOnInvestment_Input input);


    }
}
