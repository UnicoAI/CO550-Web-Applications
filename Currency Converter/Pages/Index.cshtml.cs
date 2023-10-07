using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;

namespace WebApplication1.Pages
{

    public class IndexModel : PageModel
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public double Result { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public void OnPost()
        {
            Name = Request.Form["Name"];
            FromCurrency = Request.Form["FromCurrency"];
            ToCurrency = Request.Form["ToCurrency"];
            double.TryParse(Request.Form["Amount"], out double amount);

            Result = ConvertCurrency(amount, FromCurrency, ToCurrency);
        }
        private double ConvertCurrency(double Amount, string FromCurrency, string ToCurrency)
        {
            double conversionRate = 0.0;

            // Determine the conversion rate based on the selected currencies
            switch (FromCurrency)
            {
                case "GBP":
                    switch (ToCurrency)
                    {
                        case "EUR":
                            conversionRate = 1.5; 
                            break;
                        case "USD":
                            conversionRate = 2.0; 
                            break;
                        case "GBP":
                            conversionRate = 1.0; 
                            break;
                        
                    }
                    break;

                case "EUR":
                    switch (ToCurrency)
                    {
                        case "EUR":
                            conversionRate = 1;
                            break;
                        case "USD":
                            conversionRate = 15;
                            break;
                        case "GBP":
                            conversionRate = 0.75;
                            break;

                    }
                    break;
                  

                case "USD":
                    switch (ToCurrency)
                    {
                        case "EUR":
                            conversionRate = 0.75;
                            break;
                        case "USD":
                            conversionRate = 1;
                            break;
                        case "GBP":
                            conversionRate = 0.5;
                            break;

                    }
                    break;


            }

            // Perform the conversion
            double result = Amount * conversionRate;

            return result;
        }
    }
    }