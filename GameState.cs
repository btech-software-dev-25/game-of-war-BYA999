
namespace GameOfWar
{
    public class GameState
    {
        public Deck CardDeck { get; set; }

        public Deck PlayerDeck { get; set; }

        public Deck ComputerDeck { get; set; }

        public Deck TableDeck { get; set; }

        public string Winner { get; set; }

        public GameState()
        {
            Winner = "";
            CardDeck = new Deck();
            PlayerDeck = new Deck(isEmptyDeck: true);
            ComputerDeck = new Deck(isEmptyDeck: true);
            TableDeck = new Deck(isEmptyDeck: true);
        }
    }
}
