using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsComparator
{
    public static bool IsHigherThan(CardElement element, CardElement comparator) {
        return element.CardValue > comparator.CardValue;
    }

    public static bool IsHigherThan(CardSet cardSet, CardSet comparator) {
        int toCompareTypeRank = (int)cardSet.SetType;
        int comparatorTypeRank = (int)comparator.SetType;

        if(toCompareTypeRank > comparatorTypeRank) {
            return true;
        } 

        if(toCompareTypeRank == comparatorTypeRank) {
            return cardSet.HighestCard.CardValue > comparator.HighestCard.CardValue;
        }

        return false;
    }

}
