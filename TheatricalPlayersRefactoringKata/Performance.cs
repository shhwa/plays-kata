using System;

namespace TheatricalPlayersRefactoringKata
{
    public class Performance
    {
        private string _playID;
        private int _audience;

        public string PlayID { get => _playID; set => _playID = value; }
        public int Audience { get => _audience; set => _audience = value; }
        public Play Play { get; set; }

        public Performance(string playID, int audience)
        {
            this._playID = playID;
            this._audience = audience;
        }

        public Performance(Play play, int audience)
        {
            this.Play = play;
            this._audience = audience;
        }
        
        public int CalculateVolumeCreditsForPerformance()
        {
            if ("comedy" == Play.Type)
            {
                return CalculateVolumeCreditsIfComedy(this);
            }
            return CalculateVolumeCreditsIfTragedy(this);
        }

        public static int CalculateAmountForPerformance(Performance perf)
        {
            int thisAmount;
            switch (perf.Play.Type)
            {
                case "tragedy":
                    thisAmount = CalculateThisAmountForTragedy(perf);
                    break;
                case "comedy":
                    thisAmount = CalculateThisAmountForComedy(perf);
                    break;
                default:
                    throw new Exception("unknown type: " + perf.Play.Type);
            }

            return thisAmount;
        }

        private static int CalculateVolumeCreditsIfTragedy(Performance perf)
        {
            return Math.Max(perf.Audience - 30, 0);
        }

        private static int CalculateVolumeCreditsIfComedy(Performance perf)
        {
            return Math.Max(perf.Audience - 30, 0) + (int)Math.Floor((decimal)perf.Audience / 5);
            
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
