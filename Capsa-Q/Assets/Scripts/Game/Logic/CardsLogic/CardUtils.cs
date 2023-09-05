using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardUtils
{
    public static int CalculateCardValue(CardElement.Number number, CardElement.Suite suite) 
    {
        if(number == CardElement.Number.Unknown || suite == CardElement.Suite.Unknown) { 
            return -1; 
        }
        return ((int)number * 4) + (int)suite;
    }

    public static CardElement.Number GetCardNumber(int value) 
    {
        if(value < 0 || value >= 52) { return CardElement.Number.Unknown; }
        int numberValue = (value / 4);
        return (CardElement.Number)numberValue;
    }

    public static CardElement.Suite GetCardSuite(int value) 
    {
        if(value < 0 || value >= 52) { return CardElement.Suite.Unknown; }
        int suiteValue = (value % 4);
        return (CardElement.Suite)suiteValue;
    }

    public static void SortCardsDescending(ref CardElement[] sortedCards) 
    {
        Array.Sort(sortedCards, 
                   new Comparison<CardElement>((card1, card2) => 
                        card2.CardValue.CompareTo(card1.CardValue)
                   )
        );
    }

    public static void SortCardSetsAscending(ref CardSet[] sortedCardSets) 
    {
        Array.Sort(sortedCardSets, 
                   new Comparison<CardSet>((cardSet1, cardSet2) => 
                        { 
                            var result = CardsComparator.IsHigherThan(cardSet1, cardSet2) ? 1 : -1;
                            return result;
                        }
                   )
        );
    }

    public static void GetCombinations(CardElement[] source, 
                                       int combinationSize,
                                       List<CardElement[]> resultCombinations)
    {
        CardElement[] data = new CardElement[combinationSize];
        GetCombinations(source, data, 
                        0, source.Length - 1, 
                        0,combinationSize, 
                        resultCombinations);
    }
    
    public static void GetCombinations(CardElement[] source, CardElement[] data,
                                       int start, int end,
                                       int index, int combinationSize,
                                       List<CardElement[]> resultCombinations)
    {
        if (combinationSize == index) { 
            CardElement[] copied = new CardElement[combinationSize];
            data.CopyTo(copied, 0);
            resultCombinations.Add(copied);
            return;
        }
        for (int i = start; i <= end &&
                end - i + 1 >= combinationSize - index; i++)
        {
            data[index] = source[i];
            GetCombinations(source, data, 
                            i + 1, end, 
                            index + 1, combinationSize,
                            resultCombinations);
        }
    }

    public static CardSet GetSingularCardSet(int withValue, CardElement[] fromCards)
    {
        var query = from card in fromCards
                    where card.CardValue == withValue
                    select card;
        
        var foundCard = query.DefaultIfEmpty(CardElementFactory.Unknown).FirstOrDefault();

        if(foundCard.CardNumber == CardElement.Number.Unknown) return CardSetFactory.Invalid;
        else return CardSetFactory.Create(new CardElement[] { foundCard });
    }
}
