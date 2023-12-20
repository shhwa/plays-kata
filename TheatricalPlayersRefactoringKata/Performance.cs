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
            if (Play is Comedy)
            {
                return Play.CalculateVolumeCreditsIfComedy(this);
            }
            return Play.CalculateVolumeCreditsIfTragedy(this);
        }

        public int CalculateAmountForPerformance()
        {
            int thisAmount;
            switch (Play)
            {
                case Tragedy:
                    thisAmount = Play.CalculateThisAmountForTragedy(this);
                    break;
                case Comedy:
                    thisAmount = Play.CalculateThisAmountForComedy(this);
                    break;
                default:
                    throw new Exception("unknown type: " + Play.GetType().Name);
            }

            return thisAmount;
        }
    }
}
