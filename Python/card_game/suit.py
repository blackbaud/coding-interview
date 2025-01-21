from enum import Enum


class Suit(Enum):
    """Possible values for a card suit."""
    SPADES = 'S'
    HEARTS = 'H'
    DIAMONDS = 'D'
    CLUBS = 'C'

    def to_short_string(self):
        """Returns an abbreviated string representation of the suit."""
        return self._value_
