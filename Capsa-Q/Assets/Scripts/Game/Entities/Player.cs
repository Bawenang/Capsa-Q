using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Player
{
    string CharName { get; }
    Sprite IdleSprite { get; }
    Sprite PlaySprite { get; }
    Sprite WinSprite { get; }
    Sprite LoseSprite { get; }
    List<CardElement> Cards { get; }
}

public abstract class BasePlayer: Player
{
    public string CharName { get => charName; }
    public Sprite IdleSprite { get => sprites[SpriteState.Idle]; }
    public Sprite PlaySprite { get => sprites[SpriteState.Play]; }
    public Sprite WinSprite { get => sprites[SpriteState.Win]; }
    public Sprite LoseSprite { get => sprites[SpriteState.Lose]; }
    public List<CardElement> Cards { get => cards; }

    private string charName;
    private Dictionary<SpriteState, Sprite> sprites = new Dictionary<SpriteState, Sprite>();
    private List<CardElement> cards = new List<CardElement>();

    public BasePlayer(CharacterData character, CardElement[] cards) {
        sprites.Add(SpriteState.Idle, character.GetSprite(SpriteState.Idle));
        sprites.Add(SpriteState.Play, character.GetSprite(SpriteState.Play));
        sprites.Add(SpriteState.Win, character.GetSprite(SpriteState.Win));
        sprites.Add(SpriteState.Lose, character.GetSprite(SpriteState.Lose));
        charName = character.charName;
        this.cards.AddRange(cards);
    }
}