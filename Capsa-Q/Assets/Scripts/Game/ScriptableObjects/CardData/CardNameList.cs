using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[CreateAssetMenu(fileName = "CardNameList", menuName = "ScriptableObjects/CardNameList", order = 2)]
public class CardNameList : ScriptableObject
{
    public string[] cardNames;
    public string backfaceName;

    public Sprite GetSprite(int value) 
    {
        if(value >= 0 && value < 52) {
            return AtlasSpriteStore.Instance.GetSprite(cardNames[value]);
        } else {
            return AtlasSpriteStore.Instance.GetSprite(backfaceName);
        }
    }
}
