using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CardValidationTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestOneCardValidationStrategy_CardValidation()
    {
        var sut = new OneCardValidationStrategy();
        // Use the Assert class to test conditions
        CardElement[] validCards = {new CardElement(0)};
        Assert.AreEqual(CardsType.Singular, sut.ValidateType(validCards));

        CardElement[] invalidCards1 = {new CardElement(0), new CardElement(1), new CardElement(2)};
        Assert.AreEqual(CardsType.Invalid, sut.ValidateType(invalidCards1));

        CardElement[] invalidCards2 = {};
        Assert.AreEqual(CardsType.Invalid, sut.ValidateType(invalidCards2));
    }

    [Test]
    public void TestTwoCardsValidationStrategy_CardValidation()
    {
        var sut = new TwoCardsValidationStrategy();
        // Use the Assert class to test conditions
        CardElement[] validCards = { new CardElement(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                     new CardElement(CardElement.Number.Three, CardElement.Suite.Spade) };
        Assert.AreEqual(CardsType.Pairs, sut.ValidateType(validCards));

        CardElement[] invalidCards1 = { new CardElement(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                        new CardElement(CardElement.Number.Four, CardElement.Suite.Diamond) };
        Assert.AreEqual(CardsType.Invalid, sut.ValidateType(invalidCards1));

        CardElement[] invalidCards2 = { new CardElement(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                        new CardElement(CardElement.Number.Three, CardElement.Suite.Spade),
                                        new CardElement(CardElement.Number.Three, CardElement.Suite.Heart) };
        Assert.AreEqual(CardsType.Invalid, sut.ValidateType(invalidCards2));

        CardElement[] invalidCards3 = {};
        Assert.AreEqual(CardsType.Invalid, sut.ValidateType(invalidCards3));
    }

    [Test]
    public void TestThreeCardsValidationStrategy_CardValidation()
    {
        var sut = new ThreeCardsValidationStrategy();
        // Use the Assert class to test conditions
        CardElement[] validCards = { new CardElement(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                     new CardElement(CardElement.Number.Three, CardElement.Suite.Spade),
                                     new CardElement(CardElement.Number.Three, CardElement.Suite.Club) };
        Assert.AreEqual(CardsType.Triplets, sut.ValidateType(validCards));

        CardElement[] invalidCards1 = { new CardElement(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                        new CardElement(CardElement.Number.Four, CardElement.Suite.Diamond) };
        Assert.AreEqual(CardsType.Invalid, sut.ValidateType(invalidCards1));

        CardElement[] invalidCards2 = { new CardElement(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                        new CardElement(CardElement.Number.Four, CardElement.Suite.Spade),
                                        new CardElement(CardElement.Number.Five, CardElement.Suite.Heart) };
        Assert.AreEqual(CardsType.Invalid, sut.ValidateType(invalidCards2));

        CardElement[] invalidCards3 = {};
        Assert.AreEqual(CardsType.Invalid, sut.ValidateType(invalidCards3));
    }

    [Test]
    public void TestStraightFlushValidationStrategy_CardValidation()
    {
        var sut = new StraightFlushValidationStrategy();
        // Use the Assert class to test conditions
        CardElement[] validCards = { new CardElement(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                     new CardElement(CardElement.Number.Six, CardElement.Suite.Spade),
                                     new CardElement(CardElement.Number.Five, CardElement.Suite.Club),
                                     new CardElement(CardElement.Number.Four, CardElement.Suite.Heart),
                                     new CardElement(CardElement.Number.Seven, CardElement.Suite.Spade) };
        Assert.AreEqual(CardsType.Straight, sut.ValidateType(validCards));

        CardElement[] validCards2 = { new CardElement(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                      new CardElement(CardElement.Number.Ace, CardElement.Suite.Diamond),
                                      new CardElement(CardElement.Number.King, CardElement.Suite.Diamond),
                                      new CardElement(CardElement.Number.Four, CardElement.Suite.Diamond),
                                      new CardElement(CardElement.Number.Five, CardElement.Suite.Diamond) };
        Assert.AreEqual(CardsType.Flush, sut.ValidateType(validCards2));

        CardElement[] validCards3 = { new CardElement(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                      new CardElement(CardElement.Number.Six, CardElement.Suite.Diamond),
                                      new CardElement(CardElement.Number.Five, CardElement.Suite.Diamond),
                                      new CardElement(CardElement.Number.Four, CardElement.Suite.Diamond),
                                      new CardElement(CardElement.Number.Seven, CardElement.Suite.Diamond) };
        Assert.AreEqual(CardsType.StraightFlush, sut.ValidateType(validCards3));

        CardElement[] invalidCards1 = { new CardElement(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                        new CardElement(CardElement.Number.Four, CardElement.Suite.Diamond) };
        Assert.AreEqual(CardsType.Invalid, sut.ValidateType(invalidCards1));

        CardElement[] invalidCards2 = { new CardElement(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                        new CardElement(CardElement.Number.Four, CardElement.Suite.Spade),
                                        new CardElement(CardElement.Number.Five, CardElement.Suite.Heart) };
        Assert.AreEqual(CardsType.Invalid, sut.ValidateType(invalidCards2));

        CardElement[] invalidCards3 = { new CardElement(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                        new CardElement(CardElement.Number.Eight, CardElement.Suite.Spade),
                                        new CardElement(CardElement.Number.Five, CardElement.Suite.Heart),
                                        new CardElement(CardElement.Number.Jack, CardElement.Suite.Club) };
        Assert.AreEqual(CardsType.Invalid, sut.ValidateType(invalidCards3));

        CardElement[] invalidCards4 = {};
        Assert.AreEqual(CardsType.Invalid, sut.ValidateType(invalidCards4));
    }

    [Test]
    public void TestFivePairsCardsValidationStrategy_CardValidation()
    {
        var sut = new FivePairsCardsValidationStrategy();
        // Use the Assert class to test conditions
        CardElement[] validCards = { new CardElement(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                     new CardElement(CardElement.Number.Ace, CardElement.Suite.Diamond),
                                     new CardElement(CardElement.Number.Three, CardElement.Suite.Spade),
                                     new CardElement(CardElement.Number.Ace, CardElement.Suite.Heart),
                                     new CardElement(CardElement.Number.Ace, CardElement.Suite.Club) };
        Assert.AreEqual(CardsType.FullHouse, sut.ValidateType(validCards));

        CardElement[] validCards2 = { new CardElement(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                      new CardElement(CardElement.Number.Three, CardElement.Suite.Club),
                                      new CardElement(CardElement.Number.Three, CardElement.Suite.Spade),
                                      new CardElement(CardElement.Number.Three, CardElement.Suite.Heart),
                                      new CardElement(CardElement.Number.Jack, CardElement.Suite.Club) };
        Assert.AreEqual(CardsType.Quads, sut.ValidateType(validCards2));

        CardElement[] invalidCards1 = { new CardElement(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                        new CardElement(CardElement.Number.Ace, CardElement.Suite.Diamond),
                                        new CardElement(CardElement.Number.Three, CardElement.Suite.Spade),
                                        new CardElement(CardElement.Number.Ace, CardElement.Suite.Heart),
                                        new CardElement(CardElement.Number.Jack, CardElement.Suite.Club) };
        Assert.AreEqual(CardsType.Invalid, sut.ValidateType(invalidCards1));

        CardElement[] invalidCards2 = { new CardElement(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                        new CardElement(CardElement.Number.Four, CardElement.Suite.Diamond) };
        Assert.AreEqual(CardsType.Invalid, sut.ValidateType(invalidCards2));

        CardElement[] invalidCards3 = { new CardElement(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                        new CardElement(CardElement.Number.Four, CardElement.Suite.Spade),
                                        new CardElement(CardElement.Number.Five, CardElement.Suite.Heart) };
        Assert.AreEqual(CardsType.Invalid, sut.ValidateType(invalidCards3));

        CardElement[] invalidCards4 = {};
        Assert.AreEqual(CardsType.Invalid, sut.ValidateType(invalidCards4));
    }
}
