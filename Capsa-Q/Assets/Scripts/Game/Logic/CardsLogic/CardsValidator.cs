public class CardsValidator
{
    private static CardsValidator instance = null;
    private CardsValidationStrategy[] strategies;

    public static CardsValidator Instance {
        get {
            if(instance == null) {
                CardsValidationStrategy[] strategies = { 
                    new StraightFlushValidationStrategy(),
                    new FivePairsCardsValidationStrategy(),
                    new ThreeCardsValidationStrategy(),
                    new TwoCardsValidationStrategy(),
                    new OneCardValidationStrategy()
                };

                instance = new CardsValidator(strategies);
            }
            return instance;
        }
    }
    public CardsValidator(CardsValidationStrategy[] strategies) {
        this.strategies = strategies;
    }

    public CardSetType ValidateType(CardElement[] cards) {
        for(int i = 0; i < strategies.Length; i++) {
            var cardsType = strategies[i].ValidateType(cards);
            if (cardsType != CardSetType.Invalid) return cardsType;
        }
        return CardSetType.Invalid;
    }
}
