using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortfolioBi.PricingDataAnalysis.Bll.TestConsoleApp.Views;

namespace PortfolioBi.PricingDataAnalysis.Bll.TestConsoleApp
{
    class Program
    {
        static ServiceProvider ServiceProvider { get; set; }
        static async Task Main(string[] args)
        {
            Console.WriteLine("PortfolioBi.PricingDataAnalysis.Bll.MyConsoleApp");
            Console.OutputEncoding = System.Text.Encoding.UTF8;



            IConfiguration configuration = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .Build();

            var services = new ServiceCollection();
            var startup = new Startup(configuration);
            startup.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            Program.ServiceProvider = serviceProvider;

            await StartToWork();

            Console.WriteLine("Exit PortfolioBi.PricingDataAnalysis.Bll.MyConsoleApp");
            await Task.FromResult(1);
        }

        public static async Task StartToWork()
        {
            var view = Program.ServiceProvider.GetService<CaseStudyView>();

            await view.DoClearOutputFile();

            await view.DoAvgPrice();

            await view.DoMaxPrice();

            await view.DoMinPrice();

            await view.DoLocalMaxPrice();

        }       

    }
}
