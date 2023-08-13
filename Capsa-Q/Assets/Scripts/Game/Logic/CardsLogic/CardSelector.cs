using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CardSelecting
{
    CardSet SelectCardSet(CardSet cardSet, CardElement[] cardElements);
}

public class CardSelector : CardSelecting
{
    private HigherOneCardStrategy[] strategies;
    public CardSet SelectCardSet(CardSet cardSet, CardElement[] cardElements)
    {
        for(int i = 0; i < strategies.Length; i++) {
            var higherCardSets = strategies[i].GetHigherSets(cardSet, cardElements);
            if(higherCardSets.Length > 0) {
                CardUtils.SortCardSetsAscending(ref higherCardSets);
                return higherCardSets[0];
            }
        }
        return CardSetFactory.Invalid;
    }

    public CardSelector(HigherOneCardStrategy[] strategies)
    {
        this.strategies = strategies;
    }
}
