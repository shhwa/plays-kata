using System;

namespace TheatricalPlayersRefactoringKata;

public class Comedy : Play
{
    public Comedy(string name) : base(name)
    {
    }

    public override int CalculateVolumeCredits(Performance perf)
    {
        return Math.Max(perf.Audience - 30, 0) + (int)Math.Floor((decimal)perf.Audience / 5);
    }

    public override int CalculateAmount(Performance perf)
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
}