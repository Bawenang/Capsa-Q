using System.Collections;
using System.Collections.Generic;

public struct CardElement
{
    public enum Number {
        Unknown = -1,
        Three = 0,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace,
        Two
    }

    public enum Suite {
        Unknown = -1,
        Diamond = 0,
        Club,
        Heart,
        Spade
    }

    public Number CardNumber { get => _number; }
    public Suite CardSuite { get => _suite; }
    public int CardValue { get => _value; }

    private Number _number;
    private Suite _suite;
    private int _value;

    public CardElement(Number number, Suite suite) {
        this._number = number;
        this._suite = suite;
        this._value = CardUtils.CalculateCardValue(number, suite);
    }

    public CardElement(int value) {
        this._number = CardUtils.GetCardNumber(value);
        this._suite = CardUtils.GetCardSuite(value);
        this._value = value;
    }
}
