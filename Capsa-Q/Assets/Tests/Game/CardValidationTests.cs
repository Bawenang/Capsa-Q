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
        CardElement[] validCards = { CardElementFactory.Create(0) };
        Assert.AreEqual(CardSetType.Singular, sut.ValidateType(validCards));

        CardElement[] invalidCards1 = { CardElementFactory.Create(0), 
                                        CardElementFactory.Create(1), 
                                        CardElementFactory.Create(2) };
        Assert.AreEqual(CardSetType.Invalid, sut.ValidateType(invalidCards1));

        CardElement[] invalidCards2 = {};
        Assert.AreEqual(CardSetType.Invalid, sut.ValidateType(invalidCards2));
    }

    [Test]
    public void TestTwoCardsValidationStrategy_CardValidation()
    {
        var sut = new TwoCardsValidationStrategy();
        // Use the Assert class to test conditions
        CardElement[] validCards = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                     CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Spade) };
        Assert.AreEqual(CardSetType.Pairs, sut.ValidateType(validCards));

        CardElement[] invalidCards1 = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                        CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Diamond) };
        Assert.AreEqual(CardSetType.Invalid, sut.ValidateType(invalidCards1));

        CardElement[] invalidCards2 = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                        CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Spade),
                                        CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Heart) };
        Assert.AreEqual(CardSetType.Invalid, sut.ValidateType(invalidCards2));

        CardElement[] invalidCards3 = {};
        Assert.AreEqual(CardSetType.Invalid, sut.ValidateType(invalidCards3));
    }

    [Test]
    public void TestThreeCardsValidationStrategy_CardValidation()
    {
        var sut = new ThreeCardsValidationStrategy();
        // Use the Assert class to test conditions
        CardElement[] validCards = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                     CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Spade),
                                     CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Club) };
        Assert.AreEqual(CardSetType.Triplets, sut.ValidateType(validCards));

        CardElement[] invalidCards1 = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                        CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Diamond) };
        Assert.AreEqual(CardSetType.Invalid, sut.ValidateType(invalidCards1));

        CardElement[] invalidCards2 = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                        CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Spade),
                                        CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Heart) };
        Assert.AreEqual(CardSetType.Invalid, sut.ValidateType(invalidCards2));

        CardElement[] invalidCards3 = {};
        Assert.AreEqual(CardSetType.Invalid, sut.ValidateType(invalidCards3));
    }

    [Test]
    public void TestStraightFlushValidationStrategy_CardValidation()
    {
        var sut = new StraightFlushValidationStrategy();
        // Use the Assert class to test conditions
        CardElement[] validCards = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                     CardElementFactory.Create(CardElement.Number.Six, CardElement.Suite.Spade),
                                     CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Club),
                                     CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Heart),
                                     CardElementFactory.Create(CardElement.Number.Seven, CardElement.Suite.Spade) };
        Assert.AreEqual(CardSetType.Straight, sut.ValidateType(validCards));

        CardElement[] validCards2 = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                      CardElementFactory.Create(CardElement.Number.Ace, CardElement.Suite.Diamond),
                                      CardElementFactory.Create(CardElement.Number.King, CardElement.Suite.Diamond),
                                      CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Diamond),
                                      CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Diamond) };
        Assert.AreEqual(CardSetType.Flush, sut.ValidateType(validCards2));

        CardElement[] validCards3 = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                      CardElementFactory.Create(CardElement.Number.Six, CardElement.Suite.Diamond),
                                      CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Diamond),
                                      CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Diamond),
                                      CardElementFactory.Create(CardElement.Number.Seven, CardElement.Suite.Diamond) };
        Assert.AreEqual(CardSetType.StraightFlush, sut.ValidateType(validCards3));

        CardElement[] invalidCards1 = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                        CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Diamond) };
        Assert.AreEqual(CardSetType.Invalid, sut.ValidateType(invalidCards1));

        CardElement[] invalidCards2 = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                        CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Spade),
                                        CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Heart) };
        Assert.AreEqual(CardSetType.Invalid, sut.ValidateType(invalidCards2));

        CardElement[] invalidCards3 = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                        CardElementFactory.Create(CardElement.Number.Eight, CardElement.Suite.Spade),
                                        CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Heart),
                                        CardElementFactory.Create(CardElement.Number.Jack, CardElement.Suite.Club) };
        Assert.AreEqual(CardSetType.Invalid, sut.ValidateType(invalidCards3));

        CardElement[] invalidCards4 = {};
        Assert.AreEqual(CardSetType.Invalid, sut.ValidateType(invalidCards4));
    }

    [Test]
    public void TestFivePairsCardsValidationStrategy_CardValidation()
    {
        var sut = new FivePairsCardsValidationStrategy();
        // Use the Assert class to test conditions
        CardElement[] validCards = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                     CardElementFactory.Create(CardElement.Number.Ace, CardElement.Suite.Diamond),
                                     CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Spade),
                                     CardElementFactory.Create(CardElement.Number.Ace, CardElement.Suite.Heart),
                                     CardElementFactory.Create(CardElement.Number.Ace, CardElement.Suite.Club) };
        Assert.AreEqual(CardSetType.FullHouse, sut.ValidateType(validCards));

        CardElement[] validCards2 = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                      CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Club),
                                      CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Spade),
                                      CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Heart),
                                      CardElementFactory.Create(CardElement.Number.Jack, CardElement.Suite.Club) };
        Assert.AreEqual(CardSetType.Quads, sut.ValidateType(validCards2));

        CardElement[] invalidCards1 = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                        CardElementFactory.Create(CardElement.Number.Ace, CardElement.Suite.Diamond),
                                        CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Spade),
                                        CardElementFactory.Create(CardElement.Number.Ace, CardElement.Suite.Heart),
                                        CardElementFactory.Create(CardElement.Number.Jack, CardElement.Suite.Club) };
        Assert.AreEqual(CardSetType.Invalid, sut.ValidateType(invalidCards1));

        CardElement[] invalidCards2 = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                        CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Diamond) };
        Assert.AreEqual(CardSetType.Invalid, sut.ValidateType(invalidCards2));

        CardElement[] invalidCards3 = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                        CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Spade),
                                        CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Heart) };
        Assert.AreEqual(CardSetType.Invalid, sut.ValidateType(invalidCards3));

        CardElement[] invalidCards4 = {};
        Assert.AreEqual(CardSetType.Invalid, sut.ValidateType(invalidCards4));
    }
}
