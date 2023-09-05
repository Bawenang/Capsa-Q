using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : BasePlayer
{
    private ICardSelector selector;
    public AIPlayer(PlayerType type, CharacterData character, CardElement[] cards,
                    ICardSelector selector) : 
            base(type, character, cards) 
    {
        this.selector = selector;
    }

    public CardSet SelectPlayCardSet(CardSet currentPlayedCardSet)
    {
        return selector.SelectCardSet(currentPlayedCardSet, cards.ToArray());
    }
}
