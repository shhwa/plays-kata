using System;
using System.Collections.Generic;
using System.Globalization;

namespace TheatricalPlayersRefactoringKata
{
    public class StatementPrinter
    {
        public string Print(Invoice invoice)
        {
            var totalAmount = 0;
            var volumeCredits = 0;
            var result = string.Format("Statement for {0}\n", invoice.Customer);
            CultureInfo cultureInfo = new CultureInfo("en-US");

            foreach(var perf in invoice.Performances) 
            {
                var thisAmount = 0;
                thisAmount = perf.CalculateAmountForPerformance();
                // add volume credits
                
                // add extra credit for every ten comedy attendees
                volumeCredits += perf.CalculateVolumeCreditsForPerformance();

                // print line for this order
                result += FormatOrder(cultureInfo, thisAmount, perf);
                
                totalAmount += thisAmount;
            }
            result += FormatAmountOwed(cultureInfo, totalAmount);
            result += FormatCreditsEarned(volumeCredits);
            return result;
        }

        private static string FormatCreditsEarned(int volumeCredits)
        {
            return String.Format("You earned {0} credits\n", volumeCredits);
        }

        private static string FormatAmountOwed(CultureInfo cultureInfo, int totalAmount)
        {
            return String.Format(cultureInfo, "Amount owed is {0:C}\n", Convert.ToDecimal(totalAmount / 100));
        }

        private static string FormatOrder(CultureInfo cultureInfo, int thisAmount, Performance perf)
        {
            return String.Format(cultureInfo, "  {0}: {1:C} ({2} seats)\n", perf.Play.Name, Convert.ToDecimal(thisAmount / 100), perf.Audience);
        }
    }
}
