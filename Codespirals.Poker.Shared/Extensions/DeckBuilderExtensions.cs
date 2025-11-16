namespace Codespirals.Poker;
public static class DeckBuilderExtensions
{
    public static TDeck WithJokers<TDeck>(this TDeck deck, byte number)
        where TDeck : Deck
    {
        number = Math.Clamp(number, (byte)1, byte.MaxValue);
        for (var i = 0; i < number; i++)
        {
            deck._cardPool.Add(Card.Joker());
        }
        return deck;
    }
    public static TDeck WithFools<TDeck>(this TDeck deck, byte number)
        where TDeck : Deck
    {
        number = Math.Clamp(number, (byte)1, byte.MaxValue);
        for (var i = 0; i < number; i++)
        {
            deck._cardPool.Add(Card.Fool());
        }
        return deck;
    }
    public static TDeck WithAces<TDeck>(this TDeck deck, Suit suit, byte number)
        where TDeck : Deck
    {
        number = Math.Clamp(number, (byte)1, byte.MaxValue);
        for (var i = 0; i < number; i++)
        {
            deck._cardPool.Add(Card.Ace(suit));
        }
        return deck;
    }
    public static TDeck WithKings<TDeck>(this TDeck deck, Suit suit, byte number)
        where TDeck : Deck
    {
        number = Math.Clamp(number, (byte)1, byte.MaxValue);
        for (var i = 0; i < number; i++)
        {
            deck._cardPool.Add(Card.King(suit));
        }
        return deck;
    }
    public static TDeck WithQueens<TDeck>(this TDeck deck, Suit suit, byte number)
        where TDeck : Deck
    {
        number = Math.Clamp(number, (byte)1, byte.MaxValue);
        for (var i = 0; i < number; i++)
        {
            deck._cardPool.Add(Card.Queen(suit));
        }
        return deck;
    }
    public static TDeck WithJacks<TDeck>(this TDeck deck, Suit suit, byte number)
        where TDeck : Deck
    {
        number = Math.Clamp(number, (byte)1, byte.MaxValue);
        for (var i = 0; i < number; i++)
        {
            deck._cardPool.Add(Card.Jack(suit));
        }
        return deck;
    }
    public static TDeck WithNumberedCards<TDeck>(this TDeck deck, Suit suit, byte[] numbers)
        where TDeck : Deck
    {
        foreach (var number in numbers)
        {
            var cardValue = Math.Clamp(number, (byte)1, byte.MaxValue);
            for (var i = 0; i < number; i++)
            {
                deck._cardPool.Add(Card.NumberCard(suit, cardValue));
            }
        }
        return deck;
    }
}
