using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public interface ICardsValidationStrategy
{
    CardSetType ValidateType(CardElement[] cards);
}

public class OneCardValidationStrategy: ICardsValidationStrategy 
{
    public CardSetType ValidateType(CardElement[] cards) 
    {
        if(cards.Length == 1) {
            return CardSetType.Singular;
        } else {
            return CardSetType.Invalid;
        }
    }
}

public class TwoCardsValidationStrategy: ICardsValidationStrategy 
{
    public CardSetType ValidateType(CardElement[] cards) 
    {
        if(cards.Length == 2 && cards[0].CardNumber == cards[1].CardNumber) {
            return CardSetType.Pairs;
        } else {
            return CardSetType.Invalid;
        }
    }
}

public class ThreeCardsValidationStrategy: ICardsValidationStrategy 
{
    public CardSetType ValidateType(CardElement[] cards) 
    {
        if(cards.Length == 3 && 
           cards[0].CardNumber == cards[1].CardNumber && 
           cards[0].CardNumber == cards[2].CardNumber) {
            return CardSetType.Triplets;
        } else {
            return CardSetType.Invalid;
        }
    }
}

public class StraightFlushValidationStrategy: ICardsValidationStrategy 
{
    private CardElement[] sortedCards = new CardElement[5];
    public CardSetType ValidateType(CardElement[] cards) 
    {
        if(cards.Length == 5) {
            SortCards(cards);
            bool isStraight = IsStraight(sortedCards);
            bool isFlush = IsFlush(sortedCards);
            if(isStraight && isFlush) { 
                return CardSetType.StraightFlush;
            } else if(isStraight) {
                return CardSetType.Straight;
            } else if(isFlush) {
                return CardSetType.Flush;
            } else {
                return CardSetType.Invalid;
            }
        } else {
            return CardSetType.Invalid;
        }
    }

    private void SortCards(CardElement[] cards) 
    {
        sortedCards = cards;
        CardUtils.SortCardsDescending(ref sortedCards);
    }

    private bool IsStraight(CardElement[] sortedCards) 
    {
        return IsNumberOneLevelAbove(sortedCards[0], sortedCards[1]) &&
               IsNumberOneLevelAbove(sortedCards[1], sortedCards[2]) &&
               IsNumberOneLevelAbove(sortedCards[2], sortedCards[3]) &&
               IsNumberOneLevelAbove(sortedCards[3], sortedCards[4]);
    }
    private bool IsNumberOneLevelAbove(CardElement first, CardElement second) 
    {
        return (int)first.CardNumber == ((int)second.CardNumber)+1;
    }

    public bool IsFlush(CardElement[] sortedCards) 
    {
        return IsSameSuite(sortedCards[0], sortedCards[1]) &&
               IsSameSuite(sortedCards[1], sortedCards[2]) &&
               IsSameSuite(sortedCards[2], sortedCards[3]) &&
               IsSameSuite(sortedCards[3], sortedCards[4]);
    }

    private bool IsSameSuite(CardElement first, CardElement second) 
    {
        return first.CardSuite == second.CardSuite;
    }
}

public class FivePairsCardsValidationStrategy: ICardsValidationStrategy 
{
    private Dictionary<int, int> numberDict = new Dictionary<int, int>();
    public CardSetType ValidateType(CardElement[] cards) 
    {
        if(cards.Length == 5) {
            PopulateDictionary(cards);
            if(numberDict.Count != 2) {
                return CardSetType.Invalid;
            }

            var valueArray = numberDict.Values.ToArray();
            if(valueArray[0] == 4 || valueArray[1] == 4) {
                return CardSetType.Quads;
            } else {
                return CardSetType.FullHouse;
            }
        } else {
            return CardSetType.Invalid;
        }
    }

    private void PopulateDictionary(CardElement[] cards) 
    {
        numberDict = new Dictionary<int, int>();
        foreach(CardElement elem in cards) {
            int number = (int)elem.CardNumber;
            if(numberDict.ContainsKey(number)) {
                numberDict[number] += 1; 
            } else {
                numberDict.Add(number, 1);
            }
        }
    }
    public bool IsValid(CardElement[] cards) 
    {
        if(cards.Length == 5) {
            HashSet<int> numbers = new HashSet<int>();
            foreach(CardElement elem in cards) {
                int number = (int)elem.CardNumber;
                if(!numbers.Contains(number)) {
                    if(numbers.Count == 2) {
                        return false;
                    } else {
                        numbers.Add(number);
                    }
                }
            }
            return true;
        } else {
            return false;
        }
    }

    private bool IsSameSuite(CardElement first, CardElement second) 
    {
        return first.CardSuite == second.CardSuite;
    }
}