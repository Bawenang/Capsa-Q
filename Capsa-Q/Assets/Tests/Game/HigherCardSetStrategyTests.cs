using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HigherCardSetStrategyTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestHigherOneCardStrategy()
    {
        CardElement[] cards = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                CardElementFactory.Create(CardElement.Number.Six, CardElement.Suite.Spade),
                                CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Diamond),
                                CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Diamond),
                                CardElementFactory.Create(CardElement.Number.Seven, CardElement.Suite.Diamond) };

        var cardElementToCheck = new CardElement[] {CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Diamond) };
        var cardSetToCheck = CardSetFactory.Create(cardElementToCheck);

        var sut = new HigherOneCardStrategy();
        var actualResults = sut.GetHigherSets(cardSetToCheck, cards);

        Assert.AreEqual(3, actualResults.Length);
    }

    [Test]
    public void TestHigherTwoCardsStrategy()
    {
        CardElement[] cards = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                CardElementFactory.Create(CardElement.Number.Six, CardElement.Suite.Spade),
                                CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Diamond),
                                CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Diamond),
                                CardElementFactory.Create(CardElement.Number.Seven, CardElement.Suite.Diamond),
                                CardElementFactory.Create(CardElement.Number.Jack, CardElement.Suite.Spade),
                                CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Spade),
                                CardElementFactory.Create(CardElement.Number.Jack, CardElement.Suite.Diamond) };

        var cardElementToCheck = new CardElement[] {
                        CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Spade),
                        CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Club) };
        var cardSetToCheck = CardSetFactory.Create(cardElementToCheck);

        var sut = new HigherTwoCardsStrategy();
        var actualResults = sut.GetHigherSets(cardSetToCheck, cards);

        Assert.AreEqual(1, actualResults.Length);
    }

    [Test]
    public void TestHigherThreeCardsStrategy()
    {
        CardElement[] cards = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                CardElementFactory.Create(CardElement.Number.Six, CardElement.Suite.Spade),
                                CardElementFactory.Create(CardElement.Number.Jack, CardElement.Suite.Heart),
                                CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Diamond),
                                CardElementFactory.Create(CardElement.Number.Seven, CardElement.Suite.Diamond),
                                CardElementFactory.Create(CardElement.Number.Jack, CardElement.Suite.Spade),
                                CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Spade),
                                CardElementFactory.Create(CardElement.Number.Jack, CardElement.Suite.Diamond),
                                CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Club) };

        var cardElementToCheck = new CardElement[] {
                        CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Spade),
                        CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Club),
                        CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Heart) };
        var cardSetToCheck = CardSetFactory.Create(cardElementToCheck);

        var sut = new HigherThreeCardsStrategy();
        var actualResults = sut.GetHigherSets(cardSetToCheck, cards);

        Assert.AreEqual(1, actualResults.Length);
    }
}
