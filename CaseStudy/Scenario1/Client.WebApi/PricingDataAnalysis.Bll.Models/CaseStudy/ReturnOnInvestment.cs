namespace PortfolioBi.Client.WebApi.PricingDataAnalysis.Models
{
    public class ReturnOnInvestment_Input 
    {
        public string Company { get; set; }
        public string Date { get; set; }



    }
    public partial class ReturnOnInvestment_Output
    {

        public double ROI { get; set; }


    }
}
