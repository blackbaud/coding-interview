from card_game.deck import Deck

# Part 1: Create a new deck and deal out all the cards

print("**********")
print("Part 1 - Create a new deck, shuffle, then deal out all the cards")

# Create a new deck
deck = Deck.new_deck()

# TODO: shuffle the deck
print("Shuffling...")

# Deal all the cards
while not deck.empty:
    card = deck.next_card()
    print(f"{card.to_short_string()} - {card}")

print("\n**********\n")
