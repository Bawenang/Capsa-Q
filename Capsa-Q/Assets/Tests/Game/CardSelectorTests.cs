using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CardSelectorTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestCardSelectorTests_ShouldGetTheLowestCard_FromHigherCardsThanInput()
    {
        CardElement[] inputCards = { CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Diamond), 
                                     CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Club),
                                     CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Spade)};
        var input = CardSetFactory.Create(inputCards);
        CardElement[] cardsToSelect = {
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Club),
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Spade),
            CardElementFactory.Create(CardElement.Number.Seven, CardElement.Suite.Heart),
            CardElementFactory.Create(CardElement.Number.Seven, CardElement.Suite.Diamond),
            CardElementFactory.Create(CardElement.Number.Jack, CardElement.Suite.Diamond),
            CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Diamond),
            CardElementFactory.Create(CardElement.Number.Ace, CardElement.Suite.Diamond),
            CardElementFactory.Create(CardElement.Number.Six, CardElement.Suite.Spade),
            CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Heart)
        };
        var mockedReturnValues = new CardSet[] {
            CreateFullHouse(),
            CreateStraight(),
            CreateFlush()
        };
        var strategy = new MockHigherCardsStrategy(getHigherSetsReturnValue: mockedReturnValues);
        var sut = new CardSelector(new HigherCardSetStrategy[] { strategy });

        var actualResult = sut.SelectCardSet(input, cardsToSelect);

        Assert.True(strategy.isGetHigherSetsCalled);
        Assert.AreEqual(CardSetType.Straight, actualResult.SetType);
    }

    [Test]
    public void TestCardSelectorTests_WhenPreviousStrategyReturnInvalidOrEmpty_ShouldIterateToNextStrategy()
    {
        CardElement[] inputCards = { CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Diamond), 
                                     CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Club),
                                     CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Spade)};
        var input = CardSetFactory.Create(inputCards);
        CardElement[] cardsToSelect = {
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Club),
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Spade),
            CardElementFactory.Create(CardElement.Number.Seven, CardElement.Suite.Heart),
            CardElementFactory.Create(CardElement.Number.Seven, CardElement.Suite.Diamond),
            CardElementFactory.Create(CardElement.Number.Jack, CardElement.Suite.Diamond),
            CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Diamond),
            CardElementFactory.Create(CardElement.Number.Ace, CardElement.Suite.Diamond),
            CardElementFactory.Create(CardElement.Number.Six, CardElement.Suite.Spade),
            CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Heart)
        };
        var strategy1 = new MockHigherCardsStrategy(new CardSet[] { CardSetFactory.Invalid });
        var strategy2 = new MockHigherCardsStrategy(Array.Empty<CardSet>());
        var mockedReturnValues = new CardSet[] {
            CreateFullHouse(),
            CreateStraight(),
            CreateFlush()
        };
        var strategy3 = new MockHigherCardsStrategy(mockedReturnValues);
        var sut = new CardSelector(new HigherCardSetStrategy[] { strategy1, strategy2, strategy3 });

        var actualResult = sut.SelectCardSet(input, cardsToSelect);

        Assert.True(strategy1.isGetHigherSetsCalled);
        Assert.True(strategy2.isGetHigherSetsCalled);
        Assert.True(strategy3.isGetHigherSetsCalled);
        Assert.AreEqual(CardSetType.Straight, actualResult.SetType);
    }

    private CardSet CreateFullHouse() {
        CardElement[] cards = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Club),
                                CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Spade),
                                CardElementFactory.Create(CardElement.Number.Seven, CardElement.Suite.Heart),
                                CardElementFactory.Create(CardElement.Number.Seven, CardElement.Suite.Diamond) };
        return CardSetFactory.Create(cards);
    }

    private CardSet CreateFlush() {
        CardElement[] cards = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                CardElementFactory.Create(CardElement.Number.Jack, CardElement.Suite.Diamond),
                                CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Diamond),
                                CardElementFactory.Create(CardElement.Number.Ace, CardElement.Suite.Diamond),
                                CardElementFactory.Create(CardElement.Number.Seven, CardElement.Suite.Diamond) };
        return CardSetFactory.Create(cards);
    }

    private CardSet CreateStraight() {
        CardElement[] cards = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                CardElementFactory.Create(CardElement.Number.Six, CardElement.Suite.Spade),
                                CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Diamond),
                                CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Heart),
                                CardElementFactory.Create(CardElement.Number.Seven, CardElement.Suite.Diamond) };
        return CardSetFactory.Create(cards);
    }

}

public class MockHigherCardsStrategy: HigherCardSetStrategy
{
    public bool isGetHigherSetsCalled = false;
    private CardSet[] getHigherSetsReturnValue;

    public MockHigherCardsStrategy(CardSet[] getHigherSetsReturnValue)
    {
        this.getHigherSetsReturnValue = getHigherSetsReturnValue;
    }

    public CardSet[] GetHigherSets(CardSet cardSet, CardElement[] cardElements)
    {
        isGetHigherSetsCalled = true;
        return getHigherSetsReturnValue;
    }
}