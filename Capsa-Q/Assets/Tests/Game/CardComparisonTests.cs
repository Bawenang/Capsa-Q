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

    [Test]
    public void TestCardComparison_BetweenCardSets_StraightFlushShouldBeHigherThanQuads()
    {
        // Use the Assert class to test conditions
        CardSet straightFlush = CreateStraightFlush();
        CardSet quads = CreateQuads();
        Assert.True(CardsComparator.IsHigherThan(straightFlush, quads));
        Assert.False(CardsComparator.IsHigherThan(quads, straightFlush));
    }

    [Test]
    public void TestCardComparison_BetweenCardSets_QuadsShouldBeHigherThanFullHouse()
    {
        // Use the Assert class to test conditions
        CardSet quads = CreateQuads();
        CardSet fullHouse = CreateFullHouse();
        Assert.True(CardsComparator.IsHigherThan(quads, fullHouse));
        Assert.False(CardsComparator.IsHigherThan(fullHouse, quads));
    }

    [Test]
    public void TestCardComparison_BetweenCardSets_FullHouseShouldBeHigherThanFlush()
    {
        // Use the Assert class to test conditions
        CardSet fullHouse = CreateFullHouse();
        CardSet flush = CreateFlush();
        Assert.True(CardsComparator.IsHigherThan(fullHouse, flush));
        Assert.False(CardsComparator.IsHigherThan(flush, fullHouse));
    }

    [Test]
    public void TestCardComparison_BetweenCardSets_FlushShouldBeHigherThanStraight()
    {
        // Use the Assert class to test conditions
        CardSet flush = CreateFlush();
        CardSet straight = CreateStraight();
        Assert.True(CardsComparator.IsHigherThan(flush, straight));
        Assert.False(CardsComparator.IsHigherThan(straight, flush));
    }

    [Test]
    public void TestCardComparison_BetweenCardSets_StraightShouldBeHigherThanTriplets()
    {
        // Use the Assert class to test conditions
        CardSet straight = CreateStraight();
        CardSet triplets = CreateTriplets();
        Assert.True(CardsComparator.IsHigherThan(straight, triplets));
        Assert.False(CardsComparator.IsHigherThan(triplets, straight));
    }

    [Test]
    public void TestCardComparison_BetweenCardSets_TripletsShouldBeHigherThanPairs()
    {
        // Use the Assert class to test conditions
        CardSet triplets = CreateTriplets();
        CardSet pairs = CreatePairs();
        Assert.True(CardsComparator.IsHigherThan(triplets, pairs));
        Assert.False(CardsComparator.IsHigherThan(pairs, triplets));
    }

    [Test]
    public void TestCardComparison_BetweenCardSets_PairsShouldBeHigherThanSingular()
    {
        // Use the Assert class to test conditions
        CardSet pairs = CreatePairs();
        CardSet singular = CreateSingular();
        Assert.True(CardsComparator.IsHigherThan(pairs, singular));
        Assert.False(CardsComparator.IsHigherThan(singular, pairs));
    }

    [Test]
    public void TestGetCombinations()
    {
        List<CardElement> mainArray = new List<CardElement> {  
                            CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                            CardElementFactory.Create(CardElement.Number.Six, CardElement.Suite.Diamond),
                            CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Diamond),
                            CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Diamond),
                            CardElementFactory.Create(CardElement.Number.Seven, CardElement.Suite.Diamond),
                            CardElementFactory.Create(CardElement.Number.Seven, CardElement.Suite.Club),
                            CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Spade) 
                            };
        int combinationSize = 5;

        List<CardElement[]> result = new List<CardElement[]>();
        CardElement[] data = new CardElement[combinationSize];
         

        CardsComparator.GetCombinations(mainArray.ToArray(), data, 
                               0, mainArray.Count - 1, 
                               0, combinationSize,
                               result);

        Assert.AreEqual(21, result.Count);

    }
    private CardSet CreateStraightFlush() {
        CardElement[] cards = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                CardElementFactory.Create(CardElement.Number.Six, CardElement.Suite.Diamond),
                                CardElementFactory.Create(CardElement.Number.Five, CardElement.Suite.Diamond),
                                CardElementFactory.Create(CardElement.Number.Four, CardElement.Suite.Diamond),
                                CardElementFactory.Create(CardElement.Number.Seven, CardElement.Suite.Diamond) };
        return CardSetFactory.Create(cards);
    }

    private CardSet CreateQuads() {
        CardElement[] cards = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Club),
                                CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Spade),
                                CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Heart),
                                CardElementFactory.Create(CardElement.Number.Seven, CardElement.Suite.Diamond) };
        return CardSetFactory.Create(cards);
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

    private CardSet CreateTriplets() {
        CardElement[] cards = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Club),
                                CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Spade) };
        return CardSetFactory.Create(cards);
    }

    private CardSet CreatePairs() {
        CardElement[] cards = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond), 
                                CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Club) };
        return CardSetFactory.Create(cards);
    }

    private CardSet CreateSingular() {
        CardElement[] cards = { CardElementFactory.Create(CardElement.Number.Three, CardElement.Suite.Diamond) };
        return CardSetFactory.Create(cards);
    }
}
