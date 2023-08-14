using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameRepository
{
    public PlayerType lastPlaying = PlayerType.Unknown;
    public CardSet[] PlayedCards { get => playedCards.ToArray(); }

    private Dictionary<PlayerType, Player> players = new Dictionary<PlayerType, Player>();
    private List<CardSet> playedCards = new List<CardSet>();

    public Player GetPlayer(PlayerType type) 
    {
        return players[type];
    }

    public void ResetPlayedCards()
    {
        playedCards.Clear();
    }

    public void AddPlayer(PlayerType type, Player player) 
    {
        players.Add(type, player);
    }

    public void AddPlayedCard(CardSet cardSet) 
    {
        playedCards.Add(cardSet);
    }

    public CardSet GetTopPlayedCards() 
    {
        if(playedCards.Count == 0) return CardSetFactory.CreateInvalid();
        return playedCards.Last();
    }

}
