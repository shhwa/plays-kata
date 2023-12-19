using System;
using System.Collections.Generic;
using System.Globalization;

namespace TheatricalPlayersRefactoringKata
{
    public class StatementPrinter
    {
        public string Print(Invoice invoice, Dictionary<string, Play> plays)
        {
            var totalAmount = 0;
            var volumeCredits = 0;
            var result = string.Format("Statement for {0}\n", invoice.Customer);
            CultureInfo cultureInfo = new CultureInfo("en-US");

            foreach(var perf in invoice.Performances) 
            {
                var play = perf.Play;
                var thisAmount = 0;
                switch (play.Type) 
                {
                    case "tragedy":
                        thisAmount = CalculateThisAmountForTragedy(perf);
                        break;
                    case "comedy":
                        thisAmount = CalculateThisAmountForComedy(perf);
                        break;
                    default:
                        throw new Exception("unknown type: " + play.Type);
                }
                // add volume credits
                
                // add extra credit for every ten comedy attendees
                if ("comedy" == play.Type)
                {
                    volumeCredits += CalculateVolumeCreditsIfComedy(perf);
                }
                else
                {
                    volumeCredits += CalculateVolumeCreditsIfTragedy(perf);
                }

                // print line for this order
                result += FormatOrder(cultureInfo, play, thisAmount, perf);
                
                totalAmount += thisAmount;
            }
            result += FormatAmountOwed(cultureInfo, totalAmount);
            result += FormatCreditsEarned(volumeCredits);
            return result;
        }

        private static int CalculateVolumeCreditsIfTragedy(Performance perf)
        {
            return Math.Max(perf.Audience - 30, 0);
        }

        private static int CalculateVolumeCreditsIfComedy(Performance perf)
        {
            return Math.Max(perf.Audience - 30, 0) + (int)Math.Floor((decimal)perf.Audience / 5);
            
        }

        private static string FormatCreditsEarned(int volumeCredits)
        {
            return String.Format("You earned {0} credits\n", volumeCredits);
        }

        private static string FormatAmountOwed(CultureInfo cultureInfo, int totalAmount)
        {
            return String.Format(cultureInfo, "Amount owed is {0:C}\n", Convert.ToDecimal(totalAmount / 100));
        }

        private static string FormatOrder(CultureInfo cultureInfo, Play play, int thisAmount, Performance perf)
        {
            return String.Format(cultureInfo, "  {0}: {1:C} ({2} seats)\n", play.Name, Convert.ToDecimal(thisAmount / 100), perf.Audience);
        }

        private static int CalculateThisAmountForComedy(Performance perf)
        {
            int thisAmount;
            thisAmount = 30000;
            if (perf.Audience > 20)
            {
                thisAmount += 10000 + 500 * (perf.Audience - 20);
            }

            thisAmount += 300 * perf.Audience;
            return thisAmount;
        }

        private static int CalculateThisAmountForTragedy(Performance perf)
        {
            int thisAmount;
            thisAmount = 40000;
            if (perf.Audience > 30)
            {
                thisAmount += 1000 * (perf.Audience - 30);
            }

            return thisAmount;
        }
    }
}
