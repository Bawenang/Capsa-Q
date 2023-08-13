using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public interface HigherCardSetStrategy
{
    CardSet[] GetHigherSets(CardSet cardSet, CardElement[] cardElements);
    
}

public class HigherOneCardStrategy: HigherCardSetStrategy
{
    public CardSet[] GetHigherSets(CardSet cardSet, CardElement[] cardElements)
    {
        if(cardSet.Type != CardsType.Singular) return Array.Empty<CardSet>();
        var sortedCards = cardElements;
        CardUtils.SortCardsDescending(ref sortedCards);
        var sortedSingulars = sortedCards.Select(card => CardSetFactory.Create(new CardElement[] { card } ));

        List<CardSet> listHigherCards = new List<CardSet>();
        foreach (CardSet cardSetComparator in sortedSingulars)
        {
            if(CardsComparator.IsHigherThan(cardSetComparator, cardSet)) listHigherCards.Add(cardSetComparator);
        }

        return listHigherCards.ToArray();
    }
}

public class HigherTwoCardsStrategy: HigherCardSetStrategy
{
    public CardSet[] GetHigherSets(CardSet cardSet, CardElement[] cardElements)
    {
        if(cardSet.Type > CardsType.Pairs) return Array.Empty<CardSet>();
        List<CardElement[]> pairedCardElements = new List<CardElement[]>();
        CardUtils.GetCombinations(cardElements, 2, pairedCardElements);
        var sortedPairs = pairedCardElements.Select(pairs => CardSetFactory.Create(pairs));

        List<CardSet> listHigherCards = new List<CardSet>();
        foreach (CardSet cardSetComparator in sortedPairs)
        {
            if(CardsComparator.IsHigherThan(cardSetComparator, cardSet)) listHigherCards.Add(cardSetComparator);
        }

        return listHigherCards.ToArray();
    }
}

public class HigherThreeCardsStrategy: HigherCardSetStrategy
{
    public CardSet[] GetHigherSets(CardSet cardSet, CardElement[] cardElements)
    {
        if(cardSet.Type > CardsType.Triplets) return Array.Empty<CardSet>();
        List<CardElement[]> pairedCardElements = new List<CardElement[]>();
        CardUtils.GetCombinations(cardElements, 3, pairedCardElements);
        var sortedTris = pairedCardElements.Select(tris => CardSetFactory.Create(tris));

        List<CardSet> listHigherCards = new List<CardSet>();
        foreach (CardSet cardSetComparator in sortedTris)
        {
            if(CardsComparator.IsHigherThan(cardSetComparator, cardSet)) listHigherCards.Add(cardSetComparator);
        }

        return listHigherCards.ToArray();
    }
}

public class HigherFiveCardsStrategy: HigherCardSetStrategy
{
    public CardSet[] GetHigherSets(CardSet cardSet, CardElement[] cardElements)
    {
        if(cardSet.Type == CardsType.StraightFlush) return Array.Empty<CardSet>(); //Nothing is higher than straight flush
        List<CardElement[]> fiveCardElements = new List<CardElement[]>();
        CardUtils.GetCombinations(cardElements, 5, fiveCardElements);
        var sortedCards = fiveCardElements.Select(cards => CardSetFactory.Create(cards));

        List<CardSet> listHigherCards = new List<CardSet>();
        foreach (CardSet cardSetComparator in sortedCards)
        {
            if(CardsComparator.IsHigherThan(cardSetComparator, cardSet)) listHigherCards.Add(cardSetComparator);
        }

        return listHigherCards.ToArray();
    }
}
