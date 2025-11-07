namespace Blackbaud.Interview.Cards;

/// <summary>
/// A deck of cards
/// </summary>
public class Deck
{
    private readonly Stack<Card> _stackOfCards;
    private readonly List<Card> _cards;

    /// <summary>
    /// Private constructor for a new deck of <paramref name="cards"/>.
    /// Use Deck.NewDeck() static factory method.
    /// </summary>
    /// <param name="cards"></param>
    private Deck(IEnumerable<Card> cards)
    {
        _stackOfCards = new Stack<Card>(cards);
        _cards = new List<Card>(cards);
    }

    /// <summary>
    /// Creates and returns a new deck of cards.
    /// </summary>
    /// <returns></returns>
    public static Deck NewDeck()
    {
        return new Deck(
            Enum.GetValues<Suit>().SelectMany(suit =>
                Enum.GetValues<Rank>().Select(rank =>
                    new Card(rank, suit))
        ));
    }

    /// <summary>
    /// The number of remaining cards in the deck
    /// </summary>
    public int RemainingCards => _stackOfCards.Count;

    /// <summary>
    /// Returns true if there are no remaining cards in the deck
    /// </summary>
    public bool Empty => RemainingCards == 0;

    /// <summary>
    /// Removes the next card from the deck.
    /// </summary>
    /// <returns>The next card from the deck.
    /// Returns null if no cards remain.</returns>
    public Card NextCard()
    {
        if (!Empty)
        {
            var nextCard = _stackOfCards.Pop();
            return nextCard;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Shuffles the deck in-place. Can repeat multiple times.
    /// </summary>
    /// <param name="times">Number of times to shuffle. Must be >= 1.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when times &lt;= 0.</exception>
    public void Shuffle(int times)
    {
        if (times <= 0) throw new ArgumentOutOfRangeException("shuffle time should be >= 1");

        var rnd = new Random();
        for (int t = 0; t < times; t++)
        {
            for (int i = 0; i < _cards.Count; i++)
            {
                int j = rnd.Next(i + 1);
                var temp = _cards[i];
                _cards[i] = _cards[j];
                _cards[j] = temp;
            }
        }
        _stackOfCards.Clear();
        for (int i = _cards.Count - 1; i >= 0; i--)
        {
            _stackOfCards.Push(_cards[i]);
        }
    }

    /// <summary>
    /// Returns current order of cards (without modifying the deck). Primarily for test verification.
    /// </summary>
    public List<Card> GetCards() => _cards;

}
