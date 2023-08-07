using System;
using System.Collections.Generic;
using System.Linq;

public interface CardShuffling {
    CardElement[][] ShuffleAndDeal();
}

public class CardShuffler : CardShuffling
{
    private CardElement[] deck;
    public CardShuffler() {
        var cardNumbers = Enumerable.Range(0, 52).ToArray();
        deck = cardNumbers.Select(value => CardElementFactory.Create(value)).ToArray();
    }

    public CardElement[][] ShuffleAndDeal() {
        var shuffledDeck = Shuffle(deck);
        List<CardElement> cardsPlayer1 = new List<CardElement>();
        List<CardElement> cardsPlayer2 = new List<CardElement>();
        List<CardElement> cardsPlayer3 = new List<CardElement>();
        List<CardElement> cardsPlayer4 = new List<CardElement>();

        for(int i = 0; i < shuffledDeck.Length; i++) {
            var playerNumber = i % 4;
            var card = shuffledDeck[i];
            if(playerNumber == 0) cardsPlayer1.Add(card);
            else if(playerNumber == 1) cardsPlayer2.Add(card);
            else if(playerNumber == 2) cardsPlayer3.Add(card);
            else if(playerNumber == 3) cardsPlayer4.Add(card);
        }        

        return new CardElement[][] {
            SortedCards(cardsPlayer1),
            SortedCards(cardsPlayer2),
            SortedCards(cardsPlayer3),
            SortedCards(cardsPlayer4)
        };
    }

    private static CardElement[] Shuffle(CardElement[] cards)
    {
        System.Random r = new System.Random();
        List<CardElement> shuffled = new List<CardElement>(cards);
        
        for (int n = shuffled.Count - 1; n > 0; --n)
        {
            int k = r.Next(n + 1);

            CardElement temp = shuffled[n];
            shuffled[n] = shuffled[k];
            shuffled[k] = temp;
        }

        return shuffled.ToArray();
    }

    private CardElement[] SortedCards(List<CardElement> cardList) {
        CardElement[] cards = cardList.ToArray();
        CardUtils.SortCardsDescending(ref cards);
        return cards;
    }
}
