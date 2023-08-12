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
        Debug.Log("Card Set: " + cardSet.Type + " | " + cardSet.HighestCard.CardNumber + " , " + cardSet.HighestCard.CardSuite);
        List<CardElement[]> pairedCardElements = new List<CardElement[]>();
        CardUtils.GetCombinations(cardElements, 2, pairedCardElements);
        var sortedPairs = pairedCardElements.Select(pairs => CardSetFactory.Create(pairs));

        List<CardSet> listHigherCards = new List<CardSet>();
        foreach (CardSet cardSetComparator in sortedPairs)
        {
            Debug.Log("Comparator: " + cardSetComparator.Type + " | " + cardSetComparator.HighestCard.CardNumber + " , " + cardSetComparator.HighestCard.CardSuite);
            if(CardsComparator.IsHigherThan(cardSetComparator, cardSet)) listHigherCards.Add(cardSetComparator);
        }

        return listHigherCards.ToArray();
    }
}

