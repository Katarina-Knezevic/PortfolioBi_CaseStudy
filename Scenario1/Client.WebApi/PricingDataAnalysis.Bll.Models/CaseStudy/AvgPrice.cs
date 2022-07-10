namespace PortfolioBi.Client.WebApi.PricingDataAnalysis.Models
{
    public class AvgPrice_Input /*: BaseIndexInput*/
    {
        public string Company { get; set; }


    }
    public partial class AvgPrice_Output
    {

        public double Price { get; set; }


    }
}
