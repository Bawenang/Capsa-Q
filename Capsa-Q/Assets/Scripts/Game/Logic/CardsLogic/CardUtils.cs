using System;
using System.Collections.Generic;

public class CardUtils
{
    public static int CalculateCardValue(CardElement.Number number, CardElement.Suite suite) {
        if(number == CardElement.Number.Unknown || suite == CardElement.Suite.Unknown) { 
            return -1; 
        }
        return ((int)number * 4) + (int)suite;
    }

    public static CardElement.Number GetCardNumber(int value) {
        if(value < 0 || value >= 52) { return CardElement.Number.Unknown; }
        int numberValue = (value / 4);
        return (CardElement.Number)numberValue;
    }

    public static CardElement.Suite GetCardSuite(int value) {
        if(value < 0 || value >= 52) { return CardElement.Suite.Unknown; }
        int suiteValue = (value % 4);
        return (CardElement.Suite)suiteValue;
    }

    public static void SortCardsDescending(ref CardElement[] sortedCards) {
        Array.Sort(sortedCards, 
                   new Comparison<CardElement>((card1, card2) => 
                        card2.CardValue.CompareTo(card1.CardValue)
                   )
        );
    }

    public static void GetCombinations(CardElement[] source, CardElement[] data,
                                       int combinationSize,
                                       List<CardElement[]> resultCombinations)
    {
        GetCombinations(source, data, 
                        0, source.Length - 1, 
                        0,combinationSize, 
                        resultCombinations);
    }
    
    public static void GetCombinations(CardElement[] source, CardElement[] data,
                                       int start, int end,
                                       int index, int combinationSize,
                                       List<CardElement[]> resultCombinations)
    {
        if (combinationSize == index) { 
            resultCombinations.Add(data);
            Console.WriteLine(">>> " + data[0].CardValue + ", " + data[1].CardValue + ", " + data[2].CardValue + ", " + data[3].CardValue + ", " + data[4].CardValue);
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
