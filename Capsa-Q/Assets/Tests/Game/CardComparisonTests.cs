using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CardComparisonTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestCardComparison_BetweenCardElements()
    {
        // Use the Assert class to test conditions
        CardElement higherElement = CardElementFactory.Create(CardElement.Number.Two, CardElement.Suite.Spade);
        CardElement lowerElement = CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond);
        Assert.True(CardsComparator.IsHigherThan(higherElement, lowerElement));
        Assert.False(CardsComparator.IsHigherThan(lowerElement, higherElement));
        Assert.False(CardsComparator.IsHigherThan(higherElement, higherElement));
    }

    public void TestCardComparison_BetweenCardSets()
    {
        // Use the Assert class to test conditions
        CardElement higherElement = CardElementFactory.Create(CardElement.Number.Two, CardElement.Suite.Spade);
        CardElement lowerElement = CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond);
        Assert.True(CardsComparator.IsHigherThan(higherElement, lowerElement));
        Assert.False(CardsComparator.IsHigherThan(lowerElement, higherElement));
        Assert.False(CardsComparator.IsHigherThan(higherElement, higherElement));
    }
}
