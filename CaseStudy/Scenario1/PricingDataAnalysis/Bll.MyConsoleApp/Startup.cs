using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortfolioBi.PricingDataAnalysis.Bll.TestConsoleApp.Views;

namespace PortfolioBi.PricingDataAnalysis.Bll.TestConsoleApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPricingDataAnalysisClientBll(this.Configuration);

            services.AddSingleton<CaseStudyView>();
            
        }
    }
}
