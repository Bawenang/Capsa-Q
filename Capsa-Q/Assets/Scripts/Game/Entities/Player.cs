using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType 
{
    Unknown = -1,
    Player1 = 0,
    Player2 = 1,
    Player3 = 2,
    Player4 = 3
}

public interface Player
{
    bool IsAI { get; }
    PlayerType Type { get; }
    string CharName { get; }
    Sprite IdleSprite { get; }
    Sprite PlaySprite { get; }
    Sprite WinSprite { get; }
    Sprite LoseSprite { get; }
    List<CardElement> Cards { get; }
}

public class BasePlayer: Player
{
    public bool IsAI { get => isAI; }
    public PlayerType Type { get => type; }
    public string CharName { get => charName; }
    public Sprite IdleSprite { get => sprites[SpriteState.Idle]; }
    public Sprite PlaySprite { get => sprites[SpriteState.Play]; }
    public Sprite WinSprite { get => sprites[SpriteState.Win]; }
    public Sprite LoseSprite { get => sprites[SpriteState.Lose]; }
    public List<CardElement> Cards { get => cards; }

    protected bool isAI;
    protected PlayerType type;
    protected string charName;
    protected Dictionary<SpriteState, Sprite> sprites = new Dictionary<SpriteState, Sprite>();
    protected List<CardElement> cards = new List<CardElement>();

    public BasePlayer(PlayerType type, CharacterData character, CardElement[] cards, bool isAI) {
        this.isAI = isAI;
        this.type = type;
        sprites.Add(SpriteState.Idle, character.GetSprite(SpriteState.Idle));
        sprites.Add(SpriteState.Play, character.GetSprite(SpriteState.Play));
        sprites.Add(SpriteState.Win, character.GetSprite(SpriteState.Win));
        sprites.Add(SpriteState.Lose, character.GetSprite(SpriteState.Lose));
        charName = character.charName;
        this.cards.AddRange(cards);
    }
}