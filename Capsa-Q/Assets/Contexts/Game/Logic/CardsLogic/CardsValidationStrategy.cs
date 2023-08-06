using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public interface CardsValidationStrategy
{
    CardsType ValidateType(CardElement[] cards);
}

public class OneCardValidationStrategy: CardsValidationStrategy {
    public CardsType ValidateType(CardElement[] cards) {
        if(cards.Length == 1) {
            return CardsType.Singular;
        } else {
            return CardsType.Invalid;
        }
    }
}

public class TwoCardsValidationStrategy: CardsValidationStrategy {
    public CardsType ValidateType(CardElement[] cards) {
        if(cards.Length == 2 && cards[0].CardNumber == cards[1].CardNumber) {
            return CardsType.Pairs;
        } else {
            return CardsType.Invalid;
        }
    }
}

public class ThreeCardsValidationStrategy: CardsValidationStrategy {
    public CardsType ValidateType(CardElement[] cards) {
        if(cards.Length == 3 && 
           cards[0].CardNumber == cards[1].CardNumber && 
           cards[0].CardNumber == cards[2].CardNumber) {
            return CardsType.Triplets;
        } else {
            return CardsType.Invalid;
        }
    }
}

public class StraightFlushValidationStrategy: CardsValidationStrategy {
    private CardElement[] sortedCards = new CardElement[5];
    public CardsType ValidateType(CardElement[] cards) {
        if(cards.Length == 5) {
            SortCards(cards);
            bool isStraight = IsStraight(sortedCards);
            bool isFlush = IsFlush(sortedCards);
            if(isStraight && isFlush) { 
                return CardsType.StraightFlush;
            } else if(isStraight) {
                return CardsType.Straight;
            } else if(isFlush) {
                return CardsType.Flush;
            } else {
                return CardsType.Invalid;
            }
        } else {
            return CardsType.Invalid;
        }
    }

    private void SortCards(CardElement[] cards) {
        sortedCards = cards;
        Array.Sort(sortedCards, 
                   new Comparison<CardElement>((card1, card2) => 
                        card2.CardValue.CompareTo(card1.CardValue)
                   )
        );
    }

    private bool IsStraight(CardElement[] sortedCards) {
        return IsNumberOneLevelAbove(sortedCards[0], sortedCards[1]) &&
               IsNumberOneLevelAbove(sortedCards[1], sortedCards[2]) &&
               IsNumberOneLevelAbove(sortedCards[2], sortedCards[3]) &&
               IsNumberOneLevelAbove(sortedCards[3], sortedCards[4]);
    }
    private bool IsNumberOneLevelAbove(CardElement first, CardElement second) {
        return (int)first.CardNumber == ((int)second.CardNumber)+1;
    }

    public bool IsFlush(CardElement[] sortedCards) {
        return IsSameSuite(sortedCards[0], sortedCards[1]) &&
               IsSameSuite(sortedCards[1], sortedCards[2]) &&
               IsSameSuite(sortedCards[2], sortedCards[3]) &&
               IsSameSuite(sortedCards[3], sortedCards[4]);
    }

    private bool IsSameSuite(CardElement first, CardElement second) {
        return first.CardSuite == second.CardSuite;
    }
}

public class FivePairsCardsValidationStrategy: CardsValidationStrategy {
    private Dictionary<int, int> numberDict = new Dictionary<int, int>();
    public CardsType ValidateType(CardElement[] cards) {
        if(cards.Length == 5) {
            PopulateDictionary(cards);
            if(numberDict.Count != 2) {
                return CardsType.Invalid;
            }

            var valueArray = numberDict.Values.ToArray();
            if(valueArray[0] == 4 || valueArray[1] == 4) {
                return CardsType.Quads;
            } else {
                return CardsType.FullHouse;
            }
        } else {
            return CardsType.Invalid;
        }
    }

    private void PopulateDictionary(CardElement[] cards) {
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
    public bool IsValid(CardElement[] cards) {
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

    private bool IsSameSuite(CardElement first, CardElement second) {
        return first.CardSuite == second.CardSuite;
    }
}