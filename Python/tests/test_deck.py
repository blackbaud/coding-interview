import unittest

from card_game.deck import Deck
from card_game.rank import Rank
from card_game.suit import Suit


class TestDeckMethods(unittest.TestCase):

    def test_new_deck(self):
        new_deck = Deck.new_deck()

        self.assertEqual(new_deck.remaining_cards, 52)
        self.assertEqual(new_deck.empty, False)

        top_card = new_deck.next_card()

        self.assertEqual(top_card.rank, Rank.KING)
        self.assertEqual(top_card.suit, Suit.CLUBS)


if __name__ == '__main__':
    # Execute tests by running "python -m unittest" from parent directory
    unittest.main()
