using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using PortfolioBi.Client.WebApi.PricingDataAnalysis.Setting;

namespace PortfolioBi.Client.WebApi.PricingDataAnalysis.Controllers.Base
{
    public class BaseDalController
    {
        protected DalSetting Setting { get; set; }
        protected IHttpClientFactory HttpClientFactory { get; set; }
        public BaseDalController(DalSetting setting, IHttpClientFactory httpClientFactory)
        {
            this.Setting = setting;
            this.HttpClientFactory = httpClientFactory;
        }

        #region Util-Url 
        protected string GetUrl(string relativeUrl)
        {
            return this.GetUrl(relativeUrl, null);
        }

        protected string GetUrl(string relativeUrl, string queryString)
        {
            return this.GetUrl(this.Setting.ServiceUrl, relativeUrl, queryString);
        }

        protected string GetUrl(string rootUrl, string relativeUrl, string queryString)
        {
            if (queryString == null)
            {
                var url = $"{rootUrl}{relativeUrl}";
                return url;
            }
            else
            {
                var url = $"{rootUrl}{relativeUrl}?{queryString}";
                return url;
            }
        }
        #endregion

        #region Util-Serialization
        protected T Deserialize<T>(string jsonString)
        {
            var item = JsonSerializer.Deserialize<T>(jsonString, this.GetSerializationOptions());
            return item;
        }
        protected string Serialize<T>(T input)
        {
            var json = JsonSerializer.Serialize<T>(input, this.GetSerializationOptions());
            return json;
        }
        protected JsonSerializerOptions GetSerializationOptions()
        {
            return new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
        }
        #endregion

        #region Util-HttpClient-Creating
        protected HttpClient CreateHttpClient()
        {
            return this.HttpClientFactory.CreateClient("myServiceClient");
        }
        
        #endregion

        #region Util-HttpClient-Methods

        
        protected async Task<TOutput> PostAsync<TInput, TOutput>(string relativeUrl, TInput input, HttpClient client)
        {
            var url = this.GetUrl(relativeUrl);
            var output = await this.PostToAbsoluteUrlAsync<TInput, TOutput>(url, input, client);
            return output;
        }
        protected async Task<TOutput> PostToAbsoluteUrlAsync<TInput, TOutput>(string url, TInput input, HttpClient client)
        {
            var json = JsonSerializer.Serialize<TInput>(input, this.GetSerializationOptions());
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, httpContent);
            var output = await this.ProcessResponse<TOutput>(response);
            return output;
        }
        #endregion

        protected async Task<T> ProcessResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var details = this.Deserialize<T>(jsonString);
                return details;
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"{responseContent}");
            }
        }

    }
}
