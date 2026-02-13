using System;
using System.Collections.Generic;
using System.Linq;

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
         /// <summary>
        /// Shuffles the deck a given number of times and returns a new shuffled deck.
        /// </summary>
        public Deck Shuffle(int times)
        {
            if (times <= 0)
                throw new ArgumentException("Number of shuffles must be greater than zero.");

            var cards = _stackOfCards.ToList();

            var random = new Random();

            for (int t = 0; t < times; t++)
            {
                for (int i = cards.Count - 1; i > 0; i--)
                {
                    int j = random.Next(i + 1);

                    var temp = cards[i];
                    cards[i] = cards[j];
                    cards[j] = temp;
                }
            }

            return new Deck(cards);
        }

    }

}
