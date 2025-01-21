from enum import Enum


class Rank(Enum):
    """Possible values for a card rank."""
    ACE = 'A'
    TWO = '2'
    THREE = '3'
    FOUR = '4'
    FIVE = '5'
    SIX = '6'
    SEVEN = '7'
    EIGHT = '8'
    NINE = '9'
    TEN = '10'
    JACK = 'J'
    QUEEN = 'Q'
    KING = 'K'

    def to_short_string(self):
        """Returns an abbreviated string representation of the suit."""
        return self._value_
