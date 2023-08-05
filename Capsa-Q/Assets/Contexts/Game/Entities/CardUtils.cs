using System;

public class CardUtils
{
    public static int CalculateCardValue(CardElement.Number number, CardElement.Suite suite) {
        if(number == CardElement.Number.Unknown || suite == CardElement.Suite.Unknown) { 
            return -1; 
        }
        return ((int)number * 4) + (int)suite;
    }

    public static CardElement.Number GetCardNumber(int value) {
        if(value < 0 || value >= 52) { return CardElement.Number.Unknown; }
        int numberValue = (value / 4);
        return (CardElement.Number)numberValue;
    }

    public static CardElement.Suite GetCardSuite(int value) {
        if(value < 0 || value >= 52) { return CardElement.Suite.Unknown; }
        int suiteValue = (value % 4);
        return (CardElement.Suite)suiteValue;
    }
    public static bool IsHigherThan(CardElement element, CardElement comparator) {
        return element.CardValue > comparator.CardValue;
    }
}
