using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using PortfolioBi.Client.WebApi.PricingDataAnalysis.Base;
using PortfolioBi.Client.WebApi.PricingDataAnalysis.Setting;
using PortfolioBi.Client.WebApi.PricingDataAnalysis;

using PortfolioBi.PricingDataAnalysis.BllClient.Base;
using PortfolioBi.PricingDataAnalysis.BllClient.Setting;
using PortfolioBi.PricingDataAnalysis.BllClient;

namespace PortfolioBi.PricingDataAnalysis.Bll.TestConsoleApp
{
    public static class StartupExtensionPricingDataAnalysis
    {
        public static void AddPricingDataAnalysisClientBll(this IServiceCollection services, IConfiguration configuration)
        {
            #region HttpClient
            services.AddHttpClient("myServiceClient")
                .ConfigureHttpClient((services, client) =>
                {
                    client.Timeout = TimeSpan.FromSeconds(60);
                })
                .ConfigurePrimaryHttpMessageHandler((services) =>
                {
                    return new HttpClientHandler();
                }
                );

            services.AddHttpClient("myServiceClientWinAuth")
                .ConfigureHttpClient((services, client) =>
                {
                    client.Timeout = TimeSpan.FromSeconds(60);
                })
                .ConfigurePrimaryHttpMessageHandler((services) =>
                {
                    var handler = new HttpClientHandler { UseDefaultCredentials = true };
                    return handler;
                }
                );

            
            #endregion

            #region Dal
            services.AddSingleton<DalSetting>(services =>
            {
                var setting = new DalSetting();
                configuration.GetSection("DalSetting").Bind(setting);
                return setting;
            }
            );

            services.AddScoped<IPricingDataAnalysisDalUnitOfWork, PricingDataAnalysisDalUnitOfWork>();
            #endregion

            #region Bll
            services.AddSingleton<BllSetting>(services =>
            {
                var setting = new BllSetting();
                configuration.GetSection("BllSetting").Bind(setting);
                return setting;
            }
            );
            services.AddScoped<IPricingDataAnalysisBllUnitOfWork, PricingDataAnalysisBllUnitOfWork>();
            #endregion
        }
    }

}
