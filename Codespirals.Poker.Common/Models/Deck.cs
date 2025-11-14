using System.Collections.ObjectModel;

namespace Codespirals.Poker;
public abstract class Deck
{
    internal List<Card> _cardPool = [];
    private List<Card> _discardPile = [];

    public ReadOnlyCollection<Card> CardPool => _cardPool.AsReadOnly();
    public ReadOnlyCollection<Card> Cards => _cardPool.Except(_discardPile).ToList().AsReadOnly();
    public ReadOnlyCollection<Card> DiscardPile => _discardPile.AsReadOnly();

    public Card Draw()
    {
        if (Cards.Count is 0)
            return Card.NoCard();
        var card = Cards.First();
        _discardPile.Add(card);
        return card;
    }
    public Card Draw(byte cardCode)
    {
        var card = Cards.FirstOrDefault(c => c.CardCode == cardCode);
        if (card is not null)
        {
            _discardPile.Add(card);
            return card;
        }
        return Card.NoCard();
    }
    public IEnumerable<Card> Draw(int numberOfCards)
    {
        var cards = Cards.Take(numberOfCards);
        _discardPile.AddRange(cards);
        return cards;
    }
    public void Return(byte cardCode)
    {
        var card = DiscardPile.FirstOrDefault(c => c.CardCode == cardCode);
        if (card is not null)
            _discardPile.Remove(card);
    }
    public IEnumerable<Card> Peek(int numberOfCards) => Cards.Take(numberOfCards);
    public void Shuffle() => _cardPool = [.. _cardPool.Shuffle()];
    public void Order() => _cardPool = [.. _cardPool.OrderBy(c => c.Suit).ThenBy(c => c.Value)];
    public void Reset()
    {
        _discardPile = [];
        Order();
    }
}
