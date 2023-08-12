using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public interface HigherCardSetStrategy
{
    CardSet[] GetHigherSets(CardSet cardSet, CardElement[] cardElements);
    
}

public class HigherOneCardStrategy
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

public class HigherTwoCardsStrategy
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

public class HigherThreeCardsStrategy
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

