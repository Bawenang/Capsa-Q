using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public delegate void OnChangeSelectedCards(CardElement[] selectedCards);
    public event OnChangeSelectedCards onChangeSelectedCards;

    public bool isShowing;
    public bool isControllable;
    public bool isInputActive;

    private Dictionary<int, CardElement> cardsInHand = new Dictionary<int, CardElement>();
    private Dictionary<int, CardInGame> cardGameObjectsInHand = new Dictionary<int, CardInGame>();
    private List<int> selectedCardValues = new List<int>();

    public void Populate(CardElement[] cards)
    {
        ClearCardsInHand();
        AddAll(cards);
    }

    public void ClearCardsInHand()
    {
        foreach (var card in cardGameObjectsInHand)
        {
            ObjectPoolController.Instance.Remove(card.Value);
        }
        cardsInHand.Clear();
        cardGameObjectsInHand.Clear();
    }

    private void AddAll(CardElement[] cards)
    {
        var scaleFactor = isShowing ? 1.0f : 0.5f;
        var cardDistance = isShowing ? 0.5f : 0.2f;
        var leftMostCardPos = GetLeftMostPosition(cards, cardDistance);
        for(int i = 0; i < cards.Length; i++)
        {
            var cardValue = cards[i].CardValue;
            cardsInHand.Add(cardValue, cards[i]);
            var newPosX = leftMostCardPos + (i * cardDistance);
            var newPos = new Vector3(newPosX, 0, -0.1f * i);
            var newCard = ObjectPoolController.Instance
                                .Instantiate<CardInGame>(transform.position + newPos,
                                                         Quaternion.identity);
            newCard.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1.0f);
            newCard.transform.parent = this.transform;
            var card = newCard.GetComponent<CardInGame>();
            card.onTap += SelectCard;
            card.Load(cardValue, isShowing, isControllable);
            cardGameObjectsInHand.Add(cardValue, card);
        }
    }

    private float GetLeftMostPosition(CardElement[] cards, float cardDistance)
    {
        return (float)cards.Length * -1f * cardDistance / 2f;
    }

    private void SelectCard(int value)
    {
        if(isControllable && isInputActive) {
            if(selectedCardValues.Contains(value)) {
                selectedCardValues.Remove(value);
                MoveDown(value);
            } else if(selectedCardValues.Count < 5) {
                selectedCardValues.Add(value);
                MoveUp(value);
            }
        }
    }

    private void MoveUp(int cardValue)
    {
        cardGameObjectsInHand[cardValue].transform.Translate(0f, 0.2f, 0f);
    }

    private void MoveDown(int cardValue)
    {
        cardGameObjectsInHand[cardValue].transform.Translate(0f, -0.2f, 0f);
    }
}
