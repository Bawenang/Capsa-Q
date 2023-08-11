using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsComparator
{
    public static bool IsHigherThan(CardElement element, CardElement comparator) {
        return element.CardValue > comparator.CardValue;
    }

    public static bool IsHigherThan(CardSet cardSet, CardSet comparator) {
        int toCompareTypeRank = (int)cardSet.Type;
        int comparatorTypeRank = (int)comparator.Type;

        if(toCompareTypeRank > comparatorTypeRank) {
            return true;
        } 

        if(toCompareTypeRank == comparatorTypeRank) {
            return cardSet.HighestCard.CardValue > comparator.HighestCard.CardValue;
        }

        return false;
    }

    public static void GetCombinations(CardElement[] source, CardElement[] data,
                                       int start, int end,
                                       int index, int combinationSize,
                                       List<CardElement[]> resultCombinations)
    {
        if (combinationSize == index) { 
            resultCombinations.Add(data);
            Debug.Log(">>> " + data[0].CardValue + ", " + data[1].CardValue + ", " + data[2].CardValue + ", " + data[3].CardValue + ", " + data[4].CardValue);
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
}
