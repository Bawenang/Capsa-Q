using System.Collections.Generic;
using System.Linq;
using System;

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

// public class HigherTwoCardsStrategy
// {
//     public CardSet[] GetHigherSets(CardSet cardSet, CardElement[] cardElements)
//     {
//         var sortedCards = cardElements;
//         CardUtils.SortCardsDescending(ref sortedCards);

//         List<CardSet> listHigherCards = new List<CardSet>();
//         foreach (CardElement card in sortedCards)
//         {
//             if(CardsComparator.IsHigherThan(card, cardSet)) listHigherCards.Add(card);
//         }

//         return listHigherCards.ToArray();
//     }
// }

