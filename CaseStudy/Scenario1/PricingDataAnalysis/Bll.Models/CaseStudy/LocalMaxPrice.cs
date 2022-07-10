namespace PortfolioBi.PricingDataAnalysis.Bll.Models
{
    public class LocalMaxPrice_Input
    {
        public string Company { get; set; }


    }
    public partial class LocalMaxPrice_Output
    {

        public string LocalMaxDate { get; set; }
        public double Price { get; set; }
        public double MaxSubtraction { get; set; }


    }
}
