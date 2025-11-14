using Codespirals.Poker;

var deck = new Deck();

while (true)
{
    var card = deck.Draw();
    Console.WriteLine($"{card} - {card.Emoji}");
    if (deck.Cards.Count == 0)
        break;
}
Console.ReadKey();