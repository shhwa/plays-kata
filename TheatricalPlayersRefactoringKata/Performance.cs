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
            return Play.CalculateVolumeCredits(this);
        }

        public int CalculateAmountForPerformance()
        {
            return Play.CalculateAmount(this);
        }
    }
}
