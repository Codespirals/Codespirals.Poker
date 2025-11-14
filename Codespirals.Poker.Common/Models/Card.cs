namespace Codespirals.Poker;

public readonly struct Card
{
    public byte CardCode { get; init; }
    public byte Value { get; init; }
    public string Name { get; init; }
    public Suit Suit { get; init; }
    public string Emoji { get; init; }

    public Card(byte cardCode)
    {
        if (!cardCode.CheckBitAtPosition(0))
        {
            Suit = Suit.None;
            Value = byte.MinValue;
            CardCode = byte.MinValue;
            Emoji = "?";
            Name = "Invalid Card";
        }
        else if (cardCode.CheckBitAtPosition(7))
        {
            Suit = Suit.None;
            Value = byte.MaxValue & 0b_0000_1111;
            CardCode = byte.MaxValue;
            Emoji = Constants.JOKEREMOJI;
            Name = SpecialCardNames.Joker.ToString();
        }
        else
        {
            Suit = (Suit)((cardCode & 0b_0111_0000) >> 4);
            Value = (byte)(cardCode & 0b_0000_1111);
            CardCode = cardCode;
            Emoji = char.ConvertFromUtf32(Convert.ToInt32("01F0A0", 16) + Value + (((int)Suit) * 16));
            Name = Value is not 1 and < 11 ? Value.ToString() : ((SpecialCardNames)Value).ToString();
        }
    }

    public override readonly string ToString() => $"{Name} of {Suit}";

    public static Card Joker()
        => new()
        {
            CardCode = 144,
            Suit = Suit.None,
            Value = 14,
            Name = SpecialCardNames.Joker.ToString(),
            Emoji = Constants.JOKEREMOJI
        };
}
