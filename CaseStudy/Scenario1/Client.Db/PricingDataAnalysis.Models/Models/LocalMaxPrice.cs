using System;
using System.Collections.Generic;

#nullable disable

namespace PortfolioBi.Client.Db.PricingDataAnalysis.Models
{
    public partial class LocalMaxPrice
    {


        public string LocalMaxDate { get; set; }
        public double Price { get; set; }
        public double MaxSubtraction { get; set; }



    }
}
