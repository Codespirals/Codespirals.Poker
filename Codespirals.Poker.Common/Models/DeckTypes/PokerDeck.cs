namespace Codespirals.Poker;
public class PokerDeck : Deck
{
    public PokerDeck(int number = 1)
    {
        number = Math.Clamp(number, 1, byte.MaxValue);
        for (var s = 1; s < 5; s++)
        {
            for (var cv = 1; cv < 14; cv++)
            {
                for (var i = 0; i < number; i++)
                {
                    _cardPool.Add(new((byte)((s * 16) + cv)));
                }
            }
        }
    }
}
