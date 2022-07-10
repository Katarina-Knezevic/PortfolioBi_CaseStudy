using PortfolioBi.Client.WebApi.PricingDataAnalysis.Models;
using PortfolioBi.PricingDataAnalysis.Bll.TestConsoleApp.Helpers;
using PortfolioBi.PricingDataAnalysis.BllClient.Base;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace PortfolioBi.PricingDataAnalysis.Bll.TestConsoleApp.Views
{
    public class CaseStudyView : BaseView
    {
        public string outputFilePath;

        public CaseStudyView(IPricingDataAnalysisBllUnitOfWork bllUnitOfWork) : base(bllUnitOfWork)
        {
            this.outputFilePath = "..\\..\\..\\..\\Result.txt";
        }

        public async Task DoClearOutputFile()
        {
            await File.WriteAllTextAsync(this.outputFilePath, string.Empty);
        }

        public async Task DoAvgPrice()
        {

            var input = new AvgPrice_Input() { Company = "Corning, Inc. (GLW US)" };
            var output = await this.BllUnitOfWork.CaseStudy.AvgPrice(input);

            await File.AppendAllTextAsync(this.outputFilePath, "Average price\n\n");

            var line = input.Company
                       + ": " + $"{output.FirstOrDefault().Price:0.00}"
                       + "\n";
            await File.AppendAllTextAsync(this.outputFilePath, line);
            ConsoleHelper.ShowObject(output.FirstOrDefault(), input.Company + " - Average price");


            input = new AvgPrice_Input() { Company = "GrubHub, Inc. (GRUB US)" };
            output = await this.BllUnitOfWork.CaseStudy.AvgPrice(input);

            line = input.Company
                    + ": "
                    + $"{output.FirstOrDefault().Price:0.00}" + "\n";
            await File.AppendAllTextAsync(this.outputFilePath, line);
            ConsoleHelper.ShowObject(output.FirstOrDefault(), input.Company + " - Average price");



        }

        public async Task DoMaxPrice()
        {
            var input = new MaxPrice_Input() { Company = "Corning, Inc. (GLW US)" };
            var output = await this.BllUnitOfWork.CaseStudy.MaxPrice(input);
           
            await File.AppendAllTextAsync(this.outputFilePath, "\nMax price\n\n");

            var line = input.Company
                + ": "
                + $"{output.FirstOrDefault().Price:0.00}"
                + "\n";
            await File.AppendAllTextAsync(this.outputFilePath, line);
            ConsoleHelper.ShowObject(output.FirstOrDefault(), input.Company + " - Max price");

            input = new MaxPrice_Input() { Company = "GrubHub, Inc. (GRUB US)" };
            output = await this.BllUnitOfWork.CaseStudy.MaxPrice(input);

            line = input.Company
                + ": "
                + $"{output.FirstOrDefault().Price:0.00}"
                + "\n";
            await File.AppendAllTextAsync(this.outputFilePath, line);
            ConsoleHelper.ShowObject(output.FirstOrDefault(), input.Company + " - Max price");
        }

        public async Task DoMinPrice()
        {
            var input = new MinPrice_Input() { Company = "Corning, Inc. (GLW US)" };
            var output = await this.BllUnitOfWork.CaseStudy.MinPrice(input);

            await File.AppendAllTextAsync(this.outputFilePath, "\nMin price\n\n");

            var line = input.Company
                + ": "
                + $"{output.FirstOrDefault().Price:0.00}"
                + "\n";
            await File.AppendAllTextAsync(this.outputFilePath, line);
            ConsoleHelper.ShowObject(output.FirstOrDefault(), input.Company + " - Min price");

            input = new MinPrice_Input() { Company = "GrubHub, Inc. (GRUB US)" };
            output = await this.BllUnitOfWork.CaseStudy.MinPrice(input);

            line = input.Company
                    + ": "
                    + $"{output.FirstOrDefault().Price:0.00}"
                    + "\n";
            await File.AppendAllTextAsync(this.outputFilePath, line);
            ConsoleHelper.ShowObject(output.FirstOrDefault(), input.Company + " - Min price");
        }

        public async Task DoLocalMaxPrice()
        {
            var input = new LocalMaxPrice_Input() { Company = "Corning, Inc. (GLW US)" };
            var output = await this.BllUnitOfWork.CaseStudy.LocalMaxPrice(input);

            await File.AppendAllTextAsync(this.outputFilePath, "\nMost significant positive price spike\n\n");

            var line = input.Company
                        + ": "
                        + $"{output.FirstOrDefault().MaxSubtraction:0.00}"
                        + " ("
                        + $"{output.FirstOrDefault().LocalMaxDate}"
                        + ")"
                        + "\n";
            await File.AppendAllTextAsync(this.outputFilePath, line);
            ConsoleHelper.ShowObject(output.FirstOrDefault(), input.Company + " - Most significant positive price spike");

            await this.DoReturnOnInvestment(input.Company, output.FirstOrDefault().LocalMaxDate);


            input = new LocalMaxPrice_Input() { Company = "GrubHub, Inc. (GRUB US)" };
            output = await this.BllUnitOfWork.CaseStudy.LocalMaxPrice(input);

            line = input.Company
                         + ": "
                         + $"{output.FirstOrDefault().MaxSubtraction:0.00}"
                         + " ("
                         + $"{output.FirstOrDefault().LocalMaxDate}"
                         + ")"
                         + "\n";
            await File.AppendAllTextAsync(this.outputFilePath, line);
            ConsoleHelper.ShowObject(output.FirstOrDefault(), input.Company + " - Most significant positive price spike");

            await this.DoReturnOnInvestment(input.Company, output.FirstOrDefault().LocalMaxDate);


        }

        

        public async Task DoReturnOnInvestment(string company, string date)
        {

            var input = new ReturnOnInvestment_Input() { Company = company, Date = date };

            var output = await this.BllUnitOfWork.CaseStudy.ReturnOnInvestment(input);
            await File.AppendAllTextAsync(this.outputFilePath, "Return on investment: ");

            var line = $"{output.FirstOrDefault().ROI:0.00}"
                + " (Jan 01, 2015 - "
                + $"{input.Date}"
                + ")"
                + "\n\n";

            await File.AppendAllTextAsync(this.outputFilePath, line);
            ConsoleHelper.ShowObject(output.FirstOrDefault(), input.Company + " - Return on investment");

            //input = new ReturnOnInvestment_Input() { Company = "GrubHub, Inc. (GRUB US)", Date = "Feb 05, 2015" };
            //output = await this.BllUnitOfWork.CaseStudy.ReturnOnInvestment(input);

            //line = input.Company
            //    + ": "
            //    + $"{output.FirstOrDefault().ROI:0.00}"
            //    + " (Jan 01, 2015 - "
            //    + $"{input.Date}"
            //    + ")"
            //    + "\n";
            //await File.AppendAllTextAsync(this.outputFilePath, line);
            //ConsoleHelper.ShowObject(output.FirstOrDefault(), input.Company + " - Return on investment");
        }


    }
}
