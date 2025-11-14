using System.Collections.ObjectModel;

namespace Codespirals.Poker;
public class Deck
{
    private List<Card> _initialCards = [];
    private List<Card> _spentCards = [];

    public ReadOnlyCollection<Card> InitialCards => _initialCards.AsReadOnly();
    public ReadOnlyCollection<Card> Cards => _initialCards.Except(_spentCards).ToList().AsReadOnly();
    public ReadOnlyCollection<Card> SpentCards => _spentCards.AsReadOnly();

    public Deck()
    {

    }
    public void Shuffle() => _initialCards = [.. _initialCards.Shuffle()];
    public void Restart()
    {
        _spentCards = [];
        _initialCards = [.. _initialCards.OrderBy(c => c.Suit).ThenBy(c => c.Value)];
    }
    public Card Draw()
    {
        var card = Cards.First();
        _spentCards.Add(card);
        return card;
    }
    public IEnumerable<Card> Draw(int number)
    {
        var cards = Cards.Take(number);
        _spentCards.AddRange(cards);
        return cards;
    }

    public static Deck Standard(byte withJokers = 0)
    {
        var deck = new Deck();
        for (var s = 0; s < 4; s++)
        {
            for (var cv = 1; cv < 14; cv++)
            {
                deck._initialCards.Add(new((byte)((s * 16) + cv)));
            }
        }
        for (var i = 0; i < withJokers; i++)
        {
            deck._initialCards.Add(Card.Joker());
        }
        return deck;
    }
    public static Deck MultipleStandard(int number, byte withJokers = 0)
    {
        number = Math.Clamp(number, 1, byte.MaxValue);
        var deck = new Deck();
        for (var s = 0; s < 4 * number; s++)
        {
            for (var cv = 1; cv < 14; cv++)
            {
                deck._initialCards.Add(new((byte)((cv * 10) + s)));
            }
        }
        return deck;
    }
}
