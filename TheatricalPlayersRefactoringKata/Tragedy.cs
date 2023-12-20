using System;

namespace TheatricalPlayersRefactoringKata;

public class Tragedy : Play
{
    public Tragedy(string name) : base(name)
    {
    }

    public override int CalculateVolumeCredits(Performance perf)
    {
        return Math.Max(perf.Audience - 30, 0);
    }

    public override int CalculateAmount(Performance perf)
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