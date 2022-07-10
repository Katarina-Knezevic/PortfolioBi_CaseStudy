using System;
using System.Text.Json;

namespace PortfolioBi.PricingDataAnalysis.Bll.TestConsoleApp.Helpers
{
    public class ConsoleHelper
    {
        public static void ShowObject(object obj, string msg)
        {
            var json = JsonSerializer.Serialize(obj, obj.GetType());

            Console.WriteLine("\n\n----------" + msg + "----------\n");
            Console.Write(json);        
            Console.WriteLine(String.Empty);
        }
    }
}
