namespace Blackbaud.Interview.Cards;

public static class Program
{
    static void Main()
    {
        // Part 1 Create a new deck and deal out all the cards

        Console.WriteLine("**********");
        Console.WriteLine("Part 1 - Create a new deck, shuffle, then deal out all the cards");

        // Create a new deck
        var deck = Deck.NewDeck();

        // TODO: shuffle the deck
        Console.WriteLine("Shuffling...");

        // Deal all the cards
        while (!deck.Empty)
        {
            var card = deck.NextCard();
            Console.WriteLine($"{card.ToShortString()} - {card}");
        }

        Console.WriteLine();
        Console.WriteLine("**********");
        Console.WriteLine();
    }
}
