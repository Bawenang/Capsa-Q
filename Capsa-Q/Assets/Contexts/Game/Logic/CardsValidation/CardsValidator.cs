public class CardsValidator
{
    private CardsValidationStrategy[] strategies;
    public CardsValidator(CardsValidationStrategy[] strategies) {
        this.strategies = strategies;
    }

    public CardsType ValidateType(CardElement[] cards) {
        for(int i = 0; i < strategies.Length; i++) {
            var cardsType = strategies[i].ValidateType(cards);
            if (cardsType != CardsType.Invalid) return cardsType;
        }
        return CardsType.Invalid;
    }
}
