namespace Codespirals.Poker;

public class Card
{
    public byte CardCode { get; init; }
    public byte Value { get; init; }
    public string Name { get; init; }
    public Suit Suit { get; init; }
    public string? Emoji { get; init; }

    public Card(): this(byte.MinValue)
    {

    }

    public Card(byte cardCode)
    {
        CardCode = cardCode;
        // bits 4-7 are suit
        Suit = (Suit)(CardCode >> 4);
        // bits 0-3 are value
        Value = (byte)(CardCode & 0b_0000_1111);

        if (Value is byte.MinValue)
        {
            Name = "No Card";
        }
        // joker
        else if (Value is (byte)SpecialCardNames.Joker)
        {
            Name = SpecialCardNames.Joker.ToString();
            Emoji = Constants.JOKEREMOJI;
        }
        // fool
        else if (Value is (byte)SpecialCardNames.Fool)
        {
            Name = SpecialCardNames.Fool.ToString();
            Emoji = Constants.FOOLEMOJI;
        }
        else
        {
            Name = Value is not 1 and < 11 ? Value.ToString() : ((SpecialCardNames)Value).ToString();
            // if the card is of traditinal suits, there's an emoji for it
            if ((byte)Suit is > 0 and < 5)
                Emoji = char.ConvertFromUtf32(Convert.ToInt32("01F0A0", 16) + Value + (((int)Suit) * 16));
        }
    }

    public override string ToString()
    {
        var ofSuit = (byte)Suit > 0 ? $" of {Suit}" : "";
        return $"{Name}{ofSuit}";
    }

    public static Card NoCard()
        => new(0b_0000_0000);
    public static Card Ace(Suit suit)
        => FromSuitAndValue(suit, 0b_0000_0001);
    public static Card NumberCard(Suit suit, byte value)
        => value is > 1 and < 11 ? FromSuitAndValue(suit, value) : NoCard();
    public static Card Jack(Suit suit)
        => FromSuitAndValue(suit, 0b_0000_1011);
    public static Card Queen(Suit suit)
        => FromSuitAndValue(suit, 0b_0000_1100);
    public static Card King(Suit suit)
        => FromSuitAndValue(suit, 0b_0000_1101);
    public static Card Joker()
        => new(0b_0000_1110);
    public static Card Fool()
        => new(0b_0000_1111);

    private static Card FromSuitAndValue(Suit suit, byte value)
        => new((byte)(((int)suit << 4) | value));

}
