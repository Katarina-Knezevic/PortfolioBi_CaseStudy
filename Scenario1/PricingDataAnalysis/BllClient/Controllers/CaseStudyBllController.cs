using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using PortfolioBi.Client.WebApi.PricingDataAnalysis.Models;
using PortfolioBi.Client.WebApi.PricingDataAnalysis.Base;
using PortfolioBi.PricingDataAnalysis.BllClient.Base;
using PortfolioBi.PricingDataAnalysis.BllClient.Base.Controllers;
using PortfolioBi.PricingDataAnalysis.BllClient.Setting;

namespace PortfolioBi.PricingDataAnalysis.BllClient.Controllers
{
    public class CaseStudyBllController : BaseBllUnitOfWorkController, ICaseStudyBllController
    {
        public CaseStudyBllController(BllSetting setting, IPricingDataAnalysisDalUnitOfWork dalUnitOfWork) : base(setting, dalUnitOfWork)
        {
        }

        public async Task<List<AvgPrice_Output>> AvgPrice(AvgPrice_Input input)
        {
            
            List<AvgPrice_Output> list;
            try
            {
                list = (List<AvgPrice_Output>)await this.DalUnitOfWork.CaseStudy.AvgPrice(input);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            return list;
        }

        public async Task<List<MaxPrice_Output>> MaxPrice(MaxPrice_Input input)
        {

            List<MaxPrice_Output> list;
            try
            {
                list = (List<MaxPrice_Output>)await this.DalUnitOfWork.CaseStudy.MaxPrice(input);
            }
            catch (Exception ex)
            {              
                throw ex;
            }

            return list;
        }

        public async Task<List<MinPrice_Output>> MinPrice(MinPrice_Input input)
        {

            List<MinPrice_Output> list;
            try
            {
                list = (List<MinPrice_Output>)await this.DalUnitOfWork.CaseStudy.MinPrice(input);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            return list;
        }

        public async Task<List<LocalMaxPrice_Output>> LocalMaxPrice(LocalMaxPrice_Input input)
        {

            List<LocalMaxPrice_Output> list;
            try
            {
                list = (List<LocalMaxPrice_Output>)await this.DalUnitOfWork.CaseStudy.LocalMaxPrice(input);
            }
            catch (Exception ex)
            {
               
                throw ex;
            }

            return list;
        }

        public async Task<List<ReturnOnInvestment_Output>> ReturnOnInvestment(ReturnOnInvestment_Input input)
        {

            List<ReturnOnInvestment_Output> list;
            try
            {
                list = (List<ReturnOnInvestment_Output>)await this.DalUnitOfWork.CaseStudy.ReturnOnInvestment(input);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            return list;
        }


    }
}
