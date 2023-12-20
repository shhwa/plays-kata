namespace TheatricalPlayersRefactoringKata
{
    public abstract class Play
    {
        private string _name;

        public string Name { get => _name; set => _name = value; }

        public Play(string name) {
            this._name = name;
        }
        public abstract int CalculateVolumeCredits(Performance perf);
        public abstract int CalculateAmount(Performance perf);
    }
}
