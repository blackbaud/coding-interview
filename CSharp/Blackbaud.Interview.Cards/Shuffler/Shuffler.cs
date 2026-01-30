namespace Blackbaud.Interview.Cards.Shuffler;

public class FisherYatesShuffler : IShuffler
{
    public void shuffle(IList<Card> cards, int? shuffleRounds = null, int? seed = null)
    {
        if(cards is null) throw new ArgumentNullException(nameof(cards));
        int n=cards.Count;
        Random rand = seed.HasValue ? new Random(seed.Value) : new Random();
        if(shuffleRounds==null)
        {
            for(int i=n-1;i>0;i--)
            {
                int j=rand.Next(i+1);
                (cards[i],cards[j])=(cards[j],cards[i]);
            }
        }
        else
        {
            int rounds=shuffleRounds.Value;
            for(int r = 0; r < rounds; r++)
            {
                int i=rand.Next(n);
                int j=rand.Next(n);
                if(i==j) continue;
                (cards[i],cards[j])=(cards[j],cards[i]);
            }
        }
    }

   
}