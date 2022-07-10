using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PortfolioBi.Client.Db.PricingDataAnalysis;
using PortfolioBi.Client.Db.PricingDataAnalysis.Base;
using PortfolioBi.Client.Db.PricingDataAnalysis.Ef;
using PortfolioBi.Client.Db.PricingDataAnalysis.Settings;
using PortfolioBi.PricingDataAnalysis.Bll.Base;
using Microsoft.EntityFrameworkCore;

namespace PortfolioBi.PricingDataAnalysis.Bll.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<PricingDataAnalysisDbContext>(services =>
            {
                var dalSetting = services.GetService<DalSetting>();
                var connectionStringCode = dalSetting.ConnectionStringCode;
                var connectionString = this.Configuration.GetConnectionString(connectionStringCode);

                var optionsBuilder = new DbContextOptionsBuilder<PricingDataAnalysisDbContext>();
                optionsBuilder.UseSqlServer(connectionString);

                return new PricingDataAnalysisDbContext(optionsBuilder.Options);
            });


            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));


            #region Dal
            services.AddSingleton<DalSetting>(services =>
            {
                var setting = new DalSetting();
                Configuration.GetSection("PortfolioBi.Client.Db.PricingDataAnalysis.Settings.DalSetting").Bind(setting);
                return setting;
            });
            services.AddScoped<PricingDataAnalysisDalUnitOfWorkContext>();
            services.AddScoped<IPricingDataAnalysisDalUnitOfWork, PricingDataAnalysisDalUnitOfWork>();
            #endregion

            

            #region Bll

            services.AddScoped<PricingDataAnalysisBllUnitOfWorkContext>();
            services.AddScoped<IPricingDataAnalysisBllUnitOfWork, PricingDataAnalysisBllUnitOfWork>();
            #endregion

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors("MyPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
