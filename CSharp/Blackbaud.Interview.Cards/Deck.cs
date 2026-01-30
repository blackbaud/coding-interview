namespace Blackbaud.Interview.Cards;

/// <summary>
/// A deck of cards
/// </summary>
public class Deck
{
    private readonly Stack<Card> _stackOfCards;

    /// <summary>
    /// Private constructor for a new deck of <paramref name="cards"/>.
    /// Use Deck.NewDeck() static factory method.
    /// </summary>
    /// <param name="cards"></param>
    private Deck(IEnumerable<Card> cards)
    {
        _stackOfCards = new Stack<Card>(cards);
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
    public void ShuffleCards(IShuffler shuffler, int? shuffleRounds = null, int? seed = null)
    {
        if(shuffler is null) throw new ArgumentNullException(nameof(shuffler));
        var cards=_stackOfCards.Reverse().ToList();
        shuffler.shuffle(cards,shuffleRounds,seed);
        _stackOfCards.Clear();
        foreach(var card in cards)
        {
            _stackOfCards.Push(card);
        }
    }

}
