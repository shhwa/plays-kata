using System;

namespace TheatricalPlayersRefactoringKata
{
    public class Play
    {
        private string _name;

        public string Name { get => _name; set => _name = value; }

        public Play(string name) {
            this._name = name;
        }
        
        public static int CalculateVolumeCreditsIfTragedy(Performance perf)
        {
            return Math.Max(perf.Audience - 30, 0);
        }
        
        public static int CalculateVolumeCreditsIfComedy(Performance perf)
        {
            return Math.Max(perf.Audience - 30, 0) + (int)Math.Floor((decimal)perf.Audience / 5);
        }
        
        public static int CalculateThisAmountForComedy(Performance perf)
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

        public static int CalculateThisAmountForTragedy(Performance perf)
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

    public class Comedy : Play
    {
        public Comedy(string name) : base(name)
        {
        }
    }
    public class Tragedy : Play
    {
        public Tragedy(string name) : base(name)
        {
        }
    }
}
