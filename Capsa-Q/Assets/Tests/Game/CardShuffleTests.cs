using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CardShuffleTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestCardShuffleAndDeal()
    {
        var sut = new CardShuffler();
        // Use the Assert class to test conditions
        var actualShuffledCards = sut.ShuffleAndDeal();

        AssertPlayerCards(actualShuffledCards[0]);
        AssertPlayerCards(actualShuffledCards[1]);
        AssertPlayerCards(actualShuffledCards[2]);
        AssertPlayerCards(actualShuffledCards[3]);
    }

    private void AssertPlayerCards(CardElement[] actualCards) {
        Assert.AreEqual(13, actualCards.Length);

        for(int i = 0; i<actualCards.Length-1; i++) {
            Assert.IsTrue(actualCards[i].CardValue > actualCards[i+1].CardValue);
        }
    }
}
