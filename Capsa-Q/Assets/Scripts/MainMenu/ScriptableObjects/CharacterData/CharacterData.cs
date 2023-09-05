using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData", order = 1)]
public class CharacterData : ScriptableObject
{
    public string charName;

    public string GetSpriteName(SpriteState state) 
    {
        switch (state)
        {
            case SpriteState.Idle: return charName + "_idle";
            case SpriteState.Play: return charName + "_play";
            case SpriteState.Win: return charName + "_win";
            case SpriteState.Lose: return charName + "_lose";
            default: return "";
        }
    }

    public Sprite GetSprite(SpriteState state) 
    {
        var spriteName = GetSpriteName(state);
        return AtlasSpriteStore.Instance.GetSprite(spriteName);
    }
}
