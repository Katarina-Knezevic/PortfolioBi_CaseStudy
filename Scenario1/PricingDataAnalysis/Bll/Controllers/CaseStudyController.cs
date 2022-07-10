using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DalModels = PortfolioBi.Client.Db.PricingDataAnalysis.Models;
using PortfolioBi.PricingDataAnalysis.Bll.Models;
using PortfolioBi.PricingDataAnalysis.Bll.Base.Controllers;
using PortfolioBi.PricingDataAnalysis.WebApi.BLL.Controllers.Base;
using PortfolioBi.PricingDataAnalysis.Bll;

namespace PortfolioBi.PricingDataAnalysis.WebApi.BLL.Controllers
{
    public class CaseStudyBllController : BaseUnitOfWorkBllController, ICaseStudyBllController
    {
        public CaseStudyBllController(PricingDataAnalysisBllUnitOfWorkContext context) : base(context)
        {
        }

        #region AvgPrice

        public async Task<List<AvgPrice_Output>> AvgPrice(AvgPrice_Input input)
        {
            FormattableString queryString = $"exec AvgPrice {input.Company}";
            var dalOutput = await this.DalUnitOfWork.Query.ExecuteQuery<DalModels.AvgPrice>(queryString);


            var output = new List<AvgPrice_Output>();

            foreach (var item in dalOutput)
            {
                output.Add(MappingToOutput(item));
            }

            return output;
        }

        protected AvgPrice_Output MappingToOutput(DalModels.AvgPrice fromItem)
        {
            var toItem = new AvgPrice_Output();

            toItem.Price = fromItem.Price;

            return toItem;
        }

        #endregion

        #region LocalMaxPrice

        public async Task<List<LocalMaxPrice_Output>> LocalMaxPrice(LocalMaxPrice_Input input)
        {
            FormattableString queryString = $"exec LocalMaxPrice {input.Company}";
            var dalOutput = await this.DalUnitOfWork.Query.ExecuteQuery<DalModels.LocalMaxPrice>(queryString);


            var output = new List<LocalMaxPrice_Output>();

            foreach (var item in dalOutput)
            {
                output.Add(MappingToOutput(item));
            }
            return output;
        }

        protected LocalMaxPrice_Output MappingToOutput(DalModels.LocalMaxPrice fromItem)
        {
            var toItem = new LocalMaxPrice_Output();

            toItem.Price = fromItem.Price;
            toItem.LocalMaxDate = fromItem.LocalMaxDate;
            toItem.MaxSubtraction = fromItem.MaxSubtraction;


            return toItem;
        }

        #endregion

        #region MaxPrice

        public async Task<List<MaxPrice_Output>> MaxPrice(MaxPrice_Input input)
        {
            FormattableString queryString = $"exec MaxPrice {input.Company}";
            var dalOutput = await this.DalUnitOfWork.Query.ExecuteQuery<DalModels.MaxPrice>(queryString);


            var output = new List<MaxPrice_Output>();

            foreach (var item in dalOutput)
            {
                output.Add(MappingToOutput(item));
            }
            return output;
        }

        protected MaxPrice_Output MappingToOutput(DalModels.MaxPrice fromItem)
        {
            var toItem = new MaxPrice_Output();

            toItem.Price = fromItem.Price;

            return toItem;
        }
        #endregion

        #region MinPrice

        public async Task<List<MinPrice_Output>> MinPrice(MinPrice_Input input)
        {
            FormattableString queryString = $"exec MinPrice {input.Company}";
            var dalOutput = await this.DalUnitOfWork.Query.ExecuteQuery<DalModels.MinPrice>(queryString);


            var output = new List<MinPrice_Output>();

            foreach (var item in dalOutput)
            {
                output.Add(MappingToOutput(item));
            }
            return output;
        }

        protected MinPrice_Output MappingToOutput(DalModels.MinPrice fromItem)
        {
            var toItem = new MinPrice_Output();

            toItem.Price = fromItem.Price;

            return toItem;
        }


        #endregion

        #region ReturnOnInvestment
        public async Task<List<ReturnOnInvestment_Output>> ReturnOnInvestment(ReturnOnInvestment_Input input)
        {
            FormattableString queryString = $"exec ROI {input.Company}, {input.Date}";
            var dalOutput = await this.DalUnitOfWork.Query.ExecuteQuery<DalModels.ReturnOnInvestment>(queryString);


            var output = new List<ReturnOnInvestment_Output>();

            foreach (var item in dalOutput)
            {
                output.Add(MappingToOutput(item));
            }
            return output;
        }

        protected ReturnOnInvestment_Output MappingToOutput(DalModels.ReturnOnInvestment fromItem)
        {
            var toItem = new ReturnOnInvestment_Output();

            toItem.ROI = fromItem.ROI;

            return toItem;
        }

        #endregion

    }

}



