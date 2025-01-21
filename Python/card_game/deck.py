from card_game.rank import Rank
from card_game.suit import Suit
from card_game.card import Card


class Deck:
    """A deck of cards"""

    def __init__(self, cards: list[Card]):
        self._stack = cards

    @classmethod
    def new_deck(cls):
        """Creates and returns a new deck of cards"""
        cards = []

        for s in list(Suit):
            for r in list(Rank):
                cards.append(Card(r, s))

        return cls(cards)

    @property
    def remaining_cards(self) -> int:
        """The number of remaining cards in the deck"""
        return len(self._stack)

    @property
    def empty(self) -> bool:
        """Returns true if there are no remaining cards in the deck"""
        return self.remaining_cards == 0

    def next_card(self) -> Card:
        """
        Removes the next card from the top of the deck

        :return: The next card from the deck. Returns None if no cards remain.
        """
        if not self.empty:
            return self._stack.pop()
        else:
            return None
