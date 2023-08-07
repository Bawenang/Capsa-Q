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

    public Number CardNumber { get => number; }
    public Suite CardSuite { get => suite; }
    public int CardValue { get => value; }

    private Number number;
    private Suite suite;
    private int value;

    public CardElement(Number number, Suite suite, int value) {
        this.number = number;
        this.suite = suite;
        this.value = value;
    }
}
