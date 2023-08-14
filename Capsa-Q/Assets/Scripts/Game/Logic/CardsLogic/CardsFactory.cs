using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardElementFactory {
    public static CardElement Unknown = CreateInvalidImpl();
    public static CardElement Create(CardElement.Number number, CardElement.Suite suite) {
        return new CardElement(number, 
                               suite, 
                               CardUtils.CalculateCardValue(number, suite));
    }

    public static CardElement Create(int value) {
        return new CardElement(CardUtils.GetCardNumber(value),
                               CardUtils.GetCardSuite(value),
                               value);
    }

    private static CardElement CreateInvalidImpl() {
        return Create(CardElement.Number.Unknown, CardElement.Suite.Unknown);
    }
}

public class CardSetFactory {
    public static CardSet Invalid = CreateInvalidImpl();
    public static CardSet Create(CardElement[] fromCards) {
        CardSetType type = CardsValidator.Instance.ValidateType(fromCards);
        if(type == CardSetType.Invalid) return CreateInvalid();
        else return CreateImpl(fromCards, type);
    }

    public static CardSet CreateInvalid() {
        return Invalid;
    }

    private static CardSet CreateInvalidImpl() {
        CardElement invalidCard = CardElementFactory.Create(CardElement.Number.Unknown, CardElement.Suite.Unknown);
        CardSet invalidSet = new CardSet(CardSetType.Invalid,
                                         Array.Empty<CardElement>(),
                                         invalidCard);
        return invalidSet;
    }

    private static CardSet CreateImpl(CardElement[] fromCards, CardSetType setType) {
        CardElement[] sortedCards = fromCards;
        CardUtils.SortCardsDescending(ref sortedCards);
        CardElement highest = sortedCards[0];
        CardSet cardSet = new CardSet(setType, sortedCards, highest);
        return cardSet;
    }
}