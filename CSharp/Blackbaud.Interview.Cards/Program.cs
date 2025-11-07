namespace Blackbaud.Interview.Cards;

public static class Program
{
    static void Main(string[] args)
    {
        // Part 1 Create a new deck and deal out all the cards

        Console.WriteLine("**********");
        Console.WriteLine("Part 1 - Create a new deck, shuffle, then deal out all the cards");

        // Create a new deck
        var deck = Deck.NewDeck();

        // shuffle the deck
        Console.WriteLine("Shuffling...");
        int times = 1;
        if (args != null && args.Length > 0 && int.TryParse(args[0], out var parsed) && parsed > 1)
        {
            times = parsed;
        }
        deck.Shuffle(times);

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
