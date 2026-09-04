namespace Blackbaud.Interview.Cards;

/// <summary>
/// A deck of cards
/// </summary>
public class Deck
{
    private readonly Stack<Card> _stackOfCards;
    private readonly Random _random = new();

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

    /// <summary>
    /// Shuffles the deck using the Fisher-Yates algorithm, producing a uniform,
    /// unbiased random ordering of the remaining cards.
    /// </summary>
    /// <param name="times">
    /// The number of shuffle passes to perform. A single Fisher-Yates pass already
    /// yields a uniform permutation, so additional passes do not increase randomness.
    /// </param>
    public void Shuffle(int times = 1)
    {
        for (int t = 0; t < times; t++)
        {
            var cards = _stackOfCards.ToArray();

            for (var i = cards.Length - 1; i > 0; i--)
            {
                var j = _random.Next(i + 1);
                (cards[i], cards[j]) = (cards[j], cards[i]);
            }

            _stackOfCards.Clear();
            foreach (var card in cards)
                _stackOfCards.Push(card);
        }
    }

    /// <summary>
    /// Shuffles the deck by mimicking a human riffle shuffle: the deck is split near
    /// the middle into two halves, which are then interleaved in small random clumps.
    /// A single riffle only partially randomizes the deck, so repeating it (roughly
    /// seven times for a 52-card deck) is recommended for a well-mixed result.
    /// </summary>
    /// <param name="times">The number of riffle shuffles to perform.</param>
    public void MimicHumanShuffle(int times = 1)
    {
        for (int t = 0; t < times; t++)
        {
            var cards = _stackOfCards.ToList();

            int mid = cards.Count / 2 + _random.Next(-2, 3);
            mid = Math.Clamp(mid, 0, cards.Count); // guard against small decks (e.g. after dealing)
            var leftHand = cards.GetRange(0, mid);
            var rightHand = cards.GetRange(mid, cards.Count - mid);

            var mergeSet = new List<Card>();
            int li = 0;
            int ri = 0;
            while (li < leftHand.Count || ri < rightHand.Count)
            {
                if (_random.Next(2) == 0)
                {
                    int leftDrop = _random.Next(1, 4);
                    for (int i = 0; i < leftDrop && li < leftHand.Count; i++)
                    {
                        mergeSet.Add(leftHand[li++]);
                    }

                    int rightDrop = _random.Next(1, 4);
                    for (int i = 0; i < rightDrop && ri < rightHand.Count; i++)
                    {
                        mergeSet.Add(rightHand[ri++]);
                    }
                }
                else
                {
                    int rightDrop = _random.Next(1, 4);
                    for (int i = 0; i < rightDrop && ri < rightHand.Count; i++)
                    {
                        mergeSet.Add(rightHand[ri++]);
                    }

                    int leftDrop = _random.Next(1, 4);
                    for (int i = 0; i < leftDrop && li < leftHand.Count; i++)
                    {
                        mergeSet.Add(leftHand[li++]);
                    }
                }
            }

            _stackOfCards.Clear();
            foreach (Card card in mergeSet)
            {
                _stackOfCards.Push(card);
            }
        }

    }

}
