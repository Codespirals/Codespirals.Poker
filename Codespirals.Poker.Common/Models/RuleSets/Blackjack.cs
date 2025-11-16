namespace Codespirals.Poker;
public class Blackjack
{
    public PokerDeck Deck { get; private set; } = new();
    public Hand DealerHand { get; private set; } = new();
    public Hand PlayerHand { get; private set; } = new();
    public bool GameEnded { get; private set; }
    public int DealerScore => EvaluateHand(DealerHand);
    public int PlayerScore => EvaluateHand(PlayerHand);
    public Blackjack()
    {
        
    }

    public void Start()
    {
        Deck.Shuffle();
        DealerHand.Add(Deck.Draw(2));
        PlayerHand.Add(Deck.Draw(2));
    }

    public void Reset()
    {
        Deck.Reset();
        PlayerHand = new();
        DealerHand = new();
        GameEnded = false;
    }
    public string Draw()
    {
        if (GameEnded)
            return "Reset and start a new game.";
        DealerDraw();
        PlayerHand.Add(Deck.Draw());
        var winnerFound = DeterimneWinner(DealerScore, PlayerScore);
        if (winnerFound.Win is true)
            GameEnded = true;
        return winnerFound.Message;
    }
    public string Stay()
    {
        if (GameEnded)
            if (GameEnded)
                return "Reset and start a new game.";
        while (DealerScore < 17)
            DealerDraw();
        GameEnded = true;
        var winnerFound = DeterimneWinner(DealerScore, PlayerScore);
        if (winnerFound.Win is null)
        {
            return (DealerScore - PlayerScore) switch
            {
                < 0 => "You win!",
                > 0 => "You lose...!",
                _ => "A draw!",
            };
        }
        return winnerFound.Message;
    }
    public int EvaluateHand(Hand hand)
    {
        var value = 0;
        foreach (var card in hand.Cards)
        {
            switch (card.Value)
            {
                case 1:
                    value += 11;
                    break;
                case > 10:
                    value += 10;
                    break;
                default:
                    value += card.Value;
                    break;
            }
        }
        value = ReduceAcesIfOver(value, hand);
        return value;
    }

    private void DealerDraw()
    {
        if (DealerScore < 18)
            DealerHand.Add(Deck.Draw());
    }

    private (bool? Win, string Message) DeterimneWinner(int valueDealer, int valuePlayer)
    {
        switch (valuePlayer)
        {
            case 21:
                return (true, "Wow! Blackjack!");
            case > 21:
                return (true, "You went over! You lose...");
            default:
                break;
        }
        switch (valueDealer)
        {
            case 21:
                return (true, "Dealer Blackjack... You lose.");
            case > 21:
                return (true, "Dealer went over! You win!");
            default:
                break;
        }
        return (null, "Another hit?");
    }

    private static int ReduceAcesIfOver(int value, Hand hand)
    {
        var aces = hand.Cards.Where(c => c.Value == 1);
        foreach (var ace in aces)
        {
            if (value < 22)
                return value;
            value -= 10;
        }
        return value;
    }
}
