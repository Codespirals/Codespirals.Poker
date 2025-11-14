using Codespirals.Poker;

var deck = new EmptyDeck().WithJokers(2).WithAces(Suit.Acorns, 3);
deck.Shuffle();

while (true)
{
    Console.WriteLine("Draw a hand?");
    Console.ReadKey();
    var cards = deck.Draw(5);
    foreach (var card in cards)
    {
        Console.WriteLine($"You drew: {card}");
    }
    Console.WriteLine($"Cards left in the deck: {deck.Cards.Count}");
    if (deck.Cards.Count == 0)
        break;
}
Console.ReadKey();