namespace TheatricalPlayersRefactoringKata
{
    public class Play
    {
        private string _name;

        public string Name { get => _name; set => _name = value; }

        public Play(string name) {
            this._name = name;
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
