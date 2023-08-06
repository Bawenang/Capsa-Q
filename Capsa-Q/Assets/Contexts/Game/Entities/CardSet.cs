public struct CardSet
{
    public CardsType Type { get => type; }
    public CardElement[] Cards { get => cards; }
    public CardElement HighestCard { get => highestCard; }

    private CardsType type;
    private CardElement[] cards;
    private CardElement highestCard;

    public CardSet(CardsType type, CardElement[] cards, CardElement highestCard) {
        this.type = type;
        this.cards = cards;
        this.highestCard = highestCard;
    }
}