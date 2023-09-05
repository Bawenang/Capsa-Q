using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICardSelector
{
    CardSet SelectCardSet(CardSet cardSet, CardElement[] cardElements);
}

public class CardSelector : ICardSelector
{
    private IHigherCardSetStrategy[] strategies;

    public CardSelector(IHigherCardSetStrategy[] strategies)
    {
        this.strategies = strategies;
    }

    public CardSet SelectCardSet(CardSet cardSet, CardElement[] cardElements)
    {
        for(int i = 0; i < strategies.Length; i++) {
            var higherCardSets = strategies[i].GetHigherSets(cardSet, cardElements);
            if(higherCardSets.Length > 0 && !IsInvalidSets(higherCardSets)) {
                CardUtils.SortCardSetsAscending(ref higherCardSets);
                return higherCardSets[0];
            }
        }
        return CardSetFactory.Invalid;
    }

    private bool IsInvalidSets(CardSet[] cardSet)
    {
        foreach (var card in cardSet)
        {
            if(card.SetType != CardSetType.Invalid) return false;
        }
        return true;
    }
}
