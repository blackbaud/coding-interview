using System.Linq;
using System;
using Xunit;

namespace Blackbaud.Interview.Cards.Tests;
public class DeckTests
{
    [Fact]
    public void CanCreateANewDeck()
    {
        var deck = Deck.NewDeck();
        Assert.Equal(52, deck.RemainingCards);
    }

    [Fact]
    public void ShuffleChangesOrder()
    {
        var deck = Deck.NewDeck();
        var original = deck.GetCards().Select(s => s.ToShortString()).ToList();
        deck.Shuffle(1);
        var changed = deck.GetCards().Select(s => s.ToShortString()).ToList();
        var res1 = string.Join(",", original);
        var res2 = string.Join(",", changed);
        Assert.NotEqual(original, changed);
    }

    [Fact]
    public void ShuffleMustBePositive()
    {
        var deck = Deck.NewDeck();
        Assert.Throws<ArgumentOutOfRangeException>(() => deck.Shuffle(-1));
    }

    [Fact]
    public void MultipleShufflesProduceDifferentOrders()
    {
        var deck = Deck.NewDeck();
        deck.Shuffle(1);
        var first = deck.GetCards().Select(c => c.ToShortString()).ToList();
        deck.Shuffle(1);
        var second = deck.GetCards().Select(c => c.ToShortString()).ToList();
        Assert.NotEqual(string.Join(",", first), string.Join(",", second));
    }

}
