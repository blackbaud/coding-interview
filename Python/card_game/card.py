from card_game.rank import Rank
from card_game.suit import Suit


class Card:
    """A single card, with a suit and rank"""

    def __init__(self, rank: Rank, suit: Suit):
        self._rank = rank
        self._suit = suit

    @property
    def rank(self):
        return self._rank

    @property
    def suit(self):
        return self._suit

    def __str__(self):
        return f"{self._rank.name} of {self._suit.name}"

    def to_short_string(self):
        """Returns an abbreviated string representation of the suit."""
        return f"{self._rank.to_short_string()}{self._suit.to_short_string()}"
