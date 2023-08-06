using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CardFactoryTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestCardElementFactory_FromNumberAndSuite()
    {
        // Use the Assert class to test conditions
        Assert.AreEqual(0, GetValue(CardElement.Number.Three, CardElement.Suite.Diamond));
        Assert.AreEqual(1, GetValue(CardElement.Number.Three, CardElement.Suite.Club));
        Assert.AreEqual(2, GetValue(CardElement.Number.Three, CardElement.Suite.Heart));
        Assert.AreEqual(3, GetValue(CardElement.Number.Three, CardElement.Suite.Spade));
        Assert.AreEqual(4, GetValue(CardElement.Number.Four, CardElement.Suite.Diamond));
        Assert.AreEqual(5, GetValue(CardElement.Number.Four, CardElement.Suite.Club));
        Assert.AreEqual(6, GetValue(CardElement.Number.Four, CardElement.Suite.Heart));
        Assert.AreEqual(7, GetValue(CardElement.Number.Four, CardElement.Suite.Spade));
        Assert.AreEqual(8, GetValue(CardElement.Number.Five, CardElement.Suite.Diamond));
        Assert.AreEqual(9, GetValue(CardElement.Number.Five, CardElement.Suite.Club));
        Assert.AreEqual(10, GetValue(CardElement.Number.Five, CardElement.Suite.Heart));
        Assert.AreEqual(11, GetValue(CardElement.Number.Five, CardElement.Suite.Spade));
        Assert.AreEqual(12, GetValue(CardElement.Number.Six, CardElement.Suite.Diamond));
        Assert.AreEqual(13, GetValue(CardElement.Number.Six, CardElement.Suite.Club));
        Assert.AreEqual(14, GetValue(CardElement.Number.Six, CardElement.Suite.Heart));
        Assert.AreEqual(15, GetValue(CardElement.Number.Six, CardElement.Suite.Spade));
        Assert.AreEqual(16, GetValue(CardElement.Number.Seven, CardElement.Suite.Diamond));
        Assert.AreEqual(17, GetValue(CardElement.Number.Seven, CardElement.Suite.Club));
        Assert.AreEqual(18, GetValue(CardElement.Number.Seven, CardElement.Suite.Heart));
        Assert.AreEqual(19, GetValue(CardElement.Number.Seven, CardElement.Suite.Spade));
        Assert.AreEqual(20, GetValue(CardElement.Number.Eight, CardElement.Suite.Diamond));
        Assert.AreEqual(21, GetValue(CardElement.Number.Eight, CardElement.Suite.Club));
        Assert.AreEqual(22, GetValue(CardElement.Number.Eight, CardElement.Suite.Heart));
        Assert.AreEqual(23, GetValue(CardElement.Number.Eight, CardElement.Suite.Spade));
        Assert.AreEqual(24, GetValue(CardElement.Number.Nine, CardElement.Suite.Diamond));
        Assert.AreEqual(25, GetValue(CardElement.Number.Nine, CardElement.Suite.Club));
        Assert.AreEqual(26, GetValue(CardElement.Number.Nine, CardElement.Suite.Heart));
        Assert.AreEqual(27, GetValue(CardElement.Number.Nine, CardElement.Suite.Spade));
        Assert.AreEqual(28, GetValue(CardElement.Number.Ten, CardElement.Suite.Diamond));
        Assert.AreEqual(29, GetValue(CardElement.Number.Ten, CardElement.Suite.Club));
        Assert.AreEqual(30, GetValue(CardElement.Number.Ten, CardElement.Suite.Heart));
        Assert.AreEqual(31, GetValue(CardElement.Number.Ten, CardElement.Suite.Spade));
        Assert.AreEqual(32, GetValue(CardElement.Number.Jack, CardElement.Suite.Diamond));
        Assert.AreEqual(33, GetValue(CardElement.Number.Jack, CardElement.Suite.Club));
        Assert.AreEqual(34, GetValue(CardElement.Number.Jack, CardElement.Suite.Heart));
        Assert.AreEqual(35, GetValue(CardElement.Number.Jack, CardElement.Suite.Spade));
        Assert.AreEqual(36, GetValue(CardElement.Number.Queen, CardElement.Suite.Diamond));
        Assert.AreEqual(37, GetValue(CardElement.Number.Queen, CardElement.Suite.Club));
        Assert.AreEqual(38, GetValue(CardElement.Number.Queen, CardElement.Suite.Heart));
        Assert.AreEqual(39, GetValue(CardElement.Number.Queen, CardElement.Suite.Spade));
        Assert.AreEqual(40, GetValue(CardElement.Number.King, CardElement.Suite.Diamond));
        Assert.AreEqual(41, GetValue(CardElement.Number.King, CardElement.Suite.Club));
        Assert.AreEqual(42, GetValue(CardElement.Number.King, CardElement.Suite.Heart));
        Assert.AreEqual(43, GetValue(CardElement.Number.King, CardElement.Suite.Spade));
        Assert.AreEqual(44, GetValue(CardElement.Number.Ace, CardElement.Suite.Diamond));
        Assert.AreEqual(45, GetValue(CardElement.Number.Ace, CardElement.Suite.Club));
        Assert.AreEqual(46, GetValue(CardElement.Number.Ace, CardElement.Suite.Heart));
        Assert.AreEqual(47, GetValue(CardElement.Number.Ace, CardElement.Suite.Spade));
        Assert.AreEqual(48, GetValue(CardElement.Number.Two, CardElement.Suite.Diamond));
        Assert.AreEqual(49, GetValue(CardElement.Number.Two, CardElement.Suite.Club));
        Assert.AreEqual(50, GetValue(CardElement.Number.Two, CardElement.Suite.Heart));
        Assert.AreEqual(51, GetValue(CardElement.Number.Two, CardElement.Suite.Spade));
    }

    [Test]
    public void TestCardElementFactory_FromValue()
    {
        // Use the Assert class to test conditions
        Assert.AreEqual(CardElement.Number.Three, GetNumber(0));
        Assert.AreEqual(CardElement.Suite.Diamond, GetSuite(0));
        Assert.AreEqual(CardElement.Number.Three, GetNumber(1));
        Assert.AreEqual(CardElement.Suite.Club, GetSuite(1));
        Assert.AreEqual(CardElement.Number.Three, GetNumber(2));
        Assert.AreEqual(CardElement.Suite.Heart, GetSuite(2));
        Assert.AreEqual(CardElement.Number.Three, GetNumber(3));
        Assert.AreEqual(CardElement.Suite.Spade, GetSuite(3));
        Assert.AreEqual(CardElement.Number.Four, GetNumber(4));
        Assert.AreEqual(CardElement.Suite.Diamond, GetSuite(4));
        Assert.AreEqual(CardElement.Number.Four, GetNumber(5));
        Assert.AreEqual(CardElement.Suite.Club, GetSuite(5));
        Assert.AreEqual(CardElement.Number.Four, GetNumber(6));
        Assert.AreEqual(CardElement.Suite.Heart, GetSuite(6));
        Assert.AreEqual(CardElement.Number.Four, GetNumber(7));
        Assert.AreEqual(CardElement.Suite.Spade, GetSuite(7));
        Assert.AreEqual(CardElement.Number.Five, GetNumber(8));
        Assert.AreEqual(CardElement.Suite.Diamond, GetSuite(8));
        Assert.AreEqual(CardElement.Number.Five, GetNumber(9));
        Assert.AreEqual(CardElement.Suite.Club, GetSuite(9));
        Assert.AreEqual(CardElement.Number.Five, GetNumber(10));
        Assert.AreEqual(CardElement.Suite.Heart, GetSuite(10));
        Assert.AreEqual(CardElement.Number.Five, GetNumber(11));
        Assert.AreEqual(CardElement.Suite.Spade, GetSuite(11));
        Assert.AreEqual(CardElement.Number.Six, GetNumber(12));
        Assert.AreEqual(CardElement.Suite.Diamond, GetSuite(12));
        Assert.AreEqual(CardElement.Number.Six, GetNumber(13));
        Assert.AreEqual(CardElement.Suite.Club, GetSuite(13));
        Assert.AreEqual(CardElement.Number.Six, GetNumber(14));
        Assert.AreEqual(CardElement.Suite.Heart, GetSuite(14));
        Assert.AreEqual(CardElement.Number.Six, GetNumber(15));
        Assert.AreEqual(CardElement.Suite.Spade, GetSuite(15));
        Assert.AreEqual(CardElement.Number.Seven, GetNumber(16));
        Assert.AreEqual(CardElement.Suite.Diamond, GetSuite(16));
        Assert.AreEqual(CardElement.Number.Seven, GetNumber(17));
        Assert.AreEqual(CardElement.Suite.Club, GetSuite(17));
        Assert.AreEqual(CardElement.Number.Seven, GetNumber(18));
        Assert.AreEqual(CardElement.Suite.Heart, GetSuite(18));
        Assert.AreEqual(CardElement.Number.Seven, GetNumber(19));
        Assert.AreEqual(CardElement.Suite.Spade, GetSuite(19));
        Assert.AreEqual(CardElement.Number.Eight, GetNumber(20));
        Assert.AreEqual(CardElement.Suite.Diamond, GetSuite(20));
        Assert.AreEqual(CardElement.Number.Eight, GetNumber(21));
        Assert.AreEqual(CardElement.Suite.Club, GetSuite(21));
        Assert.AreEqual(CardElement.Number.Eight, GetNumber(22));
        Assert.AreEqual(CardElement.Suite.Heart, GetSuite(22));
        Assert.AreEqual(CardElement.Number.Eight, GetNumber(23));
        Assert.AreEqual(CardElement.Suite.Spade, GetSuite(23));
        Assert.AreEqual(CardElement.Number.Nine, GetNumber(24));
        Assert.AreEqual(CardElement.Suite.Diamond, GetSuite(24));
        Assert.AreEqual(CardElement.Number.Nine, GetNumber(25));
        Assert.AreEqual(CardElement.Suite.Club, GetSuite(25));
        Assert.AreEqual(CardElement.Number.Nine, GetNumber(26));
        Assert.AreEqual(CardElement.Suite.Heart, GetSuite(26));
        Assert.AreEqual(CardElement.Number.Nine, GetNumber(27));
        Assert.AreEqual(CardElement.Suite.Spade, GetSuite(27));
        Assert.AreEqual(CardElement.Number.Ten, GetNumber(28));
        Assert.AreEqual(CardElement.Suite.Diamond, GetSuite(28));
        Assert.AreEqual(CardElement.Number.Ten, GetNumber(29));
        Assert.AreEqual(CardElement.Suite.Club, GetSuite(29));
        Assert.AreEqual(CardElement.Number.Ten, GetNumber(30));
        Assert.AreEqual(CardElement.Suite.Heart, GetSuite(30));
        Assert.AreEqual(CardElement.Number.Ten, GetNumber(31));
        Assert.AreEqual(CardElement.Suite.Spade, GetSuite(31));
        Assert.AreEqual(CardElement.Number.Jack, GetNumber(32));
        Assert.AreEqual(CardElement.Suite.Diamond, GetSuite(32));
        Assert.AreEqual(CardElement.Number.Jack, GetNumber(33));
        Assert.AreEqual(CardElement.Suite.Club, GetSuite(33));
        Assert.AreEqual(CardElement.Number.Jack, GetNumber(34));
        Assert.AreEqual(CardElement.Suite.Heart, GetSuite(34));
        Assert.AreEqual(CardElement.Number.Jack, GetNumber(35));
        Assert.AreEqual(CardElement.Suite.Spade, GetSuite(35));
        Assert.AreEqual(CardElement.Number.Queen, GetNumber(36));
        Assert.AreEqual(CardElement.Suite.Diamond, GetSuite(36));
        Assert.AreEqual(CardElement.Number.Queen, GetNumber(37));
        Assert.AreEqual(CardElement.Suite.Club, GetSuite(37));
        Assert.AreEqual(CardElement.Number.Queen, GetNumber(38));
        Assert.AreEqual(CardElement.Suite.Heart, GetSuite(38));
        Assert.AreEqual(CardElement.Number.Queen, GetNumber(39));
        Assert.AreEqual(CardElement.Suite.Spade, GetSuite(39));
        Assert.AreEqual(CardElement.Number.King, GetNumber(40));
        Assert.AreEqual(CardElement.Suite.Diamond, GetSuite(40));
        Assert.AreEqual(CardElement.Number.King, GetNumber(41));
        Assert.AreEqual(CardElement.Suite.Club, GetSuite(41));
        Assert.AreEqual(CardElement.Number.King, GetNumber(42));
        Assert.AreEqual(CardElement.Suite.Heart, GetSuite(42));
        Assert.AreEqual(CardElement.Number.King, GetNumber(43));
        Assert.AreEqual(CardElement.Suite.Spade, GetSuite(43));
        Assert.AreEqual(CardElement.Number.Ace, GetNumber(44));
        Assert.AreEqual(CardElement.Suite.Diamond, GetSuite(44));
        Assert.AreEqual(CardElement.Number.Ace, GetNumber(45));
        Assert.AreEqual(CardElement.Suite.Club, GetSuite(45));
        Assert.AreEqual(CardElement.Number.Ace, GetNumber(46));
        Assert.AreEqual(CardElement.Suite.Heart, GetSuite(46));
        Assert.AreEqual(CardElement.Number.Ace, GetNumber(47));
        Assert.AreEqual(CardElement.Suite.Spade, GetSuite(47));
        Assert.AreEqual(CardElement.Number.Two, GetNumber(48));
        Assert.AreEqual(CardElement.Suite.Diamond, GetSuite(48));
        Assert.AreEqual(CardElement.Number.Two, GetNumber(49));
        Assert.AreEqual(CardElement.Suite.Club, GetSuite(49));
        Assert.AreEqual(CardElement.Number.Two, GetNumber(50));
        Assert.AreEqual(CardElement.Suite.Heart, GetSuite(50));
        Assert.AreEqual(CardElement.Number.Two, GetNumber(51));
        Assert.AreEqual(CardElement.Suite.Spade, GetSuite(51));
    }

    [Test]
    public void TestCardElementFactory_FromInvalids()
    {
        // Use the Assert class to test conditions
        Assert.AreEqual(CardElement.Number.Unknown, GetNumber(-1));
        Assert.AreEqual(CardElement.Suite.Unknown, GetSuite(-1));

        Assert.AreEqual(CardElement.Number.Unknown, GetNumber(52));
        Assert.AreEqual(CardElement.Suite.Unknown, GetSuite(52));

        Assert.AreEqual(-1, GetValue(CardElement.Number.Unknown, CardElement.Suite.Spade));
        Assert.AreEqual(-1, GetValue(CardElement.Number.Eight, CardElement.Suite.Unknown));
        Assert.AreEqual(-1, GetValue(CardElement.Number.Unknown, CardElement.Suite.Unknown));
    }

    [Test]
    public void TestCardSetFactory_FromFiveCards() {
        CardElement[] validElementStraight = {
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
            CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Spade),
            CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Heart),
            CardElementFactory.Create(CardElement.Number.Six, CardElement.Suite.Club),
            CardElementFactory.Create(CardElement.Number.Seven, CardElement.Suite.Spade),
        };
        CardSet validSetStraight = CardSetFactory.Create(validElementStraight);
        AssertValidCardSet(validSetStraight, 
                           CardsType.Straight,
                           CardElementFactory.Create(CardElement.Number.Seven, CardElement.Suite.Spade));

        CardElement[] validElementFlush = {
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
            CardElementFactory.Create(CardElement.Number.Two, CardElement.Suite.Diamond),
            CardElementFactory.Create(CardElement.Number.Ace, CardElement.Suite.Diamond),
            CardElementFactory.Create(CardElement.Number.Six, CardElement.Suite.Diamond),
            CardElementFactory.Create(CardElement.Number.King, CardElement.Suite.Diamond),
        };
        CardSet validSetFlush = CardSetFactory.Create(validElementFlush);
        AssertValidCardSet(validSetFlush, 
                           CardsType.Flush,
                           CardElementFactory.Create(CardElement.Number.Two, CardElement.Suite.Diamond));

        CardElement[] validElementStraightFlush = {
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
            CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Diamond),
            CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Diamond),
            CardElementFactory.Create(CardElement.Number.Six, CardElement.Suite.Diamond),
            CardElementFactory.Create(CardElement.Number.Seven, CardElement.Suite.Diamond),
        };
        CardSet validSetStraightFlush = CardSetFactory.Create(validElementStraightFlush);
        AssertValidCardSet(validSetStraightFlush, 
                           CardsType.StraightFlush,
                           CardElementFactory.Create(CardElement.Number.Seven, CardElement.Suite.Diamond));

        CardElement[] validElementFullHouse = {
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Spade),
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Heart),
            CardElementFactory.Create(CardElement.Number.Two, CardElement.Suite.Spade),
            CardElementFactory.Create(CardElement.Number.Two, CardElement.Suite.Diamond),
        };
        CardSet validSetFullHouse = CardSetFactory.Create(validElementFullHouse);
        AssertValidCardSet(validSetFullHouse, 
                           CardsType.FullHouse,
                           CardElementFactory.Create(CardElement.Number.Two, CardElement.Suite.Spade));

        CardElement[] validElementQuads = {
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Spade),
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Heart),
            CardElementFactory.Create(CardElement.Number.Two, CardElement.Suite.Spade),
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Club),
        };
        CardSet validSetQuads = CardSetFactory.Create(validElementQuads);
        AssertValidCardSet(validSetQuads, 
                           CardsType.Quads,
                           CardElementFactory.Create(CardElement.Number.Two, CardElement.Suite.Spade));
    }

    [Test]
    public void TestCardSetFactory_FromThreeCards() {
        CardElement[] validElement = {
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Spade),
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Heart)
        };
        CardSet validSet = CardSetFactory.Create(validElement);
        AssertValidCardSet(validSet, 
                           CardsType.Triplets,
                           CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Spade));
    }

    [Test]
    public void TestCardSetFactory_FromTwoCards() {
        CardElement[] validElement = {
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Spade)
        };
        CardSet validSet = CardSetFactory.Create(validElement);
        AssertValidCardSet(validSet, 
                           CardsType.Pairs,
                           CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Spade));
    }

    [Test]
    public void TestCardSetFactory_FromOneCards() {
        CardElement[] validElement = {
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Spade)
        };
        CardSet validSet = CardSetFactory.Create(validElement);
        AssertValidCardSet(validSet, 
                           CardsType.Singular,
                           CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Spade));
    }

    [Test]
    public void TestCardSetFactory_FromInvalids() {
        CardElement[] invalidElement1 = {};
        CardSet invalidSet1 = CardSetFactory.Create(invalidElement1);
        AssertInvalidCardSet(invalidSet1);

        CardElement[] invalidElement2 = {
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
            CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Spade)
        };
        CardSet invalidSet2 = CardSetFactory.Create(invalidElement2);
        AssertInvalidCardSet(invalidSet2);

        CardElement[] invalidElement3 = {
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
            CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Spade),
            CardElementFactory.Create(CardElement.Number.Nine, CardElement.Suite.Heart)
        };
        CardSet invalidSet3 = CardSetFactory.Create(invalidElement3);
        AssertInvalidCardSet(invalidSet3);

        CardElement[] invalidElement4 = {
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Spade), 
            CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Spade),
            CardElementFactory.Create(CardElement.Number.Nine, CardElement.Suite.Spade),
            CardElementFactory.Create(CardElement.Number.Six, CardElement.Suite.Spade)
        };
        CardSet invalidSet4 = CardSetFactory.Create(invalidElement4);
        AssertInvalidCardSet(invalidSet4);

        CardElement[] invalidElement5 = {
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Spade), 
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond),
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Club),
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Heart)
        };
        CardSet invalidSet5 = CardSetFactory.Create(invalidElement5);
        AssertInvalidCardSet(invalidSet5);

        CardElement[] invalidElement6 = {
            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Spade), 
            CardElementFactory.Create(CardElement.Number.Seven, CardElement.Suite.Diamond),
            CardElementFactory.Create(CardElement.Number.Nine, CardElement.Suite.Club),
            CardElementFactory.Create(CardElement.Number.Jack, CardElement.Suite.Heart),
            CardElementFactory.Create(CardElement.Number.Queen, CardElement.Suite.Spade)
        };
        CardSet invalidSet6 = CardSetFactory.Create(invalidElement6);
        AssertInvalidCardSet(invalidSet6);
    }

    private int GetValue(CardElement.Number number, CardElement.Suite suite) {
        var card = CardElementFactory.Create(number, suite);
        return card.CardValue;
    }

    private CardElement.Number GetNumber(int value) {
        var card = CardElementFactory.Create(value);
        return card.CardNumber;
    }

    private CardElement.Suite GetSuite(int value) {
        var card = CardElementFactory.Create(value);
        return card.CardSuite;
    }

    private void AssertValidCardSet(CardSet actualSet, CardsType expectedType, CardElement expectedHighest) {
        Assert.AreEqual(expectedType, actualSet.Type);
        Assert.AreNotEqual(0, actualSet.Cards.Length);
        Assert.AreEqual(expectedHighest.CardNumber, actualSet.HighestCard.CardNumber);
        Assert.AreEqual(expectedHighest.CardSuite, actualSet.HighestCard.CardSuite);
    }

    private void AssertInvalidCardSet(CardSet actualSet) {
        Assert.AreEqual(CardsType.Invalid, actualSet.Type);
        Assert.AreEqual(0, actualSet.Cards.Length);
        Assert.AreEqual(CardElement.Number.Unknown, actualSet.HighestCard.CardNumber);
        Assert.AreEqual(CardElement.Suite.Unknown, actualSet.HighestCard.CardSuite);
    }
}
