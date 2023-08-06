using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsComparator
{
    public static bool IsHigherThan(CardElement element, CardElement comparator) {
        return element.CardValue > comparator.CardValue;
    }

}
