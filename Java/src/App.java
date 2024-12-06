public class App {
    public static void main(String[] args) throws Exception {
            // Part 1 Create a new deck and deal out all the cards
            System.out.println("**********");
            System.out.println("Part 1 - Create a new deck, shuffle, then deal out all the cards");

            // Create a new deck
            Deck deck = Deck.newDeck();

            // TODO: shuffle the deck
            System.out.println("Shuffling...");
            deck.shuffle();

            // Deal all the cards
            while (deck.isEmpty() == false)
            {
                Card card = deck.nextCard();
                System.out.println(String.format("%s - %s", card.toShortString(), card));
            }

            System.out.println();
            System.out.println("**********");
            System.out.println();
    }
}
