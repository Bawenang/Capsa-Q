public struct CardSet
{
    public CardSetType SetType { get => setType; }
    public CardElement[] Cards { get => cards; }
    public CardElement HighestCard { get => highestCard; }

    private CardSetType setType;
    private CardElement[] cards;
    private CardElement highestCard;

    public CardSet(CardSetType setType, CardElement[] cards, CardElement highestCard) 
    {
        this.setType = setType;
        this.cards = cards;
        this.highestCard = highestCard;
    }
}