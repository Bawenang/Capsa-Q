using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameRepository: MonoBehaviour
{
    public PlayerType lastPlaying;
    public CardSet[] PlayedCards { get => playedCards.ToArray(); }

    private Dictionary<PlayerType, Player> players;
    private List<CardSet> playedCards;

    public Player GetPlayer(PlayerType type) 
    {
        return players[type];
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
        return playedCards.Last();
    }

}
