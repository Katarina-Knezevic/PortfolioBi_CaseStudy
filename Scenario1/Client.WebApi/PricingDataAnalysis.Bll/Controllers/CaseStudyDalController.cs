using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

using PortfolioBi.Client.WebApi.PricingDataAnalysis.Models;
using PortfolioBi.Client.WebApi.PricingDataAnalysis.Base.Controllers;
using PortfolioBi.Client.WebApi.PricingDataAnalysis.Controllers.Base;
using PortfolioBi.Client.WebApi.PricingDataAnalysis.Setting;

namespace PortfolioBi.Client.WebApi.PricingDataAnalysis.Controllers
{
    public class CaseStudyDalController : BaseDalController, ICaseStudyDalController
    {
        public CaseStudyDalController(DalSetting setting, IHttpClientFactory httpClientFactory) : base(setting, httpClientFactory)
        {
        }

        public async Task<List<AvgPrice_Output>> AvgPrice(AvgPrice_Input input)
        {
            var relativeUrl = "caseStudy/avgPrice";
            var client = this.CreateHttpClient();
            var output = await this.PostAsync<AvgPrice_Input, List<AvgPrice_Output>>(relativeUrl, input, client);

            return output;
        }

        public async Task<List<MaxPrice_Output>> MaxPrice(MaxPrice_Input input)
        {
            var relativeUrl = "caseStudy/maxPrice";
            var client = this.CreateHttpClient();
            var output = await this.PostAsync<MaxPrice_Input, List<MaxPrice_Output>>(relativeUrl, input, client);

            return output;
        }

        public async Task<List<MinPrice_Output>> MinPrice(MinPrice_Input input)
        {
            var relativeUrl = "caseStudy/minPrice";
            var client = this.CreateHttpClient();
            var output = await this.PostAsync<MinPrice_Input, List<MinPrice_Output>>(relativeUrl, input, client);

            return output;
        }

        public async Task<List<LocalMaxPrice_Output>> LocalMaxPrice(LocalMaxPrice_Input input)
        {
            var relativeUrl = "caseStudy/localMaxPrice";
            var client = this.CreateHttpClient();
            var output = await this.PostAsync<LocalMaxPrice_Input, List<LocalMaxPrice_Output>>(relativeUrl, input, client);

            return output;
        }

        public async Task<List<ReturnOnInvestment_Output>> ReturnOnInvestment(ReturnOnInvestment_Input input)
        {
            var relativeUrl = "caseStudy/returnOnInvestment";
            var client = this.CreateHttpClient();
            var output = await this.PostAsync<ReturnOnInvestment_Input, List<ReturnOnInvestment_Output>>(relativeUrl, input, client);

            return output;
        }

    }
}
