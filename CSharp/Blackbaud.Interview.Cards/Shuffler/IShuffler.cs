namespace Blackbaud.Interview.Cards.Shuffler;

public interface IShuffler
{
    void shuffle(IList<Card> cards,int?shuffleRounds=null,int?seed=null);
}